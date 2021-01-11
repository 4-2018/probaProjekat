using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class PerformerRepository
    {
        public int InsertPerfomer(string name, string surname)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("INSERT INTO performers (name,surname) VALUES ('{0}', '{1}');", name, surname);

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        public int UpdatePerformer(Performer performer)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("UPDATE performers SET name = '{0}', surname = '{1}' WHERE id = {2};", performer.Name, performer.Surname, performer.Performer_Id);

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
        public Performer GetPerformer(string name, string surname)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("SELECT * FROM performers WHERE name = '{0}' AND surname = '{1}';", name, surname);

                MySqlDataReader reader = command.ExecuteReader();

                Performer performer = new Performer();
                while (reader.Read())
                {
                    performer.Performer_Id = reader.GetInt32(0);
                    performer.Name = reader.GetString(1);
                    performer.Surname = reader.GetString(2);
                }
                return performer;
            }
        }
    }
}
