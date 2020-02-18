using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public interface INotificacionRepository
    {
        void AddNotificacion(Notificacion notificacion);

        //IEnumerable<Notificacion> GetNotificacionsByUser(int userId);

        bool Save();

                     

    }
}
