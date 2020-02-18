using AutoMapper;
using Meetup.Api.Context;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicosController : ControllerBase
    {

        private MeetUpContext _context;
        private readonly IMapper _mapper;
        public TopicosController(MeetUpContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene los posibles topicos de las meetings
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult GetTopicos() {

            var topicos = _context.Topicos.ToList();

            return Ok(_mapper.Map<IEnumerable<TopicoDto>>(topicos));
            
        }

        [HttpPost]

        public IActionResult Post(string nombre) {

            Entities.Topico topico = new Entities.Topico() { Nombre = nombre };
            
            _context.Topicos.Add(topico);

            _context.SaveChanges();

            return Ok(new { Id = topico.Id, topico = topico });


        }

    }
}
