namespace MongoManager.Models
{
    public class MongoManagerView
    {
        public string Server { get; set; }
        public string Port { get; set; }

        public string Database { get; set; }
        public string Collection { get; set; }
        public string DocumentId { get; set; }
    }
}