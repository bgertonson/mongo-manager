using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoManager.Models
{
    public abstract class BrowseModel
    {
        protected BrowseModel()
        {
            Context = new MongoManagerContext();
        }

        public MongoManagerContext Context { get; set; }

    }
}