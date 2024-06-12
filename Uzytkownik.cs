public class Uzytkownik
{
    //konstruktory
    //
    //
    private string login{get; set;}
    private string haslo{get; set;}
    private string email{get; set;}
    private string adres{get; set;}

    public List<Zamowienia> zamowienia = new List<Zamowienia>();

    public List<Ksiazka> koszyk = new List<Ksiazka>();

    public Uzytkownik(string login, string haslo, string email, string adres)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
        this.adres = adres;
    }


    //Nie wiem po co jest ta funkcja. Ma zwracać wszystkie info użytkownika?
    public string getInfo()
    {
        return $"Login: {login}, haslo: {haslo}, email: {email}, adres: {adres}.";
    }


    //wyszukuje książkę z podanego zamówienia i wyświetla jej informacje w zamoweniu (np. ilość kupionych, autor itd.)
    public string wyszukajKsiazkse(Zamowienia zamowienie, string czescTytulu)
    {
        List<string> znalezioneKsiazki = new List<string>();
        for(int i = 0; i<zamowienie.ksiazki.Count; i++)
        {
            
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

                    znalezioneKsiazki.Add($"Tytul: {ke.tytul}, autor: {ke.autor}, kategoria:{ke.kategoria}, cena: {ke.cenaEle}, format: {format}.");
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

                    znalezioneKsiazki.Add ($"Tytul: {kf.tytul}, autor: {kf.autor}, {kf.kategoria}, cena: {kf.cenaFiz}, format: {format}");
                }
            }
        }
        
        return "Brak książki";
    }

}