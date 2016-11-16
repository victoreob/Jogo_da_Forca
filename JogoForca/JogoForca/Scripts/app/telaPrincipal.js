class TelaPrincipal {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    $('#game-over').hide();
    $('#winner').hide();
    this.palavras = new Palavras();
    this.jogadas = new Jogadas();
    this.usuarios = new Usuarios();
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
    this.errosLetras = 0;
    this.acertosLetras = 0;
  }

  registrarBindsEventos() {
    this.validarLetraFomulario();
    this.validarPalavraFormulario();
    this.validarFiltroFormulario();
    let self = this;
    self.$btnProximaPagina = $('#btn-proxima-pagina');
    self.$btnPaginaAnterior = $('#btn-pagina-anterior');
    self.$btnProximaPagina.on('click', self.obterProximaPagina.bind(self));
    self.$btnPaginaAnterior.on('click', self.obterPaginaAnterior.bind(self));
    if (self.paginaAtual <= 1) {
      self.$btnPaginaAnterior.attr('disabled', true);
    } else {
      self.$btnPaginaAnterior.removeAttr('disabled');
      self.$btnProximaPagina.removeAttr('disabled');
    }
    let ultimaPagina = self.paginaAtual * self.qtdHeroisPorPagina >= self.qtdTotalRegistros;
    if (ultimaPagina) {
      self.$btnProximaPagina.attr('disabled', true);
    }
    $('#resetar-jogo').on('click', function () {
      let jogada = window.sessionStorage.getObj('jogada');
      self.jogadas.resetarPontos(jogada)
        .done(() => {
          let usuario = window.sessionStorage.getObj('usuario');
          if (jogada.Dificuldade === 'normal')
            window.localStorage.setObj(usuario.Nome + jogada.Dificuldade, self.palavras.pegarPalavrasNivelNormal());
          else
            window.localStorage.setObj(usuario.Nome + jogada.Dificuldade, self.palavras.pegarRegistrosNivelBh());
          jogoDaForca.renderizarTela('login');
        });
    });
    $('#leaderboard').on('click', function () {
      let $subTelas = $('.sub-tela');
      $.each($subTelas, (indice, elem) => $(elem).hide());
      self.carregarERenderizarJogadas(1);
    });
  }

  obterProximaPagina() {
    this.carregarERenderizarJogadas(++this.paginaAtual);
  }

  obterPaginaAnterior() {
    this.carregarERenderizarJogadas(--this.paginaAtual);
  }

  carregarERenderizarJogadas(pagina) {
    self.jogadas.buscarRanking(pagina)
          .done(function (res) {
            self.paginaAtual = res[0];
            let jogadas = [];
            for (let x = 0; x < res[1].length; xi++) {
              self.usuarios.buscarPorId(res[1][x].UsuarioRefId)
                .done(function (res) {
                  nomes.push(res.Nome);
                });
            }
            let jogadasLeaderboard = [];
            for (let i = 0; i < res[1].length; i++) {
              jogadasLeaderboard[i] = {
                pontuacao: (self.paginaAtual * res[1].length) - res[1].length + i,
                nome: nomes[i],
                pontuacao: res[1].Pontos,
                dificuldade: res[1].Dificuldade
              };
            }
            $('#Leaderboard').show();
            jogoDaForca.render('#jogadas', 'leaderboard', jogadasLeaderboard);
          });
  }

  renderizarEstadoInicial() {
    $('section.tela-centralizada').removeClass('tela-centralizada');
    this.pegarPalavras();
  }

  renderizarPalavra(palavra) {
    $('#palavra').text(this.palavras.esconderAPalavra(palavra));
  }

  pegarPalavras() {
    let self = this;
    let usuario = window.sessionStorage.getObj('usuario');
    let jogada = window.sessionStorage.getObj('jogada');
    console.log(usuario);
    let palavras = window.localStorage.getObj(usuario.Nome+jogada.Dificuldade);
    if (palavras == null) {
      switch (jogada.Dificuldade) {
        case 'normal':
          self.palavras.pegarPalavrasNivelNormal()
            .done((res) => {
              self.renderizarPalavra(res[0].Nome);
              window.localStorage.setObj(usuario.Nome+jogada.Dificuldade, res.map((p) => p.Nome));
              this.$elem.show();
            });
          break;
        case 'bh':
          self.palavras.pegarRegistrosNivelBh()
            .done((res) => {
              self.renderizarPalavra(res[0].Nome);
              window.localStorage.setObj(usuario.Nome+jogada.Dificuldade, res.map((p) => p.Nome));
              this.$elem.show();
              self.gameOverBH = setTimeout(function () {
                let jogada = window.sessionStorage.getObj('jogada');
                self.jogadas.buscarPorJogada(jogada)
                  .done(function (jogadaBuscada) {
                    if (jogadaBuscada.Pontos < jogada.Pontos) {
                      self.jogadas.adicionarPontos(jogada);
                    }
                    jogada.Pontos = 0;
                    window.sessionStorage.setItem('jogada', jogada);
                  });
                self.errouPalavra();
              }, 20000);
            });
          break;
      }
    } else {
      console.log(palavras);
      self.renderizarPalavra(palavras[0]);
      this.$elem.show();
      if(jogada.Dificuldade === 'bh'){
        self.gameOverBH = setTimeout(function () {
          let jogada = window.sessionStorage.getObj('jogada');
          jogada.Pontos = 0;
          window.sessionStorage.setObj('jogada', jogada);
          self.errouPalavra();
        }, 20000);
      }
    }
  }

  renderizarLetrasErradas(letrasErradas) {
    return jogoDaForca.render('#letras-erradas', 'letras-erradas', letrasErradas);
  }

  validarLetraFomulario() {
    this.$formPalpiteLetra = $('#form-palpite-letra');
    this.$btnSubmitLetra = this.$formPalpiteLetra.find('button[type=submit]');
    let self = this;

    this.$formPalpiteLetra.submit((e) => {
      try {
        clearTimeout(self.gameOverBH);
        self.$btnSubmitLetra.text('Palpitando...');
        self.$btnSubmitLetra.attr('disabled', true);
        let letra = self.$formPalpiteLetra.find('#letra-palpite').val();
        $('#letra-palpite').val("");
        self.palpitarLetra(letra);
        return e.preventDefault();
      }
      catch (erro) {
        console.error('ops, erro:', erro);
      }
    });

    let validator = this.$formPalpiteLetra.validate({
      highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').removeClass('has-error');
      },
      showErrors: function () {
        if (validator.numberOfInvalids() === 0) {
          self.$btnSubmitLetra.removeAttr('disabled');
        } else {
          self.$btnSubmitLetra.attr('disabled', true);
        }
        this.defaultShowErrors();
      },
      submitHandler: function () {
        return false;
      }
    });
  }

  palpitarLetra(letra) {
    let self = this;
    let usuario = window.sessionStorage.getObj('usuario');
    let jogada = window.sessionStorage.getObj('jogada');
    let palavra = window.localStorage.getObj(usuario.Nome+jogada.Dificuldade)[0];
    let palavraComUnderline = $('#palavra').text();
    if (palavra.toUpperCase().indexOf(letra.toUpperCase()) !== -1) {
      let palavraASerRenderizada = self.palavras.mostrarLetras(palavra, palavraComUnderline, letra);
      self.acertosLetras++;
      $('#pontuacao-acertos').text(self.acertosLetras);
      if (palavraASerRenderizada.indexOf("_") === -1) {
        self.$btnSubmitLetra.text('Palpitar!');
        self.$btnSubmitLetra.attr('disabled', false);
        self.renderizarPalavraComPalpite(palavraASerRenderizada);
        $('#letra-palpite').val("");
        let usuario = window.sessionStorage.getObj('usuario');
        let palavras = window.localStorage.getObj(usuario.Nome+jogada.Dificuldade);
        palavras.splice(0, 1);
        window.localStorage.setObj(usuario.Nome+jogada.Dificuldade, palavras);
        jogada = window.sessionStorage.getObj('jogada');
        jogada.Pontos++;
        window.sessionStorage.setObj('jogada', jogada);
        self.acertouPalavra();
      } else {
        self.$btnSubmitLetra.text('Palpitar!');
        self.$btnSubmitLetra.attr('disabled', false);
        self.renderizarPalavraComPalpite(palavraASerRenderizada);
        $('#letra-palpite').val("");
      }
    } else {
      self.$btnSubmitLetra.text('Palpitar!');
      self.$btnSubmitLetra.attr('disabled', false);
      self.errosLetras++;
      $('#pontuacao-erros').text(self.errosLetras);
      let dificuldade = window.sessionStorage.getObj('jogada').Dificuldade;
      switch (dificuldade) {
        case 'normal':
          if (self.errosLetras == 5) {
            let jogada = window.sessionStorage.getObj('jogada');
            self.jogadas.buscarPorJogada(jogada)
              .done(function (jogadaBuscada) {
                if (jogadaBuscada.Pontos < jogada.Pontos) {
                  self.jogadas.adicionarPontos(jogada);
                }
              });
            jogada.Pontos = 0;
            window.sessionStorage.setItem('jogada', jogada);
            self.errouPalavra();
          } else {
            var letrasErradas = $('#letras-erradas').html();
            letrasErradas += `<li>${letra}</li>`;
            $('#letras-erradas').html(letrasErradas);
          }
          break;
        case 'bh':
          if (self.errosLetras == 2) {
            let jogada = window.sessionStorage.getObj('jogada');
            self.jogadas.buscarPorJogada(jogada)
              .done(function (jogadaBuscada) {
                if (jogadaBuscada.Pontos < jogada.Pontos) {
                  self.jogadas.adicionarPontos(jogada);
                }
              });
            jogada.Pontos = 0;
            window.sessionStorage.setItem('jogada', jogada);
            self.errouPalavra();
          } else {
            var letrasErradas = $('#letras-erradas').html();
            letrasErradas += `<li>${letra}</li>`;
            $('#letras-erradas').html(letrasErradas);
          }
          break;
      }
      $('#letra-palpite').val("");
    }
  }

  acertouPalavra() {
    $('#winner').show();
    $('#div-palpite-palavra').hide();
    $('#div-palpite-letra').hide();
    $('#btn-jogar-novamente')
      .on('click', () => {
        jogoDaForca.renderizarTela('principal');
        $('#div-palpite-palavra').show();
        $('#div-palpite-letra').show();

      });
  }

  renderizarPalavraComPalpite(palavra) {
    $('#palavra').text(palavra);
  }

  validarPalavraFormulario() {
    this.$formPalpitePalavra = $('#form-palpite-palavra');
    this.$btnSubmitPalavra = this.$formPalpitePalavra.find('button[type=submit]');
    let self = this;
    let validator = this.$formPalpitePalavra.validate({
      highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').removeClass('has-error');
      },
      showErrors: function () {
        if (validator.numberOfInvalids() === 0) {
          self.$btnSubmitPalavra.removeAttr('disabled');
        } else {
          self.$btnSubmitPalavra.attr('disabled', true);
        }
        this.defaultShowErrors();
      },
      submitHandler: function () {
        let jogada = window.sessionStorage.getObj('jogada');
        if(jogada.Dificuldade === 'bh')
          clearTimeout(self.gameOverBH);
        self.$btnSubmitPalavra.text('Palpitando...');
        self.$btnSubmitPalavra.attr('disabled', true);
        let palavra = self.$formPalpitePalavra.find('#palavra-palpite').val();
        $('#palavra-palpite').val("");
        self.palpitarPalavra(palavra);
      }
    });
  }

  palpitarPalavra(palavraPalpitada) {
    let self = this;
    let jogada = window.sessionStorage.getObj('jogada');
    let usuario = window.sessionStorage.getObj('usuario');
    let palavras = window.localStorage.getObj(usuario.Nome+jogada.Dificuldade);
    let palavra = palavras[0];

    if (palavraPalpitada === palavra) {
      console.log("Funcionou!");
      let jogada = window.sessionStorage.getObj('jogada');
      jogada.Pontos++;
      window.sessionStorage.setObj('jogada', jogada);
      $('#palavra-palpite').val("");
      $('#palavra').text(palavras[0]);
      palavras.splice(0, 1);
      window.localStorage.setObj(usuario.Nome+jogada.Dificuldade, palavras);
      self.acertouPalavra();
    } else {
      self.errouPalavra();
    }
  }

  errouPalavra() {
    $('#game-over').show();
    $('#div-palpite-palavra').hide();
    $('#div-palpite-letra').hide();
    $('#btn-tentar-novamente')
      .on('click', () => {
        jogoDaForca.renderizarTela('login');
        $('#div-palpite-palavra').show();
        $('#div-palpite-letra').show();
      });
  }

  validarFiltroFormulario() {
    this.$formFiltro = $('#form-filtro-usuario');
    this.$btnSubmitFiltro = this.$formFiltro.find('button[type=submit]');
    let self = this;
    this.$formFiltro.submit((e) => {
      try {
        clearTimeout(self.gameOverBH);
        self.$btnSubmitFiltro.text('Palpitando...');
        self.$btnSubmitFiltro.attr('disabled', true);
        let filtro = self.$formFiltro.find('#filtro').val();
        self.jogadas.buscarRanking(filtro)
          .done(function (res) {
            self.paginaAtual = res[0];
            let jogadas =[];
            for (let x = 0; x < res[1].length;xi++) {
              self.usuarios.buscarPorId(res[1][x].UsuarioRefId)
                .done(function(res){
                  nomes.push(res.Nome);
                });
            }
            let jogadasLeaderboard = [];
            for (let i = 0; i < res[1].length; i++) {
              jogadasLeaderboard[i] = {
                pontuacao: (self.paginaAtual * res[1].length)- res[1].length+i,
                nome: nomes[i],
                pontuacao: res[1].Pontos,
                dificuldade: res[1].Dificuldade
              };
            }
            jogoDaForca.render('#jogadas', 'leaderboard', jogadasLeaderboard);
          });
        return e.preventDefault();
      }
      catch (erro) {
        console.error('ops, erro:', erro);
      }
    });

    let validator = this.$formFiltro.validate({
      highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').removeClass('has-error');
      },
      showErrors: function () {
        if (validator.numberOfInvalids() === 0) {
          self.$btnSubmitFiltro.removeAttr('disabled');
        } else {
          self.$btnSubmitFiltro.attr('disabled', true);
        }
        this.defaultShowErrors();
      },
      submitHandler: function () {
        return false;
      }
    });
  }
}
