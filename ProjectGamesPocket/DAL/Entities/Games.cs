using MySql.Data.MySqlClient;
using System.Windows;

namespace ProjectGamesPocket.DAL.Entities
{
    class Games
    {
        public int? ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            private set;
        }
        public string Publisher
        {
            get;
            private set;
        }
        public string Producer_id
        {
            get;
            private set;
        }
        public string Type
        {
            get;
            private set;
        }
        public double Price
        {
            get;
            private set;
        }
        public string ReleaseDate
        {
            get;
            private set;
        }
        public uint Metacritics
        {
            get;
            private set;
        }
        public string Exclusive
        {
            get;
            private set;
        }
        public string IsSeries
        {
            get;
            private set;
        }
        public uint PEGI
        {
            get;
            private set;
        }

        public Games(
            string name,
            string publisher,
            string producer,
            string type,
            double price,
            string release_date,
            uint metacritics,
            string exclusive,
            string isSeries,
            uint pegi)
        {
            ID = null;
            Name = name.Trim();
            Publisher = publisher;
            Producer_id = producer;
            Type = type;
            Price = price;
            ReleaseDate = release_date;
            Metacritics = metacritics;
            Exclusive = exclusive;
            IsSeries = isSeries;
            PEGI = pegi;
        }

        public Games(Games games)
        {
            ID = games.ID;
            Name = games.Name;
            Publisher = games.Publisher;
            Producer_id = games.Producer_id;
            Type = games.Type;
            Price = games.Price;
            ReleaseDate = games.ReleaseDate;
            Metacritics = games.Metacritics;
            Exclusive = games.Exclusive;
            IsSeries = games.IsSeries;
            PEGI = games.PEGI;
        }

        public Games(MySqlDataReader mySqlDataReader)
        {
            ID = int.Parse(mySqlDataReader["id_game"].ToString());
            Name = mySqlDataReader["namegame"].ToString();
            Publisher = mySqlDataReader["publisher"].ToString();
            Producer_id = mySqlDataReader["producer"].ToString();
            Type = mySqlDataReader["type"].ToString();
            Price = double.Parse(mySqlDataReader["price"].ToString());
            ReleaseDate = mySqlDataReader["release_date"].ToString();
            Metacritics = uint.Parse(mySqlDataReader["metacritics"].ToString());
            Exclusive = mySqlDataReader["exclusive"].ToString();
            IsSeries = mySqlDataReader["IsSeries"].ToString();
            PEGI = uint.Parse(mySqlDataReader["pegi"].ToString());
        }

        public string ToInsert()
        {
            var price = Price.ToString().Replace(',', '.');
            MessageBox.Show(price.ToString(),"xd");
            return $"('{Name}','{Publisher}','{Producer_id}','{Type}','{price}','{ReleaseDate}','{Metacritics}'," +
                $"'{Exclusive}','{IsSeries}','{PEGI}')";
        }

        public override string ToString()
        {
            return $"'{ID}','{Name}','{Publisher}','{Producer_id}','{Type}','{Price}','{ReleaseDate}','{Metacritics}'," +
                $"'{Exclusive}','{IsSeries}','{PEGI}'";
        }
    }
}