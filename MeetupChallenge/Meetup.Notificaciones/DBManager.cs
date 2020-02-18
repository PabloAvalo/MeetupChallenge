using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Meetup.Notificaciones
{
    public class DBManager
    {


        private SqlConnection conn;

        public SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    conn = new SqlConnection(Config.ConnectionString);
                    conn.Close();
                    conn.Open();
                }
                else
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Close();
                        conn.Open();
                    }
                }


                return conn;
            }
            set { conn = value; }
        }





    }
}
