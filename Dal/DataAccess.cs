using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using LocaleApi.Models;

namespace LocaleApi.Dal
{
    public class DataAccess
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand command;

        private void Connect()
        {
            // Connection string
            string connstring = "Server=localhost;Port=5432;" +
                "User Id=postgres;Password=tumenjargal;Database=vutiliti;";

            // Making connection with Npgsql provider
            conn = new NpgsqlConnection(connstring);

            try
            {
                conn.Open();
            }
            catch (Exception msg)
            {           
                throw msg;
            }
        }

        private void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public Localization[] ReadAll()
        {
            Connect();

            var list = new List<Localization>();
            string sql = "SELECT * FROM localization";
            command = new NpgsqlCommand(sql, conn);

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Localization loc = new Localization();

                    loc.Id = Convert.ToInt32(reader.GetValue(0));
                    loc.Platform = Convert.ToInt32(reader.GetValue(1));
                    loc.Key = reader.GetValue(2).ToString();
                    loc.En_us = reader.GetValue(3).ToString();
                    loc.Es_mx = reader.GetValue(4).ToString();

                    list.Add(loc);
                }
            }

            Close();

            return list.ToArray();
        }
    }
}
