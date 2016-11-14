class TelaPrincipal {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    this.palavras = new Palavras();
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
    this.$elem.show();
  }

  renderizarPalavra(palavra) {
    $('#palavra').text(this.palavras.esconderAPalavra(palavra));
  }

  pegarPalavras() {
    let self = this;
    let usuario = window.sessionStorage.getItem('usuario');
    let palavras = window.localStorage.getItem(usuario);
    if (palavras == null) {
      switch (usuario.dificuldade){
        case 'normal':
          self.palavras.pegarPalavrasNivelNormal()
            .done((res) => {
              console.log(res);
              self.palavra = res[0];
              renderizarPalavra(self.palavra);
              window.localStorage.setItem(usuario, res);
            });
          break;
        case 'bh':
          self.palavras.pegarRegistrosNivelBh()
            .done((res) => {
              console.log(res);
              self.palavra = res[0];
              renderizarPalavra(self.palavra);
              window.localStorage.setItem(usuario, res);
            });
          break;
      }
    } else {
      self.palavra = palavras[0];
      self.renderizarPalavra(self.palavra);
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
}
