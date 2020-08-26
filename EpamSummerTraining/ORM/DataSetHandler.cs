using System;
using System.Collections.Generic;
using System.Text;

namespace EpamSummerTraining.ORM
{
    public class DataSetHandler<T> : ICRUD
        where T : class, IDbMember
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
