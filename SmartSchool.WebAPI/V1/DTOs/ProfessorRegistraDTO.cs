using System;

namespace SmartSchool.WebAPI.V1.DTOs
{
    public class ProfessorRegistraDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataIni { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Ativo { get; set; } = true;
    }
}