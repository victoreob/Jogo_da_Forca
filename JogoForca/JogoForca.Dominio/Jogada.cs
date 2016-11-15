using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio
{
    public class Jogada
    {

        public int Id { get; set; }
        public string Dificuldade { get; set; }
        public int Pontos { get; set; }
        public int UsuarioRefId { get; set; }
        [ForeignKey("UsuarioRefId")]
        public virtual Usuario Usuario { get; set; }

    }

}
