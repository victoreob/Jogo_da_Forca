class Palavras {

  pegarPalavrasNivelNormal() {
    return $.get('/api/palavras/normal');
  }

  pegarRegistrosNivelBh() {
    return $.get('/api/palavras/bh');
  }

  esconderAPalavra(palavra) {
    let tam = palavra.Nome.length;
    var palavraEscondida = "";
    for (let i = 0; i < tam; i++){
      palavraEscondida += "_ ";
    }
    return palavraEscondida;
  }

  mostrarLetras(palavra, letra) {
    let tam = palavra.length;
    var palavraEscondida = "";
    let letraPalavra;
    for (let i = 0; i < tam; i++) {
      if (palavra[i] == letra)
        palavraEscondida += letra + " ";
      else
        palavraEscondida += "_ ";
    }
    return palavraEscondida;
  }

}