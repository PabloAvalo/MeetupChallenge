using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.APIManager;
using BussinesLogic.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MeetupUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMeetupController controller;

        public IndexModel(ILogger<IndexModel> logger , IMeetupController controller)
        {
            _logger = logger;
            this.controller = controller;
             }

        public async Task OnGetAsync()
        {
        await controller.ObtenerProximosEventos();

        }
    }
}
