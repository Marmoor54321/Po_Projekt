

//jakieś przykładowe klasy, można usunąć
/*
KsiazkaFizyczna ksiazka1 =  new KsiazkaFizyczna("Wiedźmin", "Andrzej Sapkowski", "Akcja", 29.99f, 4, 1);

KsiazkaFizyczna ksiazka2 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 10, 1);

KsiazkaElektroniczna ksiazka3 =  new KsiazkaElektroniczna("Harry Potter", "J.K. Rowling", "Fantastyka", 29.99f, 1, 1);

KsiazkaElektroniczna ksiazka4 =  new KsiazkaElektroniczna("Harry Potter 2", "J.K. Rowling", "Fantastyka", 99.99f, 1, 0);

KsiazkaFizyczna ksiazka5 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 10, 1);

Uzytkownik marmur = new Uzytkownik("marmur", "123", "marmur@gmail.com", "Bialystok");

List<Ksiazka> ksiazki = [ksiazka1, ksiazka2, ksiazka3];

Zamowienia zamowienie = new Zamowienia(321, ksiazki,0);

List<Ksiazka> ksiazki2 = [ksiazka4, ksiazka5,ksiazka1];

Zamowienia zamowienie1 = new Zamowienia(456, ksiazki2, 0);

marmur.DodajZamowienie(zamowienie);

marmur.WyszukajKsiazke(zamowienie, "Wiedź");

marmur.DodajDoKoszyka(ksiazka1);

marmur.ZlozZamowienie();

marmur.WyswietlZamowienia();

*/
/*
List<Zamowienia> listaZamowien = [zamowienie, zamowienie1];

Pracownik mateusz = new Pracownik("mateusz", "123", "mateusz@gmail.com");

mateusz.StanZamowien(listaZamowien);
*/


/*
Ksiegarnia ksiegarnia = new Ksiegarnia();

ksiegarnia.DodajKsiazke(ksiazka1);

ksiegarnia.DodajUzytkownika(marmur);

ksiegarnia.DodajZamowienie(zamowienie);
*/


//rzeczywisty kod głównego programu

public class Program
{
        public static void Main()
        {

             Ksiegarnia ksiegarnia = new Ksiegarnia();

             KsiazkaFizyczna ksiazka1 = new KsiazkaFizyczna("Tytul 1", "Autor 1", "Kategoria 1", 20.5f, 10, 0);
            KsiazkaElektroniczna ksiazka2 = new KsiazkaElektroniczna( "Tytul 2", "Autor 2", "Kategoria 2", 15.99f, 1, 1);
            ksiegarnia.DodajKsiazke(ksiazka1);
            ksiegarnia.DodajKsiazke(ksiazka2);
            
            
            Uzytkownik uzytkownik1 = new Uzytkownik("user1", "haslo1", "user1@example.com", "Adres 1");
            ksiegarnia.DodajUzytkownika(uzytkownik1);
            
           
            Pracownik pracownik1 = new Pracownik("admin", "admin123", "admin@example.com");
            ksiegarnia.DodajPracownika(pracownik1);


            Console.WriteLine("Witaj w księgarni!");

            while (true)
            {
                Console.WriteLine("\nWybierz opcję:");
                Console.WriteLine("1. Zaloguj jako użytkownik");
                Console.WriteLine("2. Zaloguj jako pracownik");
                Console.WriteLine("3. Wyjdź");

                int opcja = StrNaInt();

                switch (opcja)
                {
                    case 1:
                        ZalogujJakoUzytkownik(ksiegarnia);
                        break;
                    case 2:
                        ZalogujJakoPracownik(ksiegarnia);
                        break;
                    case 3:
                        Console.WriteLine("Dziękujemy! Do zobaczenia.");
                        return;
                    default:
                        Console.WriteLine("Niepoprawna opcja. Wybierz ponownie.");
                        break;
                }
            }
        }

         // Metoda do logowania jako użytkownik
    private static void ZalogujJakoUzytkownik(Ksiegarnia ksiegarnia)
    {
        Console.WriteLine("Logowanie użytkownika.");
        Console.WriteLine("Podaj login:");
        string login = Console.ReadLine();
        Console.WriteLine("Podaj hasło:");
        string haslo = Console.ReadLine();

        // Sprawdzanie czy użytkownik istnieje
        List<Uzytkownik> uzytkownicy = ksiegarnia.PobierzUzytkownikow();
        Uzytkownik zalogowanyUzytkownik = null;

        foreach (var uzytkownik in uzytkownicy)
        {
            if (uzytkownik.Login == login && uzytkownik.SprawdzHaslo(haslo))
            {
                zalogowanyUzytkownik = uzytkownik;
                break;
            }
        }

        if (zalogowanyUzytkownik != null)
        {
            Console.WriteLine($"Zalogowano jako użytkownik: {zalogowanyUzytkownik.Login}");
            //tutaj dodawać funkcjonalności użytkownika
            while (true)
        {
            string czescTytulu;

            int idZamowienia;

            Console.WriteLine("\nWybierz opcję:");
            Console.WriteLine("1. Wyświetl książki");
            Console.WriteLine("2. Wyszukaj książkę");
            Console.WriteLine("3. Dodaj do koszyka");
            Console.WriteLine("4. Złóż zamówienie");
            Console.WriteLine("5. Wyświetl zamówienia");
            Console.WriteLine("6. Śledź zamówienie");
            Console.WriteLine("7. Pokaż koszyk");
            Console.WriteLine("8. Wyloguj");

            int opcja = StrNaInt();

            switch (opcja)
            {
                case 1:
                    ksiegarnia.WypiszKsiazki();
                    
                    break;
                case 2:
                {
                    Console.WriteLine("Podaj tytuł książki do znalezienia: ");

                    czescTytulu = Console.ReadLine();

                    zalogowanyUzytkownik.WyszukajKsiazke(ksiegarnia.PobierzKsiazki(), czescTytulu);
                }
                    break;
                case 3:
                    {
                    Console.WriteLine("Podaj tytuł książki do dodania do koszyka: ");

                    czescTytulu = Console.ReadLine();

                    zalogowanyUzytkownik.DodajDoKoszyka(ksiegarnia.PobierzKsiazki(), czescTytulu);
                    }
                    break;
                case 4:
                    zalogowanyUzytkownik.ZlozZamowienie();
                    break;
                case 5:
                    {
                        zalogowanyUzytkownik.WyswietlZamowienia();
                    }
                    break;
                case 6:
                    Console.WriteLine("Wpisz Id zamówienia, które chcesz śledzić: ");
                    
                    idZamowienia = StrNaInt();
                    
                    Console.WriteLine(zalogowanyUzytkownik.SledzZamowienie(idZamowienia));
                    break;
                   
                case 7:
                    zalogowanyUzytkownik.WyswietlKoszyk();
                    break;
                case 8:
                    Console.WriteLine("Wylogowano.");
                    return;
                default:
                    Console.WriteLine("Niepoprawna opcja. Wybierz ponownie.");
                    break;
            }
        }

        }
        else
        {
            Console.WriteLine("Niepoprawny login lub hasło.");
        }
    }

      private static void ZalogujJakoPracownik(Ksiegarnia ksiegarnia)
    {
        Console.WriteLine("Logowanie pracownika.");
        Console.WriteLine("Podaj login:");
        string login = Console.ReadLine();
        Console.WriteLine("Podaj hasło:");
        string haslo = Console.ReadLine();

        // Sprawdzanie istnienia pracownika
        List<Pracownik> pracownicy = ksiegarnia.PobierzPracownikow();
        Pracownik zalogowanyPracownik = null;

        foreach (var pracownik in pracownicy)
        {
            if (pracownik.Login == login && pracownik.Haslo == haslo)
            {
                zalogowanyPracownik = pracownik;
                break;
            }
        }

        if (zalogowanyPracownik != null)
        {
            Console.WriteLine($"Zalogowano jako pracownik: {zalogowanyPracownik.Login}");
            // Tutaj dodawać funkcjonalności pracownika

        }
        else
        {
            Console.WriteLine("Niepoprawny login lub hasło.");
        }
    } 
    
    
    static int StrNaInt()
    {
        string wyborStr;
        int wejscie;

        while(true)
            {


                wyborStr = Console.ReadLine();
                try
                {
                    wejscie = int.Parse(wyborStr);
                    return wejscie;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                }
            }
    }
        
}


