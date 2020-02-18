using AutoMapper;
using Meetup.Api.Entities;
using Meetup.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Profiles
{
    public class InscripcionProfile : Profile
    {
        public InscripcionProfile()
        {
            CreateMap<Inscripcion, InscripcionDto>();
            CreateMap<Inscripcion, InscripcionNuevaDto>();
            CreateMap<InscripcionNuevaDto, Inscripcion>();
        }

    }
}
