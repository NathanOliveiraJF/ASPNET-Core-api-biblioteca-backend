using System.Collections.Generic;
using Biblioteca.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    
    [Route("api/obras")]
    public class ObraController : ControllerBase
    {
        private readonly BibliotecaDbContext _dbContext;
        public ObraController(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult RetornaObras()
        {
            var obras = new List<Obra>()
            {
                new Obra 
                {
                    Titulo = "Homem Aranha", 
                    Editora = "Marvel Comics", 
                    Foto = "https://musicart.xboxlive.com/7/7bbf5000-0000-0000-0000-000000000002/504/image.jpg?w=1920&h=1080",
                    Autores = new List<string> 
                    { 
                        "Zendaya", "Marisa", "Tomei", "Laura Harrier", "Jacob Batalon" 
                    }
                },

            };

            return Ok(obras);
        }
    }    
}