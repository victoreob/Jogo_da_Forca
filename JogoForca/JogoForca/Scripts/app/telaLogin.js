class TelaLogin {

  constructor(seletor) {
    this.$elem = $(seletor);
    this.usuarios = new Usuarios();
    this.registrarBindsEventos();
    this.renderizarEstadoInicial();
  }

  renderizarEstadoInicial() {
    this.$elem.show();
    this.$btnSubmit.attr('disabled', !this.$formLogin.valid());
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
        let $usuario = $('#usuario').val();
        let $dificuldade = $('input[type="radio"][name="dificuldade"]:checked', this.$formLogin).val();
        self.salvarUsuarioNaSessao($usuario, $dificuldade);
        self.$btnSubmit.text('Carregando...');
        self.$btnSubmit.attr('disabled', true);
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
    let self = this;
    this.usuarios.buscarPorNome(usuarioASerSalvo)
      .done(function (res) {
        if (res.Id === 0) {
          self.usuarios.cadastrar(usuarioASerSalvo)
            .done(function (res) {
              console.log('res', res);
              window.sessionStorage.setItem('usuario', res);
          });
        } else {
          console.log('res', res);
          window.sessionStorage.setItem('usuario', res);
        }
      });

  }

  

}