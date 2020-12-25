using System;
using System.Collections.Generic;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.DTOs
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataIni { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}