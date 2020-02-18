using Meetup.Api.Context;
using Meetup.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Api.Services
{
    public class EventoRepository : IEventoRepository
    {
        private readonly MeetUpContext _context;

        public EventoRepository(MeetUpContext context)
        {
            _context = context;
        }

        public bool AddEvento(Evento evento)
        {
            if (_context.Topicos.Where(t => t.Id == evento.TopicoId).Count() == 0)
                return false;

            if (_context.Usuarios.Where(u => u.Id == evento.OrganizadorId) .Count () == 0)

                return false;

            _context.Eventos.Add(evento);
            return true;

        }

        public bool Exists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }

        public Evento GetEventoById(int id)
        {
            return GetFullEvento().Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos.Include(e => e.Topico).ToList();
        }

        public IEnumerable<Evento> GetEventos(DateTime date)
        {
            return _context.Eventos.Include(e => e.Topico).Where(e => e.Fecha.Date == date.Date);
        }



        public IEnumerable<Evento> GetEventosByOrganizerId(int organizadorId)
        {
            return _context.Eventos.Include(e => e.Topico).Where(e => e.OrganizadorId == organizadorId).ToList();
        }

        public object GetEventosByUserId(int userId)
        {
            List<int> eventoIds = _context.Inscripciones.Where(i => i.UsuarioId == userId)
                                                        .Select(e => e.EventoId).ToList();

            return _context.Eventos.Where(e => eventoIds.Contains(e.Id)).ToList();

        }

        public IEnumerable<Evento> GetProximosEventos()
        {
            return _context.Eventos.Include(e => e.Topico).
                                    Where(e => e.Fecha > DateTime.Now).ToList();
        }

        public void Remove(int id)
        {
            _context.Eventos.Remove(_context.Eventos.Find(id));
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateEvento(Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;

            //deberia modificar clases relacionadas
        }

        private IQueryable<Evento> GetFullEvento()
        {

            var full = _context.Eventos.Include(e => e.Topico)
                                   .Include(e => e.Inscriptos);

            return full;

        }


    }
}
