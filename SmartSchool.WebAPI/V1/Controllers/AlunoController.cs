using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.DTOs;
using SmartSchool.WebAPI.Models;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versão 1.0 do Controlador de Alunos
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

    /// <summary>
    /// Método responsável para retornar todos os alunos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
    {
        var alunos = await _repo.GetAllAlunosAsync(pageParams, true);  

        var alunosResult = _mapper.Map<IEnumerable<AlunoDTO>>(alunos);

        Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

        return Ok(alunosResult);
    }

        /// <summary>
        /// Método responsável para retornar todos os AlunoRegistraDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(_repo.GetAllAlunos(false));
        }

        /// <summary>
        /// Método responsável por retonar apenas um único AlunoDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) { return BadRequest("O aluno não foi encontrado"); }

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return Ok(alunoDTO);
        }

        /// <summary>
        /// Método responsável por inserir um novo AlunoRegistraDTO.
        /// </summary>
        /// <param name="alunoDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por alterar apenas um determinado AlunoRegistraDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alunoDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por alterar parte de um determinado AlunoRegistraDTO.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alunoDTO"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por eliminar um determinado Aluno.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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