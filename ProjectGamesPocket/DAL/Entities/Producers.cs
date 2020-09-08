using MySql.Data.MySqlClient;

namespace ProjectGamesPocket.DAL.Entities
{
    class Producers
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
        public int YoE
        {
            get;
            private set;
        }
        public string Country
        {
            get;
            private set;
        }
        public string Website
        {
            get;
            private set;
        }

        public Producers(
            string name,
            int yoe,
            string country,
            string website)
        {
            ID = null;
            Name = name.Trim();
            YoE = yoe;
            Country = country;
            Website = website;
        }

        public Producers(Producers producers)
        {
            ID = producers.ID;
            Name = producers.Name;
            YoE = producers.YoE;
            Country = producers.Country;
            Website = producers.Website;
        }

        public Producers(MySqlDataReader mySqlDataReader)
        {
            ID = int.Parse(mySqlDataReader["id_producer"].ToString());
            Name = mySqlDataReader["NameProducer"].ToString();
            YoE = int.Parse(mySqlDataReader["YoE"].ToString());
            Country = mySqlDataReader["Country"].ToString();
            Website = mySqlDataReader["Website"].ToString();
        }

        public string ToInsert()
        {
            return $"('{Name}', '{YoE}', '{Country}', '{Website}')";
        }

        public override string ToString()
        {
            return $"'{ID}','{Name}','{YoE}','{Country}','{Website}'";
        }
    }
}