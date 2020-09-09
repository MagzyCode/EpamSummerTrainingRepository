using System.Collections.Generic;

namespace EpamSummerTraining.ORM
{
    public interface ICrud<T> where T : class
    {
        void Create();
        T Read();
        void Update();
        void Delete();
    }
}
