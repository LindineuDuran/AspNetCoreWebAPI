using System.Collections.Generic;

namespace SmartSchool.WebAPI.V1.DTOs
{
    public class DisciplinaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public DisciplinaDTO Prerequisito { get; set; }
        public int ProfessorId { get; set; }
        public ProfessorDTO Professor { get; set; }
        public int CursoId { get; set; }
        public CursoDTO Curso { get; set; }

        public IEnumerable<AlunoDTO> Alunos { get; set; }
    }
}