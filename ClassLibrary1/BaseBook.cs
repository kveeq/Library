using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ClassLibrary1
{
    public class BaseBook
    {
        private static string uri = "mongodb+srv://kveeq:2554781@cluster0.lfe3e.mongodb.net/Base?retryWrites=true&w=majority";
        private static MongoClient client = new MongoClient(uri); // чтобы подключится к серверу надо передать в качестве аргумента {uri}


        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Autor { get; set; }
        [BsonElement]
        public string Izdatelstvo { get; set; }
        [BsonElement]
        public string Year { get; set; }

        public BaseBook(string name, string autor, string izdatelstvo, string year)
        {
            Name = name;
            Autor = autor;
            Izdatelstvo = izdatelstvo;
            Year = year;
        }

        public static async void Add(BaseBook basa)
        {
            try
            {
                var db = client.GetDatabase("Library");
                var collection = db.GetCollection<BaseBook>("books");
                await collection.InsertOneAsync(basa);
            }
            catch (Exception ex)
            {
                string a = ($"Не удалось добавить в базу \n {ex.Message}");
            }
        }

        public static List<BaseBook> TakeList()
        {
            var db = client.GetDatabase("Library");
            var collection = db.GetCollection<BaseBook>("books");
            return collection.Find(x => true).ToList();
        }
    }
}
