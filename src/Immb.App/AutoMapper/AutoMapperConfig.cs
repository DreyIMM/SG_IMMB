using AutoMapper;
using Immb.App.ViewModels;
using Immb.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immb.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UnidadeReligiosa, UnidadeReligiosaViewModel>().ReverseMap();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();

            CreateMap<Membro, MembroViewModel>().ReverseMap();

        }

    }
}
