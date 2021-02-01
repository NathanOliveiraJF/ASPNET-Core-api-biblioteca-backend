using System;
using System.Collections.Generic;
namespace Biblioteca.Api.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Foto { get; set; }
        public IList<string> Autores { get; set; }
    }
}