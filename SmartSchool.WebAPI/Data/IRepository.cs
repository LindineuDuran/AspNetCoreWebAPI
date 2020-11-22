using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

         // Alunos
         Aluno[] GetAllAlunos(bool includeDisciplina = false);
         Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false);
         Aluno GetAlunoById(int alunoId, bool includeDisciplina = false);

         // Professores
         Professor[] GetAllProfessores(bool includeDisciplina = false);
         Professor[] GetProfessoresByDisciplinaId(int disciplinaId, bool includeDisciplina = false);
         Professor GetProfessorById(int professorId, bool includeDisciplina = false);
    }
}