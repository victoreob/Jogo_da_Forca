class TelaLogin {

  constructor(seletor) {
    this.$elem = $(seletor);
    this.usuarios = new Usuarios();
    this.jogadas = new Jogadas();
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
        let $nomeUsuario = $('#usuario').val();
        let $dificuldade = $('input[type="radio"][name="dificuldade"]:checked', this.$formLogin).val();
        self.verificarUsuarioExistente($nomeUsuario, $dificuldade);
        self.$btnSubmit.text('Carregando...');
        self.$btnSubmit.attr('disabled', true);
      }
    });
  }

  verificarUsuarioExistente(nomeUsuario, dificuldade) {
    let usuarioASerSalvo = {
      Nome: nomeUsuario,
      Pontuacao: 0
    };
    let self = this;
    this.usuarios.buscarPorNome(usuarioASerSalvo)
      .done(function (usuarioRespostaBusca) {
        console.log('usuario resposta busca', usuarioRespostaBusca)
        if (usuarioRespostaBusca.Id === 0) {
          self.usuarios.cadastrar(usuarioASerSalvo)
            .done(function (usuarioRespostaCadastro) {
              console.log('usuario resposta cadastro', usuarioRespostaCadastro);
              self.salvarUsuarioNaSessao(usuarioRespostaCadastro);
              self.verificarJogadaExistente(usuarioRespostaCadastro.Id, dificuldade);
            });
        } else {
          self.salvarUsuarioNaSessao(usuarioRespostaBusca);
          self.verificarJogadaExistente(usuarioRespostaBusca.Id, dificuldade);
        }
      });
  }

  salvarUsuarioNaSessao(usuario) {
    console.log('usuario salvo na sessao', usuario);
    window.sessionStorage.setObj('usuario', usuario);
  }

  verificarJogadaExistente(idUsuario, dificuldade) {
    let self = this;
    let jogadaASerSalva = {
      Dificuldade: dificuldade,
      Pontos: 0,
      UsuarioRefId: idUsuario
    }
    self.jogadas.buscarPorJogada(jogadaASerSalva)
      .done(function (jogadaRespostaBusca) {
        console.log('jogada resposta busca', jogadaRespostaBusca);
        if (jogadaRespostaBusca.Id === 0) {
          self.jogadas.cadastrar(jogadaASerSalva)
            .done(function (jogadaRespostaCadastro) {
              console.log('jogada resposta cadastro', jogadaRespostaCadastro);
              self.salvarJogadaNaSessao(jogadaRespostaCadastro);
              self.renderizarTelaPrincipalComDelay();
            });
        } else {
          self.salvarJogadaNaSessao(jogadaRespostaBusca);
          self.renderizarTelaPrincipalComDelay();
        }
      });
  }

  salvarJogadaNaSessao(jogada) {
    console.log('jogada salvo na sessao', jogada);
    window.sessionStorage.setObj('jogada', jogada);
  }

  renderizarTelaPrincipalComDelay() {
    setTimeout(function () {
      jogoDaForca.renderizarTela('principal');
    }, 2000);
  }
}