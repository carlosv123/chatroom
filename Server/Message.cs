﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Message
    {
        public Client sender;
        public Client recive;
        public string Body;
        public string UserId;
        public Message(Client Sender, string Body)
        {
            sender = Sender;
            this.Body = Body;
            UserId = sender?.UserId;
        }
        public Message(Client recieve, string body)
        {
            recive = Recive;
            this.Body = body;
            UserId = recieve?.UserId;

        }


    }
}
