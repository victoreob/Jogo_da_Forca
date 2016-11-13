class Palavras {

  pegarPalavrasNivelNormal() {
    return $.get('/api/palavras/normal');
  }

  pegarRegistrosNivelBh() {
    return $.get('/api/palavras/bh');
  }

}