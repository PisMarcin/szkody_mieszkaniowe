using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class DbConnection
    {
        //HOST_DATABASE: www.db4free.net
        //DATABASE_NAME = sys_ubezpieczen
        //login : io2018
        //password: ioio2018
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DbConnection()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "db4free.net";
            database = "sys_ubezpieczen";
            uid = "io2018";
            password = "ioio2018";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                               database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; oldguids=true;";

            connection = new MySqlConnection(connectionString);
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List<string>[] Select(int choice)
        {
            string query;
            if (choice ==1)
            {
                query = "SELECT * FROM clients";
            }
            else
            {
                query = "SELECT c.NAME, c.SURNAME, c.PESEL, it.NAME AS ITNAME FROM insurances i JOIN clients c ON c.ID=i.id_client JOIN insurance_types it ON it.id = i.id_insurance_type";
            }
            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                if (choice == 1)
                {
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["NAME"].ToString());
                        list[1].Add(dataReader["SURNAME"].ToString());
                        list[2].Add(dataReader["ADDRESS"].ToString());
                        list[3].Add(dataReader["PESEL"].ToString());
                    }

                }
                if (choice == 2)
                {
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["NAME"].ToString());
                        list[1].Add(dataReader["SURNAME"].ToString());
                        list[2].Add(dataReader["PESEL"].ToString());
                        list[3].Add(dataReader["ITNAME"].ToString());
                    }
                    
                }
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

    }
}

