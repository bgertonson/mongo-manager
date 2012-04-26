using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoManager.Models
{
    public class DatabaseBrowseModel: BrowseModel
    {
        public DatabaseBrowseModel()
        {
            Databases = new List<DatabaseItem>();
        }

        public IList<DatabaseItem> Databases { get; set; } 
    }

    public class DatabaseItem
    {
        public string Name { get; set; }
        public int CollectionCount { get; set; }
        public long DocumentCount { get; set; }
    }
}