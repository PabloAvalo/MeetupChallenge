using AutoMapper;
using Meetup.Api.Services;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionRepository inscripcionRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IEventoRepository eventoRepository;

        private readonly IMapper mapper;
        public InscripcionController(IInscripcionRepository repoIns, IUsuarioRepository  repoUsu, IEventoRepository repoEvento ,IMapper mapper)
        {
            inscripcionRepository = repoIns;
            usuarioRepository = repoUsu;
            eventoRepository = repoEvento;

            this.mapper = mapper;
        }

        /// <summary>
        /// Genera una nueva inscripcion de un usuario a una Meeting
        /// 
        /// </summary>
        /// <param name="inscripcion"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(InscripcionNuevaDto inscripcion) {

            if (usuarioRepository.ObtenerUsuario(inscripcion.UsuarioId) == null)
            {
                return NotFound("Usuario inexistente");
            }

            if (!eventoRepository.Exists(inscripcion.EventoId)) {
                return NotFound("Evento inexistente");
            }

            if (inscripcionRepository.Exists( inscripcion.UsuarioId, inscripcion.EventoId )){

                return BadRequest("El usuario ya se encuentra inscripto");
            }

            var entity = mapper.Map<Entities.Inscripcion>(inscripcion);

            inscripcionRepository.AddInscripcion(entity);

            inscripcionRepository.Save();

            var response = mapper.Map<InscripcionDto>(entity);

            return Ok(new { Id = entity.Id, Inscripcion = response });
        
        }


        /// <summary>
        /// Confirma asistencia de usuario a una meeting
        /// </summary>
        /// <param name="inscripcionId"> id de la inscripcion</param>
        /// <returns></returns>

        [HttpPut("{inscripcionId}/Checkin")]
        public IActionResult CheckIn(int inscripcionId) {

            var inscripcion = inscripcionRepository.GetInscripcion(inscripcionId);

            if (inscripcion == null) {

                return NotFound();
                
            }

            if(inscripcion.Evento.Fecha > DateTime.Now)
            {

                return BadRequest("La meeting a la que intenta hacer checkin no se ha realizado");

            }

            inscripcion.CheckIn = true;
            //inscripcionRepository.Checkin(inscripcionId);
            inscripcionRepository.Save();

            return NoContent();
            
        }
        

    }
}
