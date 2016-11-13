class TelaPrincipal {
  
  constructor(seletor) {
    this.$elem = $(seletor);
    this.renderizarEstadoInicial();
  }

  registrarBindsEventos(self) {
    self.$btnLetra = $('#btn-letra');
    self.$btnPagina = $('#btn-pagina');
    self.$btnLetra.on('click', self.palpitarLetra($('#letra')).bind(self));
    self.$btnPagina.on('click', self.palpitarPalavras($('#Palavras')).bind(self));
  }

  carregarERenderizarLetrasErradas() {
    return localStorage.getItem()(pagina, this.qtdHeroisPorPagina)
      .done(function (res) {
        this.qtdTotalRegistros = res.total;
        this.renderizarLetrasErradas(res.dados).then(() => {
          this.registrarBindsEventos(this);
        })
      }.bind(this));
  }

  renderizarLetrasErradas(letrasErradas) {
    return jogoDaForca.render('.tela', 'tela-principal', letrasErradas);
  }

  renderizarEstadoInicial() {
    $('section.tela-centralizada').removeClass('tela-centralizada');
    this.$elem.show();
  }
}
