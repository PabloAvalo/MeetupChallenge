using Meetup.Api.Context;
using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly MeetUpContext _context;

        public NotificacionRepository(MeetUpContext context)
        {
            _context = context;
        }

        public void AddNotificacion(Notificacion notificacion)
        {
            _context.Notificacions.Add(notificacion);
        }

        //public IEnumerable<Notificacion> GetNotificacionsByUser(int userId)
        //{
            
        //}

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
