
    public class ksiazka
    {
        public string tytul{get; set;};

        public string autor{get; set;};

        public string kategoria{get; set;};

        public ksiazka(string tytul, string autor, string kategoria)
        {
            this.tytul = tytul;
            this.autor = autor;
            this.kategoria = kategoria;
        }

        public virtual string get_details()
        {
            return $"Tytul: {tytul}, autor: {autor}, kategoria: {kategoria}.";
        }

        public virtual int update_stan()
        {

        }

    }

