using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FourthTask.ClientPart
{
    public class Client
    {
        private readonly TcpClient _tcpClient;

        private event Action<string> Message;

        public Client()
        { }

        public Client(IPAddress address, int port = 9999)
        {
            _tcpClient.Connect(address, port);

        }

        public Client(TcpListener listener)
        {
            _tcpClient = listener.AcceptTcpClient();
        }

        public NetworkStream GetConnectionStream()
        {
            var result = _tcpClient.GetStream();
            return result;
        }
        
        public void GetResponse()
        {
            NetworkStream stream = GetConnectionStream();
            var data = new byte[256];
            int bytes = stream.Read(data, 0, data.Length);
            string message = Encoding.UTF8.GetString(data, 0, bytes);
            Message?.Invoke(message);
        }

        public void SentRequest(string request)
        {
            var stream = GetConnectionStream();
            var data = Encoding.UTF8.GetBytes(request);
            stream.Write(data, 0, data.Length);
        }

        public void AddMessage(Action<string> message) => Message += message;

        public void DeleteMessage(Action<string> message) => Message -= message;
    }
}
