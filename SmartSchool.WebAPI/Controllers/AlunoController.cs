using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            
            if(aluno == null) {return BadRequest("O aluno não foi encontrado");}

            return Ok(aluno);
        }

        // GET api/<AlunosController>/ByName?nome&sobrenome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // POST api/<AlunosController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);            
            if (al == null) return BadRequest("O Aluno não foi encontrado");

            // aluno.Id = al.Id;
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PATCH api/<AlunosController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);            
            if (al == null) return BadRequest("O Aluno não foi encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}