class TelaPrincipal {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    $('#game-over').hide();
    $('#winner').hide();
    this.palavras = new Palavras();
    this.usuarios = new Usuarios();
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
  }

  registrarBindsEventos() {
    this.validarLetraFomulario();
    this.validarPalavraFormulario();
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
    console.log(usuario);
    let palavras = window.localStorage.getObj(usuario.Nome);
    if (palavras == null) {
      switch (usuario.Dificuldade){
        case 'normal':
          self.palavras.pegarPalavrasNivelNormal()
            .done((res) => {
              self.renderizarPalavra(res[0]);
              window.localStorage.setObj(usuario.Nome, res.map((p) => p.Nome));
              this.$elem.show();
            });
          break;
        case 'bh':
          self.palavras.pegarRegistrosNivelBh()
            .done((res) => {
              self.renderizarPalavra(res[0]);
              window.localStorage.setObj(usuario.Nome, res.map((p) => p.Nome));
              this.$elem.show();
            });
          break;
      }
    } else {
      console.log(palavras);
      self.renderizarPalavra(palavras[0]);
      this.$elem.show();
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
    let palavra = window.localStorage.getObj(usuario.Nome)[0];
    let palavraComUnderline = $('#palavra').text();
    if (palavra.indexOf(letra) !== -1) {
      let palavraASerRenderizada = self.palavras.mostrarLetras(palavra, palavraComUnderline, letra);
      if (palavraASerRenderizada.indexOf("_") === -1) {
        let usuario = window.sessionStorage.getObj('usuario');
        self.usuarios.adicionarPontos(usuario)
          .done(function (res) {
            window.sessionStorage.setObj('usuario', res);
            self.$btnSubmitLetra.text('Palpitar!');
            self.$btnSubmitLetra.attr('disabled', false);
            self.renderizarPalavraComPalpite(palavraASerRenderizada);
            $('#letra-palpite').val("");
            let usuario = window.sessionStorage.getObj('usuario');
            let palavras = window.localStorage.getObj(usuario.Nome);
            palavras.splice(0, 1);
            window.localStorage.setObj(usuario.Nome, palavras);
            self.acertouPalavra();

          });
      } else {
        self.$btnSubmitLetra.text('Palpitar!');
        self.$btnSubmitLetra.attr('disabled', false);
        self.renderizarPalavraComPalpite(palavraASerRenderizada);
        $('#letra-palpite').val("");
      }
    } else {
      self.$btnSubmitLetra.text('Palpitar!');
      self.$btnSubmitLetra.attr('disabled', false);
      console.log('nao tem a letra');
      $('#letra-palpite').val("");
    }
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
        self.$btnSubmitPalavra.text('Palpitando...');
        self.$btnSubmitPalavra.attr('disabled', true);
        let palavra = $('#palavra-palpite').val();
        self.palpitarPalavra(palavra);
      }
    });
  }

  palpitarPalavra(palavra) {
    if (palavra === this.palavra) {
      this.renderizarPalavra(this.palavra);
      let usuario = window.sessionStorage.getItem('usuario');
      this.usuarios.adicionarPontos(usuario)
        .done(function (res) {
          $('#winner').show();
        });
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
}
