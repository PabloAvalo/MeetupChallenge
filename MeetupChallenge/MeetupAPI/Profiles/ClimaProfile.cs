﻿using AutoMapper;
using Meetup.Api.Entities;
using Meetup.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Profiles
{
    public class ClimaProfile : Profile
    {
        public ClimaProfile()
        {
            CreateMap<ClimaEvento, ClimaDto>();
            CreateMap<ClimaDto, ClimaEvento>();

        }
    }
}
