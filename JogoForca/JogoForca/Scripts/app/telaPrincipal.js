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
    let palavras = window.localStorage.getItem(usuario.Nome);
    if (palavras == null) {
      switch (usuario.Dificuldade){
        case 'normal':
          self.palavras.pegarPalavrasNivelNormal()
            .done((res) => {
              console.log(res);
              self.palavra = res[0];
              self.renderizarPalavra(self.palavra);
              window.localStorage.setItem(usuario, res);
              this.$elem.show();
            });
          break;
        case 'bh':
          self.palavras.pegarRegistrosNivelBh()
            .done((res) => {
              console.log(res);
              self.palavra = res[0];
              self.renderizarPalavra(self.palavra);
              window.localStorage.setItem(usuario, res);
              this.$elem.show();
            });
          break;
      }
    } else {
      self.palavra = palavras[0];
      self.renderizarPalavra(self.palavra);
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
        self.$btnSubmitLetra.text('Palpitando...');
        self.$btnSubmitLetra.attr('disabled', true);
        let letra = $('#letra-palpite').val();
        self.palpitarLetra(letra).bind(self);
      }
    });
  }

  palpitarLetra(letra) {
    let palavra = this.palavra.Nome;
    if (palavra.indexOf(letra) !== -1) {
      let palavraASerRenderizada = this.palavras.mostrarLetras(palavra, letra);
      if (palavraASerRenderizada.indexOf("_") === -1) {
        let usuario = window.sessionStorage.getObj('usuario');
        this.usuarios.adicionarPontos(usuario)
          .done(function (res) {
            window.sessionStorage.setObj('usuario', res);
            this.renderizarPalavraComPalpite(palavraASerRenderizada);
            $('#winner').show();
          });
      } else {
        this.renderizarPalavraComPalpite(palavraASerRenderizada);
      }
    } else 
      console.log('nao tem a letra');
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
        self.palpitarPalavra(palavra).bind(self);
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
}
