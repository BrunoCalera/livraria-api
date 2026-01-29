using livraria_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace livraria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public static List<Livro> LivroList { get; set; }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetLivroById(Guid id)
        {
            var livro = LivroList.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();
            return Ok(livro);
        }

        [HttpGet]
        public IActionResult GetAllLivros()
        {
            return Ok(LivroList);
        }

        [HttpPost]
        public IActionResult CreateLivro([FromBody] Livro livro)
        {
            livro.Id = Guid.NewGuid();
            LivroList.Add(livro);
            return CreatedAtAction(nameof(GetLivroById), new { id = livro.Id }, livro);
        }
    }
}
