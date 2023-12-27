using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocadoraAPI.Models
{
    public class Locacao
    {
        [Key()]
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public string NomeUsuario { get; set; }
        public string Telefone { get; set; }

        [ForeignKey("Filme")]
        public int FilmeId { get; set; }
        public virtual Filme? Filme { get; set; }
    }
}