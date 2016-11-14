using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoForca.Dominio;

namespace JogoForca.Repositorio
{
    public class DificuldadeRepositorio : IDificuldadeRepositorio
    {
        public string NomeDaDificuldade(int id)
        {
            using (var context = new ContextoDeDados())
            {
                var dificuldade =  context.Dificuldade.FirstOrDefault(d => d.Id == id);

                return dificuldade.Nome;
            }
        }
    }
}
