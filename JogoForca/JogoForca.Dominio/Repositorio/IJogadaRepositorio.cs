using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio.Repositorio
{
    public interface IJogadaRepositorio
    {
        void Criar(Jogada jogada);
        void AlterarPontos(Jogada jogada);
        Jogada BuscarJogada(Jogada jogada);
        IEnumerable<Jogada> Ranking(int pagina, int tamanhoPagina);
        int ContarRegristros();
    }
}
