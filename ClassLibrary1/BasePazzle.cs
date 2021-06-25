using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ClassLibrary1
{
    public class BasePazzle
    {
        private static string uri = "mongodb+srv://kveeq:2554781@cluster0.lfe3e.mongodb.net/Base?retryWrites=true&w=majority";
        public static MongoClient client = new MongoClient(uri); // чтобы подключится к серверу надо передать в качестве аргумента {uri}

        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public int Count_of_elem { get; set; }
        [BsonElement]
        public string Company_name { get; set; }

        public BasePazzle(string name, int count_of_elem, string company_name)
        {
            Name = name;
            Count_of_elem = count_of_elem;
            Company_name = company_name;
        }

        public static async void Add(BasePazzle basa)
        {
            try
            {
                var db = client.GetDatabase("Library");
                var collection = db.GetCollection<BasePazzle>("pazzles");
                await collection.InsertOneAsync(basa);
            }
            catch (Exception ex)
            {
                string a = ($"Не удалось добавить в базу \n {ex.Message}");
            }
        }

        public static List<BasePazzle> TakeList()
        {
            var db = client.GetDatabase("Library");
            var collection = db.GetCollection<BasePazzle>("pazzles");
            return collection.Find(x => true).ToList();
        }
    }
}
