using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.Controllers;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meetup.UI
{
    public class MeetupHomeModel : PageModel
    {
        private IMeetupController controller;
        public MeetupHomeModel(IMeetupController controller)
        {
            this.controller = controller;


        }


        [BindProperty]
        public IEnumerable<EventoDto> ProximosEventos { get; set; } = new List<EventoDto>();

        
        public async void OnGet()
        {
            ProximosEventos = await controller.ObtenerEventosPorUsuario(1);
        }
    }
}