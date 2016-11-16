class Jogadas {

  cadastrar(jogada) {
    return $.post('api/Jogadas', jogada);
  }

  resetarPontos(jogada) {
    //resetando pontuacao
    jogada.Pontos = 0;
    return $.ajax({
      url: 'api/jogadas/alterarPontos',
      type: 'PUT',
      data: jogada
    });
  }

  adicionarPontos(jogada) {
    return $.ajax({
      url: 'api/jogadas/alterarPontos',
      type: 'PUT',
      data: jogada
    });
  }

  buscarPorJogada(jogada) {
    return $.get('api/Jogadas', { idUsuario: jogada.UsuarioRefId, dificuldade: jogada.Dificuldade });
  }

  buscarRanking(pagina) {
    return $.get('api/jogadas/ranking', { pagina: pagina });
  }
}