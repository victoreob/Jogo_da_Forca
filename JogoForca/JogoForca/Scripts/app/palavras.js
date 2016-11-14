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
    for (let i = 0; i < tam; i++) {
      palavraEscondida += "_ ";
    }
    return palavraEscondida;
  }

  mostrarLetras(palavra, palavraComUnderline, letra) {
    let tam = palavra.length;
    let arrayDeLetras = palavraComUnderline.split(" ");
    for (let i = 0; i < arrayDeLetras.length; i++) {
      if (palavra[i] === letra && arrayDeLetras[i] === "_")
        arrayDeLetras[i] = letra;
    }
    let palavraResultado = "";
    for (let i = 0; i < arrayDeLetras.length; i++) {
      palavraResultado += arrayDeLetras[i] + " ";
    }
    return palavraResultado;
  }
}