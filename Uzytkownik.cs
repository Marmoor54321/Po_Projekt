public class Uzytkownik
{
    
    private string login{get; set;}
    private string haslo{get; set;}
    private string email{get; set;}
    private string adres{get; set;}

    public List<Zamowienia> zamowienia {get; set;}

    public List<Ksiazka> koszyk {get; set;}

    public Uzytkownik(string login, string haslo, string email, string adres)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
        this.adres = adres;
        zamowienia = new List<Zamowienia>();
        koszyk = new List<Ksiazka>();
    }

    
   

   

    //Nie wiem po co jest ta funkcja. Ma zwracać wszystkie info użytkownika?
    public string GetInfo()
    {
        return $"Login: {login}, haslo: {haslo}, email: {email}, adres: {adres}.";
    }

    bool t=false;
    //wyszukuje książkę z podanego zamówienia i wyświetla jej informacje w zamoweniu (dodać opcję kupowania kilku sztuk tej samej książki?)
    public void WyszukajKsiazke(Zamowienia zamowienie, string czescTytulu)
    {
        
        for(int i = 0; i<zamowienie.ksiazki.Count; i++)
        {
            t=true;
           if (zamowienie.ksiazki[i].tytul.StartsWith(czescTytulu, StringComparison.OrdinalIgnoreCase))
            {

                if(zamowienie.ksiazki[i] is KsiazkaElektroniczna ke)
                {
                    string format;

                    if(ke.formatKsiazki == 0)
                    {
                        format = "Cyfrowa";
                    }
                    else
                    {
                        format = "Audiobook";
                    }

                    Console.WriteLine($"Tytul: {ke.tytul}, autor: {ke.autor}, kategoria:{ke.kategoria}, cena: {ke.cenaEle}, format: {format}.");
                }
                else if(zamowienie.ksiazki[i] is KsiazkaFizyczna kf)
                {
                    string format;

                    if(kf.formatKsiazki == 0)
                    {
                        format = "Miękka okładka";
                    }
                    else
                    {
                        format = "Twarda okładka";
                    }

                    Console.WriteLine($"Tytul: {kf.tytul}, autor: {kf.autor}, {kf.kategoria}, cena: {kf.cenaFiz}, format: {format}");
                }
            }
        }
        if(t==false)
        Console.WriteLine("Nie znaleziono książki.");        
    }

    //jeszcze nie wiem czy DodajZamowienie jest potrzebne ale na razie niech będzie
    public void DodajZamowienie(Zamowienia zamowienie)
        {
            zamowienia.Add(zamowienie);
        }


        public void DodajDoKoszyka(Ksiazka ksiazka)
        {
            koszyk.Add(ksiazka);
        }
    
        public Zamowienia ZlozZamowienie()
        {
             Random random = new Random();

             int losoweId = random.Next(1000, 10000+1);

             Zamowienia zamowienie =  new Zamowienia(losoweId, koszyk, 0);
             

             //wyczyszczenie koszyka po zakupie
             koszyk.Clear();

             return zamowienie;
        }

        public string SledzZamowienie(Zamowienia zamowienie)
        {
            if(zamowienie.statusZamowienia == 0)
            {
                return "Zamowienie oczekiwuje wysyłki";
            }
            if(zamowienie.statusZamowienia == 1)
            {
                return "Zamowienie przekazane do wysłania";
            }
            if(zamowienie.statusZamowienia == 2)
            {
                return "Zamowienie w drodze";
            }
             if(zamowienie.statusZamowienia == 3)
            {
                return "Zamowienie czeka na odbiór";
            }
            if(zamowienie.statusZamowienia == 4)
            {
                return "Zamowienie odebrane";
            }
            return "Błąd";
        }

        public void WyswietlZamowienia()
        {
            foreach(var zamowienie in zamowienia)
            {
                Console.WriteLine($"Id zamówienia: {zamowienie.idZamowienia}, status zamowienia: {zamowienie.statusZamowienia}.");
            }
        }
}