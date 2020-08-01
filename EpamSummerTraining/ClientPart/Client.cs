﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FourthTask.ClientPart.LanguageTranslator;
using FourthTask.ServerPart;

namespace FourthTask.ClientPart
{
    public class Client
    {
        private event Action<string> NotifyEvent;

        public NetworkStream ClientConnectionStream { get; private set; }

        public TcpClient TcpClient { get; private set; } = new TcpClient();

        public Language MessagesLanguage { get; set; } = Language.English;

        public Client(string ip = "127.0.0.1", int port = 1)
        {
            TcpClient.Connect(ip, port);
            ClientConnectionStream = TcpClient.GetStream();
        }

        //public Client(Server server)
        //{
        //    TcpClient = server.TcpListener.AcceptTcpClient();
        //    ClientConnectionStream = TcpClient.GetStream();
        //}
        
        public string GetResponse()
        {
            var data = new byte[256];
            int bytes = ClientConnectionStream.Read(data, 0, data.Length);
            string message = Encoding.UTF8.GetString(data, 0, bytes);
            string translitMessage = TranslitTranslater.ConvertToTranslit(message, MessagesLanguage);
            NotifyEvent?.Invoke(translitMessage);
            return translitMessage;
        }

        public void SentRequest(string request)
        {
            var data = Encoding.UTF8.GetBytes(request);
            ClientConnectionStream.Write(data, 0, data.Length);
        }

        public void Close()
        {
            TcpClient.Close();
            ClientConnectionStream.Close();
        }

        public void AddSubscriber(Action<string> message) => NotifyEvent += message;

        public void DeleteSubscriber(Action<string> message) => NotifyEvent -= message;
    }
}
