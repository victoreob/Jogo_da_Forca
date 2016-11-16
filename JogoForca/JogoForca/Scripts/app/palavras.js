class Palavras {

  pegarPalavrasNivelNormal() {
    return $.get('/api/palavras/normal');
  }

  pegarRegistrosNivelBh() {
    return $.get('/api/palavras/bh');
  }

  esconderAPalavra(palavra) {
    let tam = palavra.length - 1;
    var palavraEscondida = "_";
    for (let i = 0; i < tam; i++) {
      palavraEscondida += " _";
    }
    return palavraEscondida;
  }

  mostrarLetras(palavra, palavraComUnderline, letra) {
    let tam = palavra.length;
    let arrayDeLetras = palavraComUnderline.split(" ");
    for (let i = 0; i < arrayDeLetras.length; i++) {
      if (palavra[i].toUpperCase() === letra.toUpperCase() && arrayDeLetras[i] === "_")
        if(i == 0)
          arrayDeLetras[i] = letra.toUpperCase();
        else
          arrayDeLetras[i] = letra.toLowerCase();
    }
    let palavraResultado = arrayDeLetras[0];
    for (let i = 1; i < arrayDeLetras.length; i++) {
      palavraResultado += " " + arrayDeLetras[i];
    }
    return palavraResultado;
  }
}