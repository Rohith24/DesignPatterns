using System;
using System.Collections.Generic;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseConnection databaseConnection1 = DatabaseConnection.DatabaseConnectionInstance;
            DatabaseConnection databaseConnection2 = DatabaseConnection.DatabaseConnectionInstance;

            if (databaseConnection1 == databaseConnection2)
            {
                Console.WriteLine("Yes");
            }


            
            Console.WriteLine("Hello World!");
        }
    }

    class DatabaseConnection : IDisposable
    {
        public string connectionstring { get; set; }

        private static DatabaseConnection databaseConnection;
        private static readonly object lockObject = new object();
        public static DatabaseConnection DatabaseConnectionInstance
        {
            get
            {
                lock (lockObject)
                {
                    if (databaseConnection == null)
                        databaseConnection = new DatabaseConnection();
                }
                return databaseConnection;
            }
        }
        private DatabaseConnection()
        {
            connectionstring = "Defaut";
        }

        public void Dispose()
        {
            databaseConnection = null;
        }
    }

    
}
