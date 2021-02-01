using System.Collections.Generic;
using Biblioteca.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            var obras = _dbContext
                        .Obras
                        .Include(e => e.Autores)
                        .ToArray();

            var res = from x in obras
                     from y in x.Autores
                     select new
                     {
                         Titulo = x.Titulo,
                         Editora = x.Editora,
                         Foto = x.Foto,
                         Autores = new { Nome = y.Nome }
                     };

            return Ok(res);
        }

        [HttpPost]
        public IActionResult InserirObra([FromBody] Obra obra)
        {

            foreach (var item in obra.Autores)
                _dbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;

            _dbContext.Entry(obra).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}