using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class AdminRepository
    {
        private List<Admin> list = new List<Admin>();
        public int RegisterAdmin(Admin admin)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("INSERT INTO admins(name, surname, username, password) VALUES ('{0}','{1}','{2}',md5('{3}'));", admin.Name, admin.Surname, admin.Username, admin.Password);

                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        //Checking if Admin Username already exists in database
        public List<Admin> GetAdmin(Admin admin)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();
                List<Admin> list2 = new List<Admin>();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM admins;";

                MySqlDataReader reader = command.ExecuteReader();
                Admin temp = new Admin();
                while (reader.Read())
                {
                    temp.Admin_Id = Convert.ToInt32(reader.GetString(0));
                    temp.Name = reader.GetString(1);
                    temp.Surname = reader.GetString(2);
                    temp.Username = reader.GetString(3);
                    temp.Password = reader.GetString(4);
                    list2.Add(temp);
                }

                return list2;
              
            }
        }

        public Admin AuthenticateAdmin(Admin admin)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                Admin temp = new Admin();
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("SELECT * FROM admins WHERE username = '{0}' AND password = md5('{1}');", admin.Username, admin.Password);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    temp.Admin_Id = reader.GetInt32(0);
                    temp.Name = reader.GetString(1);
                    temp.Surname = reader.GetString(2);
                    temp.Username = reader.GetString(3);
                    temp.Password = reader.GetString(4);
                }
                return temp;
            }
        }

        public int UpdateAdmin(Admin admin)
        {
            using (MySqlConnection connection = new MySqlConnection(Constants.connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = string.Format("UPDATE admins SET name = '{0}', surname='{1}', username='{2}', password=md5('{3}') WHERE id = {4};",admin.Name, admin.Surname, admin.Username, admin.Password, admin.Admin_Id);

                int result = command.ExecuteNonQuery();
                return result;
            }
        }
    }
}
