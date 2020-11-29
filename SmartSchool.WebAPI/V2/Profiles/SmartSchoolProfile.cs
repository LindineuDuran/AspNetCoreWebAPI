using AutoMapper;
using SmartSchool.WebAPI.V2.DTOs;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V2.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            // Aluno
            CreateMap<Aluno, AlunoDTO>()
                     .ForMember(
                         dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                     )
                     .ForMember(
                         dest => dest.Idade,
                         opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                     );

            CreateMap<AlunoDTO, Aluno>();
            CreateMap<Aluno, AlunoRegistraDTO>().ReverseMap();
        }
    }
}