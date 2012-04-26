using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoManager.Models;

namespace MongoManager.Services
{
    public class ConnectionService
    {
        public ApiResponse SetConnection(ConnectionModel model)
        {
            var builder = new MongoUrlBuilder();
            var server = new MongoServerAddress(model.Server, model.Port ?? 27017);
            builder.Server = server;

            var url = builder.ToMongoUrl();

            try
            {
                var conn = MongoServer.Create(url);
                conn.Connect();
                conn.Disconnect();
            }
            catch
            {
                return new ApiResponse(false, string.Format("Connection to {0} failed.", url));
            }
            
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("Mongo.Manager.Connection", url.ToString()));
            return new ApiResponse();
        }

        public MongoUrl GetConnection()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("Mongo.Manager.Connection");
            if (cookie == null || String.IsNullOrWhiteSpace(cookie.Value))
                return null;

            var url = MongoUrl.Create(cookie.Value);
            return url;
        }
    }
}