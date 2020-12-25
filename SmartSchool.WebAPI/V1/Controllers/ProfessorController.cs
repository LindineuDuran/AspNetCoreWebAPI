using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.DTOs;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versão 1.0 do Controlador de Professor
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável para retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetAllProfessores(true);  

            return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professor));
        }

        /// <summary>
        /// Método responsável para retornar todos os ProfessorRegistraDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(_repo.GetAllProfessores(false));
        }

        /// <summary>
        /// Método responsável por retonar apenas um único ProfessorDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id,true);
            if (professor == null) { return BadRequest("O professor não foi encontrado"); }

            var professorDTO = _mapper.Map<ProfessorDTO>(professor);

            return Ok(professorDTO);
        }

        /// <summary>
        /// Método responsável por retonar apenas um único ProfessorDTO.
        /// </summary>
        /// <param name="alunoId"></param>
        /// <returns></returns>
        [HttpGet("byaluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var professores = _repo.GetProfessoresByAlunoId(alunoId, true);
            if (professores == null) { return BadRequest("Os professores não foram encontrados"); }

             return Ok(_mapper.Map<IEnumerable<ProfessorDTO>>(professores));
        }

        /// <summary>
        /// Método responsável por inserir um novo ProfessorRegistraDTO.
        /// </summary>
        /// <param name="professorDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por alterar apenas um determinado ProfessorRegistraDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por alterar parte de um determinado ProfessorRegistraDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por eliminar um determinado Professor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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