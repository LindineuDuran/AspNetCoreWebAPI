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
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null) { return BadRequest("O aluno não foi encontrado"); }

            return Ok(aluno);
        }

        // POST api/<AlunosController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if(_repo.SaveChanges()) {return Ok(aluno);}
            
            return BadRequest("O Aluno não foi cadastrado!");
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoById(id);
            if (al == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);
            if(_repo.SaveChanges()) {return Ok(aluno);}
            
            return BadRequest("O Aluno não foi alterado!");
        }

        // PATCH api/<AlunosController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var al = _repo.GetAlunoById(id);
            if (al == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Update(aluno);
            if(_repo.SaveChanges()) {return Ok(aluno);}
            
            return BadRequest("O Aluno não foi alterado!");
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Delete(aluno);
            if(_repo.SaveChanges()) {return Ok(aluno);}
            
            return BadRequest("O Aluno não foi alterado!");
        }
    }
}