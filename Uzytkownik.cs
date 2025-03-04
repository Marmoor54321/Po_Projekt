public class Uzytkownik

{

    private string login { get; set; }
    public string haslo { get; set; }
    private string email { get; set; }
    private string adres { get; set; }

    public List<Zamowienia> zamowienia;

    public List<Ksiazka> koszyk { get; set; }


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
        set { email = value; }
    }

    public string Adres
    {
        get { return adres; }
        set { adres = value; }
    }

    public List<Zamowienia> Zamowienia
    {
        get { return zamowienia; }
        set { zamowienia = value; }
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

    public void DodajZamowienie(Zamowienia zamowienie)
    {
        zamowienia.Add(zamowienie);
    }


    public void DodajDoKoszyka(List<Ksiazka> ksiazki, string czescTytulu)
    {
        int indeksKsiazki = -1;
        int formatKsiazki;
        for (int i = 0; i < ksiazki.Count; i++)
            if (ksiazki[i].Tytul.StartsWith(czescTytulu, StringComparison.OrdinalIgnoreCase))
            {

                koszyk.Add(ksiazki[i]);
                indeksKsiazki++;

                if (koszyk[indeksKsiazki] is KsiazkaFizyczna kf)
                {
                    Console.WriteLine($"Wybierz format książki {kf.Tytul} 0-miękka okładka, 1-twarda okładka: ");
                    formatKsiazki = InputExceptionHandler.StrNaInt();
                    while (true)
                    {
                        if (formatKsiazki < 0 || formatKsiazki > 1)
                        {
                            Console.WriteLine("Niepoprawny format książki 0-miękka okładka, 1-twarda okładka");
                            formatKsiazki = InputExceptionHandler.StrNaInt();
                        }
                        else
                            break;
                    }
                    kf.FormatKsiazki = formatKsiazki;
                }
                else if (koszyk[indeksKsiazki] is KsiazkaElektroniczna ke)
                {
                    Console.WriteLine($"Wybierz format książki {ke.Tytul} 0-ebook, 1-audiobook: ");
                    formatKsiazki = InputExceptionHandler.StrNaInt();

                    while (true)
                    {
                        if (formatKsiazki < 0 || formatKsiazki > 1)
                        {
                            Console.WriteLine("Niepoprawny format książki 0-ebook, 1-audiobook:");
                            formatKsiazki = InputExceptionHandler.StrNaInt();
                        }
                        else
                            break;
                    }
                    ke.FormatKsiazki = formatKsiazki;
                }


                Console.WriteLine($"Dodano książkę {ksiazki[i].Tytul} do koszyka.");
                break;
            }
    }


    //można zamówić kilka sztuk tej samej książki (yay)
    public void ZlozZamowienie(List<Ksiazka> ksiazki)
    {
        Random random = new Random();

        int losoweId = random.Next(1000, 10000 + 1);

        Zamowienia zamowienie = new Zamowienia(losoweId, koszyk, 0);

        foreach (var ksiazkaWKoszyku in koszyk)
        {
            foreach (var ksiazka in ksiazki)
            {
                if (ksiazka is KsiazkaElektroniczna ke)
                {
                    if (ke.Stan < 1)
                    {
                        Console.WriteLine("Brak ksiazki na stanie.");
                        break;
                    }

                    else if (ke.Stan >= 1)
                    {

                        Console.WriteLine($"Link do książki {ksiazka.Tytul}: {ke.GenerujLosoweUrl()}");

                    }
                }
                else if (ksiazka is KsiazkaFizyczna kf)
                {
                    if (kf.Stan < 1)
                    {
                        Console.WriteLine("Brak ksiazki na stanie.");
                        break;
                    }
                    else if (kf.Tytul == ksiazkaWKoszyku.Tytul)
                    {

                        kf.Stan--;
                        break;
                    }
                }
            }
        }

        //wyczyszczenie koszyka po zakupie
        koszyk.Clear();

        DodajZamowienie(zamowienie);

        Console.WriteLine("Zamówienie złożone pomyślnie");
    }




    public string SledzZamowienie(int id)
    {
        foreach (var zamowienie in zamowienia)
        {
            if (zamowienie.idZamowienia == id)
            {
                switch (zamowienie.statusZamowienia)
                {
                    case 0:
                        return "Zamowienie oczekuje wysyłki";
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
        foreach (var zamowienie in zamowienia)
        {
            Console.WriteLine($"Id zamówienia: {zamowienie.idZamowienia}, status zamowienia: {SledzZamowienie(zamowienie.idZamowienia)}.");
        }
    }

    public void WyswietlKoszyk()
    {
        decimal totalPrice = 0;

        for (int i = 0; i < koszyk.Count(); i++)
        {
            foreach (var ksiazka in koszyk)
            {
                if (ksiazka is KsiazkaElektroniczna ke)
                {
                    string format = "ebook";
                    if (ke.FormatKsiazki == 1)
                        format = "audiobook";

                    Console.WriteLine($"Tytul: {ke.Tytul}, autor: {ke.Autor}, kategoria: {ke.Kategoria}, cena: {ke.CenaEle}, format: {format}.");
                    totalPrice += (decimal)ke.CenaEle;
                }
                else if (ksiazka is KsiazkaFizyczna kf)
                {
                    string format = "miękka okładka";
                    if (kf.FormatKsiazki == 1)
                        format = "twarda okładka";

                    Console.WriteLine($"Tytul: {kf.Tytul}, autor: {kf.Autor}, kategoria: {kf.Kategoria}, cena: {kf.CenaFiz}, format: {format}.");
                    totalPrice += (decimal)kf.CenaFiz;
                }
            }
        }

        Console.WriteLine($"Łączna cena książek w koszyku: {totalPrice}");
    }
    public string ToCsvString()
    {
        return $"{login},{haslo},{email},{adres}";
    }



}