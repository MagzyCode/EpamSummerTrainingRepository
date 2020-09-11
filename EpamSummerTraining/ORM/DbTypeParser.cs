using System;
using System.Collections.Generic;
using System.Text;

namespace EpamSummerTraining.ORM
{
    public static class DbTypeParser
    {
        public static Dictionary<Type, string> DbTypeDictionary { get; private set; }
            = new Dictionary<Type, string>()
            {
                [typeof(int)] = "int",
                [typeof(string)] = "NVARCHAR(50)",
                [typeof(DateTime)] = "datetime",
                [typeof(long)] = "bigint",
                [typeof(decimal)] = "decimal",
                [typeof(double)] = "float"
            };
    }
}
