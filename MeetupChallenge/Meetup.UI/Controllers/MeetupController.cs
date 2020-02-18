using BussinesLogic.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.UI.Controllers
{
    public class MeetupController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMeetupController _controller;

        public MeetupController(ILogger<HomeController> logger, IMeetupController controller)
        {
            _logger = logger;
            _controller = controller;

        }

        public IActionResult Index() {

            return View();
        }
    }
}
