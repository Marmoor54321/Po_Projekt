public class Uzytkownik

//gotowa klasa
{
    
    private string login{get; set;}
    public string haslo{get; set;}
    private string email{get; set;}
    private string adres{get; set;}

    public List<Zamowienia> zamowienia {get; set;}

    public List<Ksiazka> koszyk {get; set;}


public string Login
    {
        get { return login; }
    }

    public string Haslo
    {
        get { return haslo; }
    }

    public string Email
    {
        get { return email; }
    }

    public string Adres
    {
        get { return adres; }
    }

    public Uzytkownik()
    {

    }
    public Uzytkownik(string login, string haslo, string email, string adres)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
        this.adres = adres;
        zamowienia = new List<Zamowienia>();
        koszyk = new List<Ksiazka>();
    }

    
   

   
    //sprawdza czy podane hasło jest poprawne
     public bool SprawdzHaslo(string haslo)
    {
        return this.haslo == haslo;
    }

    bool t=false;
    //wyszukuje książkę i wyświetla jej informacje w zamowieniu (dodać opcję kupowania kilku sztuk tej samej książki?)
    public void WyszukajKsiazke(List<Ksiazka> ksiazki, string czescTytulu)
    {
        
        for(int i = 0; i<ksiazki.Count; i++)
        {
            
           if (ksiazki[i].Tytul.StartsWith(czescTytulu, StringComparison.OrdinalIgnoreCase))
            {
                t=true;
                if(ksiazki[i] is KsiazkaElektroniczna ke)
                {
                    
                    Console.WriteLine($"Tytul: {ke.Tytul}, autor: {ke.Autor}, kategoria:{ke.Kategoria}, cena: {ke.CenaEle}.");
                }
                else if(ksiazki[i] is KsiazkaFizyczna kf)
                {
              
                    Console.WriteLine($"Tytul: {kf.Tytul}, autor: {kf.Autor}, kategoria: {kf.Kategoria}, cena: {kf.CenaFiz}.");
                }
            }
    
        }
        if(t==false)
        Console.WriteLine("Nie znaleziono książki.");        
    }

    
    public void DodajZamowienie(Zamowienia zamowienie)
        {
            zamowienia.Add(zamowienie);
        }


        public void DodajDoKoszyka(List<Ksiazka> ksiazki, string czescTytulu)
        {
             for(int i = 0; i<ksiazki.Count; i++)
             if (ksiazki[i].Tytul.StartsWith(czescTytulu, StringComparison.OrdinalIgnoreCase))
             {
                koszyk.Add(ksiazki[i]);
                break;
             }
        }
    
        public void ZlozZamowienie()
        {
             Random random = new Random();

             int losoweId = random.Next(1000, 10000+1);

             Zamowienia zamowienie =  new Zamowienia(losoweId, koszyk, 0);
             

             //wyczyszczenie koszyka po zakupie
             koszyk.Clear();

             DodajZamowienie(zamowienie);

             Console.WriteLine("Zamówienie złożone pomyślnie");
        }

        
           
        
        public string SledzZamowienie(int id)
        {   foreach (var zamowienie in zamowienia)
            {
                if (zamowienie.idZamowienia == id)
                {
                    switch (zamowienie.statusZamowienia)
                    {
                        case 0:
                            return "Zamowienie oczekiwuje wysyłki";
                        case 1:
                            return "Zamowienie przekazane do wysłania";
                        case 2:
                            return "Zamowienie w drodze";
                        case 3:
                            return "Zamowienie czeka na odbiór";
                        case 4:
                            return "Zamowienie odebrane";
                        default:
                            return "Błąd";
                    }
                }
            }
            return "Niepoprawne Id.";
        }

        public void WyswietlZamowienia()
        {
            foreach(var zamowienie in zamowienia)
            {
                Console.WriteLine($"Id zamówienia: {zamowienie.idZamowienia}, status zamowienia: {zamowienie.statusZamowienia}.");
            }
        }

        public void WyswietlKoszyk()
        {
            for(int i=0; i<koszyk.Count(); i++)
            {
                Console.WriteLine($"[{i+1}]{koszyk[i].Tytul}");
            }
        }
}