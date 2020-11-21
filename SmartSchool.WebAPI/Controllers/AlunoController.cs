using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){Id = 1, Nome = "Marcos", Sobrenome = "Almeida", Telefone = "12345678"},
            new Aluno(){Id = 2, Nome = "Marta", Sobrenome = "Kent", Telefone = "87654321"},
            new Aluno(){Id = 3, Nome = "Lucas", Sobrenome = "Ribeiro", Telefone = "12348765"},
            new Aluno(){Id = 4, Nome = "Laura", Sobrenome = "Cintra", Telefone = "43215678"}
        };

        public AlunoController() {}

        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            
            if(aluno == null) {return BadRequest("O aluno não foi encontrado");}

            return Ok(aluno);
        }

        // GET api/<AlunosController>/ByName?nome&sobrenome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // POST api/<AlunosController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            git commit -m "first commit"
        }

        // PATCH api/<AlunosController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}