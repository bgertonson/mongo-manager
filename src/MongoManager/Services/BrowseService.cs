using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoManager.Models;

namespace MongoManager.Services
{
    public class BrowseService
    {
        private readonly MongoUrl _url;

        public BrowseService(MongoUrl url)
        {
            _url = url;
        }

        public DatabaseBrowseModel BrowseDatabases()
        {
            var model = new DatabaseBrowseModel();
            var server = GetServer();

            var names = server.GetDatabaseNames();
            foreach (var name in names)
            {
                long docCount = 0;
                var db = server.GetDatabase(name);
                var cnames = db.GetCollectionNames().ToList();
                foreach (var cname in cnames)
                {
                    var c = db.GetCollection(cname);
                    docCount += c.FindAll().Count();
                }

                var item = new DatabaseItem();
                item.Name = name;
                item.CollectionCount = cnames.Count();
                item.DocumentCount = docCount;
                model.Databases.Add(item);
                
            }
            server.Disconnect();
            return model;
        }

        public CollectionBrowseModel BrowseCollections(string dbName)
        {
            var model = new CollectionBrowseModel();
            model.Context.Database = dbName;
            var db = GetDatabase(dbName);
            var collections = db.GetCollectionNames();
            foreach (var collection in collections)
            {
                var c = db.GetCollection(collection);
                var item = new CollectionItem();
                item.Name = collection;
                item.DocumentCount = c.FindAll().Count();
                model.Collections.Add(item);
            }
            return model;
        }

        public DocumentBrowseModel BrowseDocuments(string dbname, string collection, int page = 0, int pageSize = 10)
        {
            var model = new DocumentBrowseModel();
            model.Context.Database = dbname;
            model.Context.Collection = collection;
            model.PageSize = pageSize;
            model.PageNumber = page;
            
            var c = GetCollection(dbname, collection);
            model.TotalItems = c.FindAll().Count();
            model.PageCount = model.TotalItems/pageSize;
            model.Documents =
                c.FindAll().Skip(pageSize*page).Take(pageSize).Select(d => new DocumentItem {Json = d.ToJson()}).ToList();
            return model;
        }

        private MongoServer GetServer()
        {
            return MongoServer.Create(_url);
        }

        private MongoDatabase GetDatabase(string name)
        {
            var server = GetServer();
            var db = server.GetDatabase(name);
            return db;
        }

        private MongoCollection<BsonDocument> GetCollection(string dbName, string collection)
        {
            var db = GetDatabase(dbName);
            return db.GetCollection(collection);
        }
    }
}