using WebApiComputadoras.DTOs;
using WebApiComputadoras.Entitys;
using AutoMapper;

namespace WebApiComputadoras.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ComputadorasDTO, Computadoras>();
            CreateMap<Computadoras, GetComputadorasDTO>();
        }
    }
}
