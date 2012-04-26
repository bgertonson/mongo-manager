using System;

namespace MongoManager.Models
{
    public class ConnectionModel
    {
        public string Server { get; set; }
        public int? Port { get; set; }
        public string Message { get; set; }

        public bool HasMessage()
        {
            return !String.IsNullOrEmpty(Message);
        }
    }
}