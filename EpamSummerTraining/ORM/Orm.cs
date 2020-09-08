using System.Configuration;

namespace EpamSummerTraining.ORM
{
    public class Orm<T> : ICrud
        where T : class, IDbMember, new()
    {
        public void Create()
        {
            
        }

        public void Delete()
        {
            
        }

        public void Read()
        {
            
        }

        public void ReadAll()
        {

        }

        public void Update()
        {
            
        }
    }
}
