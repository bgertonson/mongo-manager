using System.Collections.Generic;

namespace MongoManager.Models
{
    public class CollectionBrowseModel: BrowseModel
    {
        public CollectionBrowseModel()
        {
            Collections = new List<CollectionItem>();
        }

        public IList<CollectionItem> Collections { get; set; } 
    }

    public class CollectionItem
    {
        public string Name { get; set; }
        public long DocumentCount { get; set; }
    }
}