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
                        .Include(e => e.Atores)
                        .ToArray();

            return Ok(obras);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaPorId(int id)
        {
            var obra = _dbContext.Obras.Where(e => e.ObraId == id).Include(e => e.Atores).FirstOrDefault();

            if(obra == null)
                return BadRequest();

            return Ok(obra);
        }

        [HttpPost]
        public IActionResult InserirObra([FromBody] Obra obra)
        {
            _dbContext.Add(obra);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaObra(int id, [FromBody] Obra obra)
        {

            var obraContext = _dbContext.Obras.Where(x => x.ObraId == id);
            
            if (obraContext == null)
                return BadRequest();
            
            _dbContext.Entry(obra).Property(e => e.ObraId).IsModified = false;
            _dbContext.Entry(obra).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            foreach (var item in obra.Atores)
            {
                _dbContext.Entry(item).Property(i => i.AtorId).IsModified = false;
                _dbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
           

            _dbContext.SaveChanges();
            return NoContent();
        }

         [HttpDelete("{id}")]
         public IActionResult DeletarObra(int id)
         {
             var obraContext = _dbContext.Obras.Where(x => x.ObraId == id).FirstOrDefault();

             if(obraContext == null)
                return BadRequest();


            _dbContext.Entry(obraContext).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.SaveChanges();
             return NoContent();
         }
    }
}