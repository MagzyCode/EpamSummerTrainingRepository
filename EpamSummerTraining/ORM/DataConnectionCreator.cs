using System;
using System.Collections.Generic;
using System.Text;

namespace EpamSummerTraining.ORM
{
    public class DataConnectionCreator
    {
        private static DataConnectionCreator _instance;
        private string _connectionString;


        private DataConnectionCreator()
        { }

        public static DataConnectionCreator GetConnection()
        {
            _instance ??= new DataConnectionCreator();
            return _instance;
        }
    }
}
