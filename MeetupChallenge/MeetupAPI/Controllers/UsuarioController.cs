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

    //Se podria agregar identity para manejar los usuario de forma mas prolija

    public class UsuarioController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioController(IUsuarioRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            usuarioRepository = repo;
        }

        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="usuarioNuevo"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("SingUp")]
        public IActionResult SingUp(UsuarioNuevoDto usuarioNuevo)
        {

            if (usuarioRepository.Exists(usuarioNuevo.Correo))
            {
                return BadRequest("Usuario ya registrado");
            }

            


            var entity = mapper.Map<Entities.Usuario>(usuarioNuevo);

            usuarioRepository.AddUsuario(entity);

            usuarioRepository.Save();

            var response = mapper.Map<UsuarioDto>(entity);

            return Ok(new { Id = response.Id, response });



        }

        /// <summary>
        /// Obtiene el usuario logueado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("login")]
        public IActionResult Login(UsuarioLoginDto usuario)
        {

            if (!usuarioRepository.Exists(usuario.Correo, usuario.Contraseña))
            {

                return BadRequest("Usuario inexistente");
            }

            var usu = usuarioRepository.ObtenerUsuario(usuario.Correo, usuario.Contraseña);

            return Ok(mapper.Map<UsuarioDto>(usu));

        }

        /// <summary>
        /// Obtiene todos los usuario que usan meetup
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok(mapper.Map<IEnumerable<UsuarioDto>>(usuarioRepository.ObtenerUsuarios()));
        }

        /// <summary>
        /// Permite agregar topicos que le interesan al usuario
        /// *Podria agregar otras configuraciones*
        /// </summary>
        /// <param name="configuracion"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("Preferencias")]
        public IActionResult AddTopicoDePreferencia(ConfiguracionNuevaDto configuracion) {

            var usuario = usuarioRepository.ObtenerUsuario(configuracion.UsuarioId);

            if (usuario == null)
            {
                return NotFound();
            }
                       
            usuario.Configuracion.Add(mapper.Map<Entities.Configuracion>(configuracion));

            usuarioRepository.Save();

            return Ok($"Se agrego la configuracion");
        
        }



        [HttpGet("{id}/Notificaciones")]
     

        public IActionResult GetNotificacionesDeUsuario(int id)
        {

            if (usuarioRepository.ObtenerUsuario(id) == null)

                return NotFound();


            var notificaciones = usuarioRepository.ObtenerNotificaciones(id);

            return Ok(mapper.Map<List<NotificacionDto>>(notificaciones));


        }




    }
}
