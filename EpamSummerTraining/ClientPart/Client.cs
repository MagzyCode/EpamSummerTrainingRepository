using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FourthTask.ClientPart
{
    public class Client
    {

        private event Action<string> NotifyEvent;

        public NetworkStream ClientConnectionStream { get; private set; }

        public TcpClient TcpClient { get; private set; } = new TcpClient();

        public Client(IPEndPoint endPoint)
        {
            TcpClient.Connect(endPoint);
            ClientConnectionStream = TcpClient.GetStream();
        }

        public Client(TcpListener listener)
        {
            TcpClient = listener.AcceptTcpClient();
            ClientConnectionStream = TcpClient.GetStream();
        }
        
        public string GetResponse()
        {
            var data = new byte[256];
            int bytes = ClientConnectionStream.Read(data, 0, data.Length);
            string message = Encoding.UTF8.GetString(data, 0, bytes);
            // преобразование строки в новый язык
            NotifyEvent?.Invoke(message);
            return message;
        }

        public void SentRequest(string request)
        {
            var data = Encoding.UTF8.GetBytes(request);
            ClientConnectionStream.Write(data, 0, data.Length);
        }

        public void Close() => TcpClient.Close();

        public void AddSubscriber(Action<string> message) => NotifyEvent += message;

        public void DeleteSubscriber(Action<string> message) => NotifyEvent -= message;
    }
}
