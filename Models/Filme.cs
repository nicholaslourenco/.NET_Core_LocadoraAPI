using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace LocadoraAPI.Models
{
    public class Filme
    {
        [Key()]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        public string? CaminhoImagem { get; set; }
        public byte[]? Imagem { get; set; }
    }
}