using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Meetup.Notificaciones
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DBManager db = new DBManager();


            //notificaciones a los inscriptos ..
            var notificaciones = NotificacionHandler.GetNotificacionesAEnviar(db);

            //podria agregar otras notificaciones, cada una con su template... x ej por los topicos de preferencia de los user

            foreach (var item in notificaciones)
            {

                NotificacionHandler.Insert("TemplateTitulo", "TemplateMensaje", item.UsuarioId, item.EventoId, db);

            }


        }
    }
}
