class Usuarios {

  cadastrar(usuario) {
    return $.post('api/Usuarios', usuario);
  }

  resetarPontos(usuario) {
    return $.put('api/usuarios/resetarPontos', usuario);
  }

  adicionarPontos(usuario) {
    // incrementando pontuação.
    usuario.Pontuacao++;
    return $.ajax({
      url: 'api/usuarios/adicionarPontos',
      type: 'PUT',
      data: usuario
    });
  }

  buscarPorNomeENivel(usuario) {
    return $.get('api/usuarios/buscarPorNomeENivel', { nome: usuario.nome, nivel: usuario.dificuldade });
  }

  buscarPorId(usuario) {
    return $.get('api/usuarios/buscarPorId', usuario);
  }
  buscarRanking() {
    return $.get('api/usuarios/buscarRanking');
  }
}