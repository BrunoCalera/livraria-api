using AutoMapper;
using livraria_api.Dtos;
using livraria_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace livraria_api.Controllers
{
    public class LivroController(IMapper mapper) : LivrariaApiController(mapper)
    {
        public static List<Livro> LivroList { get; set; } = new List<Livro>();

        [HttpPost]
        [ProducesResponseType(typeof(LivroCreateDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateLivro([FromBody] LivroCreateDto livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var livroModel = _mapper.Map<Livro>(livro);
            LivroList.Add(livroModel);
            return CreatedAtAction(nameof(GetLivroById), new { id = livroModel.Id }, livroModel);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(LivroCreateDto), StatusCodes.Status200OK)]
        public IActionResult GetLivroById(Guid id)
        {
            var livro = LivroList.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();
            return Ok(livro);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LivroCreateDto>), StatusCodes.Status200OK)]
        public IActionResult GetAllLivros()
        {
            return Ok(LivroList);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(LivroUpdateDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateLivro(Guid id, [FromBody] LivroUpdateDto livroUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var livro = LivroList.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            _mapper.Map(livroUpdateDto, livro);
            return Ok(livro);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteLivro(Guid id)
        {
            var livro = LivroList.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            LivroList.Remove(livro);
            return NoContent();
        }
    }
}
