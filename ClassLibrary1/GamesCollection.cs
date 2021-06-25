using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ClassLibrary1
{
    public class Collection
    {
        private static string uri = "mongodb+srv://kveeq:2554781@cluster0.lfe3e.mongodb.net/Base?retryWrites=true&w=majority";
        private static MongoClient client = new MongoClient(uri); // чтобы подключится к серверу надо передать в качестве аргумента {uri}
        protected static IMongoDatabase db = client.GetDatabase("Library");
        protected string name;

        public Collection(string name)
        {
            this.name = name;
        }

        public virtual void Add()
        {
           
        }

        public virtual void Reduct(string id)
        {
           
        }

        public virtual void Delete(string id)
        {
            
        }
    }

    public class Book : Collection
    {
        private static IMongoCollection<BaseBook> data = db.GetCollection<BaseBook>("books");

        private string autor;
        private string illustrator;
        private string izdatelstvo;
        private string year;

        public Book(string name, string autor, string izdatelstvo, string year) : base(name)
        {
            this.autor = autor;
            this.izdatelstvo = izdatelstvo;
            this.year = year;
        }

        public override void Add()
        {
            BaseBook.Add(new BaseBook(name, autor, izdatelstvo, year));
        }

        public override void Reduct(string id)
        {
            var UpdateDef = Builders<BaseBook>.Update.Set("Name", name).Set("Autor", autor).Set("Izdatelstvo", izdatelstvo).Set("Year", year);
            data.UpdateOne(basa => basa._id == ObjectId.Parse(id), UpdateDef);
        }

        public override void Delete(string id)
        {
            data.DeleteOne(basa => basa._id == ObjectId.Parse(id));
        }
    }

    public class Pazzle : Collection
    {
        private static IMongoCollection<BasePazzle> data = db.GetCollection<BasePazzle>("pazzles");

        private int count_of_elem;
        private string company_name;

        public Pazzle(string name, int count_of_elem, string company_name) : base(name)
        {
            this.count_of_elem = count_of_elem;
            this.company_name = company_name;
        }

        public override void Add()
        {
            BasePazzle.Add(new BasePazzle(name, count_of_elem, company_name));
        }

        public override void Reduct(string id)
        {
            var UpdateDef = Builders<BasePazzle>.Update.Set("Name", name).Set("Count_of_elem", count_of_elem).Set("Company_name", company_name);
            data.UpdateOne(basa => basa._id == ObjectId.Parse(id), UpdateDef);
        }

        public override void Delete(string id)
        {
            data.DeleteOne(basa => basa._id == ObjectId.Parse(id));
        }
    }

    public class Game : Collection
    {
        private static IMongoCollection<BaseGame> data = db.GetCollection<BaseGame>("games");

        private string developer;
        private string description;
        private int count_of_players;

        public Game(string name, string developer, string description, int count_of_players) : base(name)
        {
            this.developer = developer;
            this.description = description;
            this.count_of_players = count_of_players;
        }

        public override void Add()
        {
            BaseGame.Add(new BaseGame(name, developer, description, count_of_players));
        }

        public override void Reduct(string id)
        {
            var UpdateDef = Builders<BaseGame>.Update.Set("Name", name).Set("Developer", developer).Set("Description", description).Set("Count_of_players", count_of_players);
            data.UpdateOne(basa => basa._id == ObjectId.Parse(id), UpdateDef);
        }

        public override void Delete(string id)
        {
            data.DeleteOne(basa => basa._id == ObjectId.Parse(id));
        }
    }
}
