using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.DTOs;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<AlunosController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);  

            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }

        // GET: api/<AlunosController>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(_repo.GetAllAlunos(false));
        }

        // GET api/<AlunosController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) { return BadRequest("O aluno não foi encontrado"); }

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDTO);
        }

        // POST api/<AlunosController>
        [HttpPost]
        public IActionResult Post(AlunoRegistraDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("O Aluno não foi cadastrado!");
        }

        // PUT api/<AlunosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistraDTO alunoDTO)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _mapper.Map(alunoDTO, aluno);
            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("O Aluno não foi alterado!");
        }

        // PATCH api/<AlunosController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistraDTO alunoDTO)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _mapper.Map(alunoDTO, aluno);
            _repo.Update(aluno);

            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));
            }

            return BadRequest("O Aluno não foi alterado!");
        }

        // DELETE api/<AlunosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges()) { return Ok("Aluno eliminado"); }

            return BadRequest("O Aluno não foi eliminado!");
        }
    }
}