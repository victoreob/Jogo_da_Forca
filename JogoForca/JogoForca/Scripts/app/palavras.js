class Palavras {

  pegarRegistrosNivelNormal() {
    return $.get('/api/palavras', {
      palavras: palavras
    });
  }

  pegarRegistrosNivelBh() {
    return $.get('/api/palavras/bh', {
      palavras: palavras
    });
  }

  cadastrar(palavra) {
    return $.post('/api/palavras', palavra);
  }

}