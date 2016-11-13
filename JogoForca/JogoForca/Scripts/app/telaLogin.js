class TelaLogin {

  constructor(seletor) {
    this.$elem = $(seletor);
    this.usuarios = new Usuarios();
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
  }
  registrarBindsEventos() {
    this.$formLogin = $('#formLogin');
    this.$btnSubmit = this.$formLogin.find('button[type=submit]');
    let self = this;
    let validator = this.$formLogin.validate({
      highlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').addClass('has-error');
      },
      unhighlight: function (element, errorClass, validClass) {
        $(element).closest('.form-group').removeClass('has-error');
      },
      showErrors: function () {
        if (validator.numberOfInvalids() === 0) {
          self.$btnSubmit.removeAttr('disabled');
        } else {
          self.$btnSubmit.attr('disabled', true);
        }
        this.defaultShowErrors();
      },
      submitHandler: function () {
        self.$btnSubmit.text('Carregando...');
        self.$btnSubmit.attr('disabled', true);
        let usuario = $('#usuario').val();
        let dificuldade = $('#dificuldade').val();
        self.salvarUsuarioNaSessao(usuario, dificuldade).bind(self);
        setTimeout(function () {
          jogoDaForca.renderizarTela('principal');
        }, 2000);
      }
    });
  }

  

  salvarUsuarioNaSessao(usuario, dificuldade) {
    let usuarioASerSalvo = {
      nome: usuario,
      pontuacao: 0,
      dificuldade: dificuldade
    };
    this.usuarios.cadastrar(usuario).done((res) => {
      console.log('res', res);
      //window.sessionStorage.setItem('usuario', res);
    });
  }

  renderizarEstadoInicial() {
    this.$elem.show();
    this.$btnSubmit.attr('disabled', !this.$formLogin.valid());
  }

}