using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meetup.Api.Entities;
using Meetup.Dto.Models;

namespace Meetup.Api.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioNuevoDto>();
            CreateMap<UsuarioNuevoDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
