using BussinesLogic.Controllers;
using Meetup.Dto.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Meetup.BussinessLogic.Test
{
    public class MeetupController_Should
    {

        private IMeetupController controller = new MeetupController();

        [Fact]
        public async Task MeetupController_ShouldCreateMeetup()
        {

            string ciudad = "Rosario";
            string descripcion = "descriptivo";
            DateTime date = DateTime.Today;
            string nombre = "nombre";
            string sucursal = "Santander Rosario";
            int organizador = 1;


            EventoDto evento = await controller.CrearMeetUpAsync(
                new EventoNuevoDto()
                {

                    Ciudad = ciudad,
                    Descripcion = descripcion,
                    Fecha = date,
                    Nombre = nombre,
                    OrganizadorId = organizador,
                    Sucursal = sucursal,
                    TopicoId = 1

                }
                );


            Assert.NotNull(evento);
            Assert.True(evento.Id > 0);

        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(-1, 1)]
        [InlineData(int.MaxValue, int.MaxValue)]


        public async Task MeetupController_ShouldntCreateMeetup(int topicoId, int organizadorId)
        {

            string ciudad = "Rosario";
            string descripcion = "descriptivo";
            DateTime date = DateTime.Today;
            string nombre = "nombre";
            string sucursal = "Santander Rosario";



            EventoDto evento = await controller.CrearMeetUpAsync(
                new EventoNuevoDto()
                {

                    Ciudad = ciudad,
                    Descripcion = descripcion,
                    Fecha = date,
                    Nombre = nombre,
                    OrganizadorId = organizadorId,
                    Sucursal = sucursal,
                    TopicoId = topicoId

                }
                );


            Assert.Null(evento);



        }

        public async Task MeetupController_ShouldUpdateMeetup(int id)
        {



        }


        [Fact]
        public async Task MeetupController_ShouldGetWeatherForMeetup()
        {

            var evento = await controller.ObtenerMeetup(5);


            var clima = await controller.ObtenerClimarDeEvento(5);

            if (evento.Fecha >= DateTime.Today)
            {
                Assert.NotNull(clima);
            }

            else
            {

                Assert.Null(clima);
            }

        }

        [Fact]
        public async Task MeetupController_ShouldGetAmountOfBeers()
        {
            var evento = await controller.ObtenerMeetup(4);

            var clima = await controller.ObtenerCantidadDeBirras(4);

            if (evento.Fecha > DateTime.Now)
            {
                Assert.NotNull(clima);
            }

            else
            {

                Assert.Null(clima);
            }
        }

        public async Task MeetupController_ShouldGetNextMeetups()
        {
        }

        public async Task MeetupController_ShouldGetUserMeetups()
        {

        }

        public async Task MeetupController_ShouldGetOrganizadorMeetups()
        {


        }









    }
}
