using Meetup.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> GetEventos();

        IEnumerable<Evento> GetProximosEventos();
        IEnumerable<Evento> GetEventos(DateTime date);
        IEnumerable<Evento> GetEventosByOrganizerId(int organizadorId);
        Evento GetEventoById(int id);
        bool AddEvento(Evento evento);
        void UpdateEvento(Evento evento);
        bool Save();

        void Remove(int id);
        bool Exists(int id);
        object GetEventosByUserId(int userId);
    }
}
