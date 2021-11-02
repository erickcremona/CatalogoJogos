using AutoMapper;
using ExemploApiCatalogoJogos.Api.ViewModels.Jogo;
using ExemploApiCatalogoJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Api.Configurations
{
    public class AutoMapperResolve : Profile
    {
        public AutoMapperResolve()
        {
            CreateMap<Jogo, JogoViewModelResponse>().ReverseMap();
            CreateMap<Jogo, JogoViewModelRequestUpdate>().ReverseMap();
            CreateMap<Jogo, JogoViewModelRequestAdd>().ReverseMap();
        }
    }
}
