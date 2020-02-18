using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meetup.Api.Services;
using Meetup.Dto.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Meetup.Api.ClimaHelper;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepo;



        private readonly IMapper _mapper;

        public EventosController(IEventoRepository repository, IMapper mapper)
        {
            _eventoRepo = repository;

            _mapper = mapper;
        }


        /// <summary>
        /// Lista todos los eventos creados
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult GetEventos()
        {

            var eventos = _eventoRepo.GetEventos().ToList();

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }

        /// <summary>
        /// Lista los eventos que fueron creados por el usuario organizador del evento
        /// </summary>
        /// <param name="organizadorId"> Id  del organizador</param>
        /// <returns></returns>            

        [HttpGet("organizador/{organizadorId}")]
        public IActionResult GetEventosByOrganizadorId(int organizadorId)
        {

            var eventos = _eventoRepo.GetEventosByOrganizerId(organizadorId);

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }

        /// <summary>
        /// Lista los eventos en que se encuentra inscripto el usuario
        /// </summary>
        /// <param name="userId"> id del usuario </param>
        /// <returns></returns>

        [HttpGet("usuario/{userId}")]
        public IActionResult GetEventosByUser(int userId)
        {

            var eventos = _eventoRepo.GetEventosByUserId(userId);

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }


        /// <summary>
        /// Obtiene una Meeting a traves  de su id
        /// </summary>
        /// <param name="id"> id del evento</param>
        /// <returns></returns>
        [HttpGet("{id}", Name ="GetEvento")]
        
        public IActionResult GetEvento(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (!_eventoRepo.Exists(id))
            {
                return NotFound();
            }

            var evento = _eventoRepo.GetEventoById(id);



            return Ok(_mapper.Map<EventoDto>(evento));

        }

        /// <summary>
        /// Crea un evento nuevo
        /// </summary>
        /// <param name="evento"> Tiene todos los datos pertenecientes al evento nuevo</param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult PostEvento(EventoNuevoDto evento)
        {
            
            var entity = _mapper.Map<Entities.Evento>(evento);

            entity.FechaActualizacion = DateTime.Now;

            bool ok = _eventoRepo.AddEvento(entity);

            if(!ok)
            {
                return BadRequest("No se pudo agregar el evento. usuario o topico no existentes");

            }
            _eventoRepo.Save();

            EventoDto response = _mapper.Map<EventoDto>(entity);

            return Ok(
                new { Id = entity.Id, response }
                );

        }

        /// <summary>
        /// Se obtiene los packs de birra que se necesitan para el evento 
        /// </summary>
        /// <param name="eventoId"> id del evento buscado </param>
        /// <returns></returns>

        [HttpGet("{eventoId}/cantidadDeBirras")]
        public IActionResult GetCantidadDeBirras(int eventoId)
        {

            var evento = _eventoRepo.GetEventoById(eventoId);

            if (evento == null) {

                return NotFound();

            }

            if (evento.Inscriptos.Count == 0)
            {
                return Ok("No hay inscriptos en la meetup");
            }

            double? temp = ClimaHelper.ClimaHelper.GetTemperaturaDelEvento(evento.Ciudad, evento.Fecha)?.Result;

            if (temp == double.MinValue) {

                return NotFound("No se encontraron datos del clima para el evento");

            }


            int packsBirra = ProvicionesHelper.CantidadDeBirras(evento.Inscriptos.Count, temp.Value);


            return Ok(new
            {
                EventoId = eventoId,
                CantidadBirras = packsBirra * 6,
                CantidadPersonas = evento.Inscriptos.Count,
                Mensaje = $"Necesitamos comprar {packsBirra} packs de Birra"

            });

        }

        /// <summary>
        /// Elimina un evento
        /// </summary>
        /// <param name="eventoId"></param>
        /// <returns></returns>
        [HttpDelete("eventoId")]

        public IActionResult Delete(int eventoId)
        {

            if (!_eventoRepo.Exists(eventoId))
            {
                return NotFound();
            }

            //remove de inscripciones ??

            _eventoRepo.Remove(eventoId);

            _eventoRepo.Save();

            return Ok(new { Mensaje = $"Se elimino el evento con id : {eventoId} " });

        }

        /// <summary>
        /// Modifica los datos del evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventoDto"> datos completos del evento modificado </param>
        /// <returns></returns>

        [HttpPut("id")]

        public IActionResult Put(int id, EventoPutDto eventoDto)
        {

            if (!_eventoRepo.Exists(id))
            {
                return BadRequest();
            }


            var eventoModificado = _mapper.Map<Entities.Evento>(eventoDto);
            eventoModificado.Id = id;
            eventoModificado.FechaActualizacion = DateTime.Now;

            _eventoRepo.UpdateEvento(eventoModificado);

            _eventoRepo.Save();

            return Ok();

        }

        /// <summary>
        /// Obtiene el clima para unaa meeting 
        /// </summary>
        /// <param name="eventoId"> Id del evento buscado</param>
        /// <returns></returns>

        [HttpGet("eventoid/Clima")]
        public async Task<IActionResult> GetClima(int eventoId)
        {

            if (!_eventoRepo.Exists(eventoId))
            {
                return NotFound();
            }

            var evento = _eventoRepo.GetEventoById(eventoId);
            ClimaDto dto = await ClimaHelper.ClimaHelper.GetClimaPorFecha(evento.Ciudad, evento.Fecha);

            if (dto == null)
            {
                return NotFound($"No se encontro el clima para la fecha {evento.Fecha}");
            }

            return Ok(dto);

        }

        [HttpGet]
        [Route("Proximos")]
        public IActionResult GetProximosEventos() {

            var eventos =  _eventoRepo.GetProximosEventos();
           

            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventos));

        }


    }
}