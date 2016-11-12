class Usuarios {

  pegarRegistros(nomeUsuario) {
    return $.get(`/api/usuarios?nomeUsuario=${nomeUsuario}`, {
      usuario: usuario
    });
  }

  cadastrar(usuarios) {
    return $.post('/api/usuarios', usuarios);
  }

}