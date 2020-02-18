using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public interface IUsuarioRepository
    {

        Usuario ObtenerUsuario(string user, string contraseña);

        Usuario ObtenerUsuario(int usuarioId);


        void AddUsuario(Usuario usuario);

        bool Save();
        bool Exists(string correo);

        bool Exists(string correo, string contraseña);
        IEnumerable<Usuario> ObtenerUsuarios();
        IEnumerable<Notificacion> ObtenerNotificaciones(int id);
       
    }
}
