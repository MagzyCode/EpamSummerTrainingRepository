using System;
using System.Collections.Generic;
using System.Text;

namespace FourthTask.ServerPart
{
    public class MessageStore
    {
        private readonly List<(DateTime time, string message)> _messages = new List<(DateTime, string)>();

        public void Add(string message)
        {
            _messages.Add((DateTime.Now, message));
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var item in _messages)
            {
                result.Append($"{item.time} - {item.message}");
            }
            return result.ToString();
        }


    }
}
