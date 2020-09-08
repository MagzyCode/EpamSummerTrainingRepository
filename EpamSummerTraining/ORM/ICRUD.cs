using System.Collections.Generic;

namespace EpamSummerTraining.ORM
{
    public interface ICrud
    {
        void Create();
        void Read();
        void Update();
        void Delete();
    }
}
