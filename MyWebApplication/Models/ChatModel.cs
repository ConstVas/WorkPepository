using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication.Models
{
    public class ChatModel
    {
        public List<ChatUser> Users { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public ChatModel()
        {
            Users = new List<ChatUser>();
            Messages = new List<ChatMessage>();
            Messages.Add(new ChatMessage()
            {
                Text = "Чат Запущен " + DateTime.Now
            });
        }
    }
    public class ChatUser
    {
        public string Name { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LastPing { get; set; }
    }
    public class ChatMessage
    {
        public ChatUser User{ get; set; }
        public DateTime Date { get; set; }
        public string Text = "";
    }
}