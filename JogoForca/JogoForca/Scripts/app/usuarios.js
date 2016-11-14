class Usuarios {

  cadastrar(usuario) {
    return $.post('api/Usuarios', usuario);
  }

  resetarPontos(usuario) {
    return $.put('api/usuarios/resetarPontos', usuario);
  }

  adicionarPontos(usuario) {
    return $.put('api/usuarios/adicionarPontos', usuario);
  }

  buscarPorNomeENivel(usuario) {
    return $.get('api/usuarios/busarPorNomeENivel', { nome: usuario.nome, nivel: usuario.dificuldade });
  }

  buscarPorId(usuario) {
    return $.get('api/usuarios/buscarPorId', usuario);
  }
  buscarRanking() {
    return $.get('api/usuarios/buscarRanking');
  }
}