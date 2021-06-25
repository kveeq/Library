using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace GamesCollectionsLibrary
{
    public class BaseGame
    {
        private static string uri = "mongodb+srv://kveeq:2554781@cluster0.lfe3e.mongodb.net/Base?retryWrites=true&w=majority";
        private static MongoClient client = new MongoClient(uri); // чтобы подключится к серверу надо передать в качестве аргумента {uri}


        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Developer { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public int Count_of_players { get; set; }

        public BaseGame(string name, string developer, string description, int count_of_players)
        {
            Name = name;
            Developer = developer;
            Description = description;
            Count_of_players = count_of_players;
        }

        public static async void Add(BaseGame basa)
        {
            try
            {
                var db = client.GetDatabase("Library");
                var collection = db.GetCollection<BaseGame>("games");
                await collection.InsertOneAsync(basa);
            }
            catch (Exception ex)
            {
                string a = ($"Не удалось добавить в базу \n {ex.Message}");
            }
        }

        public static List<BaseGame> TakeList()
        {
            var db = client.GetDatabase("Library");
            var collection = db.GetCollection<BaseGame>("games");
            return collection.Find(x => true).ToList();
        }
    }
}
