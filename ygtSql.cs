using System;
using System.Data;
using System.Data.SqlClient;

namespace ygtSql
{
    abstract class SqlDatabase
    {
        #region SQL Variables

        private SqlConnection connection = null;
        private SqlDataReader reader = null;
        private SqlCommand command = null;
        private string connectionString = string.Empty;
        //private SqlDataAdapter dataAdapter = null;

        #endregion

        #region Connection String Variables

        private string dataSource = string.Empty;
        private string initialCatalog = string.Empty;
        private bool integratedSecurity = true;
        private string userId = string.Empty;
        private string password = string.Empty;

        #endregion

        #region Methods

        protected void SetConnectionString(string dataSource, string initialCatalog, bool integratedSecurity)
        {
            this.dataSource = dataSource;
            this.initialCatalog = initialCatalog;
            this.integratedSecurity = integratedSecurity;

            connectionString = $"Data Source={this.dataSource};Initial Catalog={this.initialCatalog};Integrated Security={this.integratedSecurity}";
        }

        protected void SetConnectionString(string dataSource, string initialCatalog, string userId, string password)
        {
            this.dataSource = dataSource;
            this.initialCatalog = initialCatalog;
            this.userId = userId;
            this.password = password;

            integratedSecurity = false;
            connectionString = $"Data Source={this.dataSource};Initial Catalog={this.initialCatalog};User ID={this.userId};Password={this.password}";
        }

        protected  void SetConnection()
        { 
            connection = new SqlConnection(connectionString);
        }

        protected void ExecuteSqlCommand(string sqlCommand)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                }
                command = new SqlCommand(sqlCommand, connection);
                reader = command.ExecuteReader();

                #region Data Read

                for (int i = 0; i < reader.VisibleFieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i)}");
                    if (i + 1 != reader.VisibleFieldCount)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                while (reader.Read())
                {
                    for (int i = 0; i < reader.VisibleFieldCount; i++)
                    {
                        Console.Write($"{reader[i]}");
                        if (i + 1 != reader.VisibleFieldCount)
                        {
                            Console.Write(" - ");
                        }
                    }
                    Console.WriteLine();
                }

                #endregion

                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }

    class SqlCmdl : SqlDatabase
    {
        #region Command Line Variables

        private string currentLine = string.Empty;
        private string currentDataSource = string.Empty;
        private string currentDatabase = string.Empty;
        private bool currentIntegratedSecurity;
        public bool cmdlRun = false;

        #endregion

        #region Methods

        public SqlCmdl() { cmdlRun = true; }

        private string GetCommand()
        {
            currentLine = Console.ReadLine();
            Console.Clear();
            currentLine = currentLine.Trim();
            return currentLine;
        }

        public void Commands()
        {
            if (currentDatabase != string.Empty)
            {
                Console.Write($"{currentDatabase}>>");
            }
            else
            {
                Console.Write(">>");
            }
            switch (GetCommand().ToLower())
            {
                case "crt":
                    Create();
                    break;
                case "set":
                    Set();
                    break;
                case "exe":
                    SetConnection();
                    ExecuteSqlCommand(GetCommand());
                    break;
                case "help":
                    Console.WriteLine("create :\n\tdatabase\n\ttable\nset :\n\tconnstr\n\tconn\nexecute : SQL COMMANDS\nexit : NULL\n");
                    break;
                case "exit":
                    cmdlRun = false;
                    break;
            }
        }

        private void Create()
        {
            Console.Write($"{currentDatabase}>>Create>>");
            switch (GetCommand().ToLower())
            {
                case "db":
                    CreateDatabase();
                    break;
                case "tb":
                    CreateTable();
                    break;
            }
        }
        private void CreateDatabase()
        {
            Console.Write("Database Name : ");
            ExecuteSqlCommand($"CREATE DATABASE {GetCommand()}");
        }
        private void CreateTable()
        {
            Console.Write("Table Name : ");
            ExecuteSqlCommand($"CREATE TABLE {GetCommand()} (itemId INT IDENTITY(1,1) NOT NULL PRIMARY KEY)");
        }

        private void Set()
        {
            Console.Write($"{currentDatabase}>>Set>>");
            switch (GetCommand().ToLower())
            {
                case "connstr":
                    SetConnStr();
                    break;
                case "conn":
                    SetConnection();
                    break;
            }
        }

        private void SetConnStr()
        {
            Console.Write("Data Source : ");
            currentDataSource = GetCommand();
            Console.Write("Database Name : ");
            currentDatabase = GetCommand();
            Console.Write("Integrated Security : ");
            currentIntegratedSecurity = Convert.ToBoolean(GetCommand().ToLower());

            SetConnectionString(currentDataSource, currentDatabase, currentIntegratedSecurity);
        }

        #endregion
    }
}
