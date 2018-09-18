using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TCTest.Mongo
{
    public class MongoTest
    {
        public static void Run()
        {
            //string connectionString =
            //@"mongodb://***/?ssl=true&replicaSet=globaldb";

            string connectionString = ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;

            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            var db = mongoClient.GetDatabase("familiesdb");
            var collection = db.GetCollection<BsonDocument>("families");

            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }}
            };

            collection.InsertOne(document);
        }
    }

    // The following is from https://blog.oz-code.com/how-to-mongodb-in-c-part-1/
    /*
     * {
         _id:1,
         name:"John smith"
         company_name:"Bloggy-dev",
         knowledge_base:[
           {
             langu_name:"C#",
             technology:"WPF",
             rating:"9"
           },
           {
             langu_name:"C#",
             technology:"TPL",
             rating:"7"
           },
           {
             langu_name:"C++",
             technology:"QT",
             rating:"8"
           }
         ]
        }
     */
    public class Developer
    {
        [BsonId]
        public ObjectId ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("company_name")]
        public string CompanyName { get; set; }

        [BsonElement("knowledge_base")]
        public List<Knowledge> KnowledgeBase { get; set; }
    }

    public class Knowledge
    {
        [BsonElement("langu_name")]
        public string Language { get; set; }

        [BsonElement("technology")]
        public string Technology { get; set; }

        [BsonElement("rating")]
        public ushort Rating { get; set; }
    }
}
