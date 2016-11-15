using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorNome(string nome);
        Usuario BuscarPorId(int id);
        void Criar(Usuario usuario);
    }
}
