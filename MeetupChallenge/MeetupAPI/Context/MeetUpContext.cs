using Meetup.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Api.Context
{
    public class MeetUpContext : DbContext
    {


        //Configure options connection string
        public MeetUpContext(DbContextOptions<MeetUpContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Notificacion> Notificacions { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Configuracion> Configuracions { get; set; }



        //invites
    }
}
