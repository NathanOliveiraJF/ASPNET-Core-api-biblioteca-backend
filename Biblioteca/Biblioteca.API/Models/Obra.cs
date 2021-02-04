using System;
using System.Collections.Generic;
namespace Biblioteca.Api.Models
{
    public class Obra
    {
        public int ObraId { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Foto { get; set; }
        public ICollection<Ator> Atores { get; set; }
    }
}