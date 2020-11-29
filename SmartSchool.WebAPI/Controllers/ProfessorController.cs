using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<ProfessorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetAllProfessores(true);  

            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professor));
        }

        // GET: api/<ProfessorsController>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(_repo.GetAllProfessores(false));
        }

        // GET api/<ProfessorsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) { return BadRequest("O professor não foi encontrado"); }

            var professorDTO = _mapper.Map<ProfessorDTO>(professor);

            return Ok(professorDTO);
        }

        // POST api/<ProfessoresController>
        [HttpPost]
        public IActionResult Post(ProfessorRegistraDTO professorDTO)
        {
            var professor = _mapper.Map<Professor>(professorDTO);

            _repo.Add(professor);            
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{professorDTO.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("O Professor não foi cadastrado!");
        }

        // PUT api/<ProfessoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistraDTO professorDTO)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _mapper.Map(professorDTO, professor);
            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{professorDTO.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("O Professor não foi alterado!");
        }

        // PATCH api/<ProfessoresController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistraDTO professorDTO)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _mapper.Map(professorDTO, professor);
            _repo.Update(professor);

            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{professorDTO.Id}", _mapper.Map<ProfessorDTO>(professor));
            }

            return BadRequest("O Professor não foi alterado!");
        }

        // DELETE api/<ProfessoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges()) { return Ok("O Professor foi eliminado"); }

            return BadRequest("O Professor não foi alterado!");
        }
    }
}