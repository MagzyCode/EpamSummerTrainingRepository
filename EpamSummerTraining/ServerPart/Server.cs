using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FourthTask.ServerPart
{
    public class Server
    {
        private TcpClient _client;

        private event Action<string> NotifyEvent;

        public Server(IPEndPoint address)
        {
            TcpListener = new TcpListener(address);
            NotifyEvent += ServerMessages.Add;   
        }

        public MessageStore ServerMessages { get; private set; } = new MessageStore();

        public TcpListener TcpListener { get; private set; }

        public void Start() => TcpListener.Start();

        public void Stop() => TcpListener.Stop();

        public void Processing()
        {
            _client = TcpListener.AcceptTcpClient();
            var bytes = new byte[256];
            var stream = _client.GetStream();
            var count = stream.Read(bytes, 0, bytes.Length);

            if (count != 0)
            {
                var clientMessage = Encoding.UTF8.GetString(bytes);
                NotifyEvent?.Invoke(clientMessage);
                var response = Encoding.UTF8.GetBytes(clientMessage);
                stream.Write(response, 0, response.Length);
            }
        }

        public void AddSubscriber(Action<string> subscriber) => NotifyEvent += subscriber;

        public void DeleteSubscriber(Action<string> subscriber) => NotifyEvent -= subscriber;


    }
}
