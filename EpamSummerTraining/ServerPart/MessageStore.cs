using System;
using System.Collections.Generic;
using System.Text;

namespace FourthTask.ServerPart
{
    public class MessageStore
    {

        public List<string> ServerMassages { get; private set; } = new List<string>();

        public void Add(string message)
        {
            var massageTimeMark = DateTime.Now;
            var newServerMassage = $"{massageTimeMark}:{message}";
            ServerMassages.Add(newServerMassage);
        }

        public override string ToString()
        {
            var result = string.Join('\n', ServerMassages);
            return result;
        }


    }
}
