using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/<ProfessorsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // GET api/<ProfessorsController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            
            if(professor == null) {return BadRequest("O professor não foi encontrado");}

            return Ok(professor);
        }

        // GET api/<ProfessorsController>/ByName?nome&sobrenome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));

            if (professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        // POST api/<ProfessorsController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // PUT api/<ProfessorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var al = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);            
            if (al == null) return BadRequest("O Professor não foi encontrado");

            // professor.Id = al.Id;
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // PATCH api/<ProfessorsController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var al = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);            
            if (al == null) return BadRequest("O Professor não foi encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        // DELETE api/<ProfessorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}