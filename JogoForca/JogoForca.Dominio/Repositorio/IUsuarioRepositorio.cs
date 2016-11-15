﻿using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> Ranking(int pagina, int tamanhoPagina);
        Usuario BuscarPorNomeENivel(string nome, string nivel);
        Usuario BuscarPorId(int id);
        void Criar(Usuario usuario);
        void AdicionarPontos(Usuario usuario);
        void ResetarPontos(Usuario usuario);
        int ContarRegristros();
    }
}
