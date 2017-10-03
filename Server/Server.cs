using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
     class Server 
    {

        Dictionary<string, Client> UserDictionary = new Dictionary<string, Client>();

        Queue<Message> messages = new Queue<Message>();

        IList<Inotify> users = new List<Inotify>();

        public static Client client;
        TcpListener server;

        public Server()
        {
            server = new TcpListener(IPAddress.Parse("192.168.0.122"), 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            string message = client.Recieve();
            Respond(message);
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            
        }
        private void CreateUser()
        {
            client.UserId = client.Recieve();
            Console.WriteLine("user name" + client.UserId);
            UserDictionary.Add(client.UserId, client);
 
        }  
        public void sendmessage()
        {   //have a loop send messages to all people in the chatroom. //start with enqueue to accept messages, end with dequue to send messages out, and at the end, end it with count, to check if there any messages inside the queue.
            client.Recieve();

        }
       

        private void Respond(string body)
        {
             client.Send(body);
        }
        public void Join(Inotify u)
        {
            users.Add(u);
        }
        public void unjoin(Inotify u)
        {
            users.Remove(u);
        }
        public void Notifyusers()
        {
            foreach(Inotify u in users)
            {
                u.notify();
            }
        }
    }
}
