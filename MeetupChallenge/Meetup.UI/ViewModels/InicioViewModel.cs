using Meetup.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.UI.ViewModels
{
    public class InicioViewModel
    {


        List<TopicoDto> Topicos { get; set; } = new List<TopicoDto>();

        List<EventoDto> ProximosEvento { get; set; } = new List<EventoDto>();

        List<EventoDto> MisEventos { get; set; } = new List<EventoDto>();


    }
}
