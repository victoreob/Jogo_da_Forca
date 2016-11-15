class Usuarios {
  
  cadastrar(usuario) {
    return $.post('api/Usuarios', usuario);
  }

  buscarPorNome(usuario) {
    return $.get('api/usuarios/buscarPorNome', { nome: usuario.Nome });
  }

  buscarPorId(usuario) {
    return $.get('api/usuarios/buscarPorId', usuario);
  }

  buscarRanking() {
    return $.get('api/usuarios/buscarRanking');
  }
}