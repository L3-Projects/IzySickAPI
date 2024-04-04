using AutoMapper;
using izySick.Models;
using IzySickAPI.Dto;

namespace IzySickAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Docteur, DocteurDto>();
            //CreateMap<DocteurDto, Docteur>(); // when POST
        }
    }
}
