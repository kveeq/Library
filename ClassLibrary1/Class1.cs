using System;

namespace ClassLibrary1
{
    public class Collection
    {
        public string name;


        public Collection(string name)
        {
            this.name = name;
        }

        public virtual void Add()
        {
            Console.WriteLine("Figure is drawn");
        }

        public virtual void Reduct()
        {
            Console.WriteLine("Figure is drawn");
        }

        public virtual void Delete()
        {
            Console.WriteLine("Figure is drawn");
        }
    }

    public class Book : Collection
    {
        private string autor;
        private string illustrator;
        private string izdatelstvo;
        private string year;

        public Book(string name, string autor, string illustrator, string izdatelstvo, string year) : base(name)
        {
            this.autor = autor;
            this.illustrator = illustrator;
            this.izdatelstvo = izdatelstvo;
            this.year = year;
        }

        public override void Add()
        {
        }

        public override void Reduct()
        {
        }

        public override void Delete()
        {
        }
    }

    public class Pazzle : Collection
    {
        private int count_of_elem;
        private string company_name;

        public Pazzle(string name, int count_of_elem, string company_name) : base(name)
        {
            this.count_of_elem = count_of_elem;
            this.company_name = company_name;
        }

        public override void Add()
        {
        }

        public override void Reduct()
        {
        }

        public override void Delete()
        {
        }
    }

    public class Game : Collection
    {
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
        }

        public override void Reduct()
        {
        }

        public override void Delete()
        {
        }
    }
}
