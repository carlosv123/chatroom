﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client : Inotify
    {
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public Client(NetworkStream Stream, TcpClient Client)
        {
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message)
        {
            byte[] message = Encoding.ASCII.GetBytes(Message);
            stream.Write(message, 0, message.Count());
        }
        public string Recieve()
        {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            string recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
            Console.WriteLine(recievedMessageString);
            return recievedMessageString;
        }
        public string Send()
        {
            byte[] sendmessage = new byte[256];
            stream.Read(sendmessage, 0, sendmessage.Length);
            string sendmessagestring = Encoding.ASCII.GetString(sendmessage);
            Console.WriteLine(sendmessagestring);
            return sendmessagestring;

            
        }
        public void notify()
        {
            Console.WriteLine("User has been notify");
            
        }
    }
}
