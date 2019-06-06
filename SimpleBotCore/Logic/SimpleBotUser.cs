using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("15net");
            var col = db.GetCollection<BsonDocument>("col01");

            var doc = new BsonDocument() {
                { "user", message.User },
                {"mensagem", message.Text }
            };

            col.InsertOne(doc);

            return $"{message.User} disse '{message.Text}'";
        }

    }
}