using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Meetup.Notificaciones
{
    public static class NotificacionHandler
    {

        public static void Insert(string titulo, string mensaje, int usuarioId, int eventoId, DBManager db)
        {

            SqlCommand command = new SqlCommand($"INSERT INTO Notificacion VALUES ('{titulo}','{mensaje}',0,'{usuarioId}','{eventoId}')", db.Conn);

            command.ExecuteNonQuery();

        }

        public static List<NotificacionView> GetNotificacionesAEnviar(DBManager db)
        {

            string query = "SELECT i.UsuarioId, i.EventoId FROM Inscripcion i INNER JOIN Evento e on i.EventoId = e.Id " +
                            $"WHERE e.Fecha > '{DateTime.Now}' ";

            SqlCommand command = new SqlCommand(query, db.Conn);
            command.CommandType = CommandType.Text;

            SqlDataAdapter ad = new SqlDataAdapter(command);

            DataSet ds = new DataSet();

            ad.Fill(ds);

            List<NotificacionView> notificaciones = new List<NotificacionView>();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                notificaciones.Add(new NotificacionView()
                {

                    EventoId = (int)item["EventoId"],
                    UsuarioId = (int)item["UsuarioId"]

                });
            }


            return notificaciones;


        }

    }
}
