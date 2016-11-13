class Usuarios {

  cadastrar(usuario) {
    return $.post('/api/usuarios/cadastrar', usuario);
  }

  resetarPontos(usuario) {
    return $.put('api/usuarios/resetarPontos', usuario);
  }

  adicionarPontos(usuario) {
    return $.put('api/usuarios/adicionarPontos', usuario);
  }

  buscarPorNome(usuario) {
    return $.get('/api/usuarios/buscarPorNome', usuario);
  }

  buscarPorId(usuario) {
    return $.get('api/usuarios/buscarPorId', usuario);
  }
  buscarRanking() {
    return $.get('api/usuarios/buscarRanking');
  }
}