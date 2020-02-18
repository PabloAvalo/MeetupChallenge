using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.Dto.Models;
using Meetup.Api.Entities;

namespace Meetup.Api.Profiles
{
    public class NotificacionProfile : Profile

    {
        public NotificacionProfile()
        {
            CreateMap<Notificacion, NotificacionDto>();
        }
    }
}
