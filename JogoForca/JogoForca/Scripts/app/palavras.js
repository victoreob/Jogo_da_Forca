class Palavras {

  pegarPalavrasNivelNormal() {
    return $.get('/api/palavras/normal');
  }

  pegarRegistrosNivelBh() {
    return $.get('/api/palavras/bh');
  }

  esconderAPalavra(palavra) {
    let tam = palavra.length;
    var palavraEscondida = "";
    for (let i = 0; i < tam; i++){
      palavraEscondida += "_ ";
    }
    return palavraEscondida;
  }

}