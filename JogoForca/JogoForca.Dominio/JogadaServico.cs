using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio
{
    public class JogadaServico
    {

        private IJogadaRepositorio jogadaRepositorio;

        public JogadaServico(IJogadaRepositorio jogadaRepositorio)
        {
            this.jogadaRepositorio = jogadaRepositorio;
        }

        public Jogada BuscarJogada(Jogada jogada)
        {
            return jogadaRepositorio.BuscarJogada(jogada);
        }

        public void AlterarPontos(Jogada jogada)
        {
            jogadaRepositorio.AlterarPontos(jogada);
        }

        public void Criar(Jogada jogada)
        {
            jogadaRepositorio.Criar(jogada);
        }

        public IEnumerable<Jogada> CriarRanqueamento(int pagina, int tamanhoPagina)
        {
            return jogadaRepositorio.Ranking(pagina, tamanhoPagina);
        }

        public int ContarRegistros()
        {
            return jogadaRepositorio.ContarRegristros();
        }

    }
}
