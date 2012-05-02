using System.Collections.Generic;

namespace MongoManager.Models
{
    public class DocumentBrowseModel: BrowseModel
    {
        public long TotalItems { get; set; }
        public int PageSize { get; set; }
        public long PageNumber { get; set; }
        public long PageCount { get; set; }
        public List<DocumentItem> Documents { get; set; }

        public DocumentBrowseModel()
        {
            Documents = new List<DocumentItem>();
        }
    }

    public class DocumentItem
    {
        public string Json { get; set; }
    }
}