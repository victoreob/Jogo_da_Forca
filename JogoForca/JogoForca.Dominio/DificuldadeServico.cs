using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio
{
    public class DificuldadeServico
    {

        private IDificuldadeRepositorio dificuldadeRepositorio;

        public DificuldadeServico(IDificuldadeRepositorio dificuldadeRepositorio)
        {
            this.dificuldadeRepositorio = dificuldadeRepositorio;
        }

        public string NomeDaDificuldade(int id)
        {
            return dificuldadeRepositorio.NomeDaDificuldade(id);
        }

    }
}
