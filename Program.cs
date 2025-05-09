﻿using System; 
using static InputExceptionHandler;
             

/*
List<Ksiazka> ksiazki = [ksiazka1, ksiazka2, ksiazka3];

Zamowienia zamowienie = new Zamowienia(321, ksiazki,0);

List<Ksiazka> ksiazki2 = [ksiazka4, ksiazka5,ksiazka1];

Zamowienia zamowienie1 = new Zamowienia(456, ksiazki2, 0);

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
            //Przykładowe wartości do testowania
            KsiazkaFizyczna ksiazka1 =  new KsiazkaFizyczna("Wiedzmin", "Andrzej Sapkowski", "Akcja", 29.99f, 4);

            KsiazkaFizyczna ksiazka2 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 1);

            KsiazkaElektroniczna ksiazka3 =  new KsiazkaElektroniczna("Harry Potter", "J.K. Rowling", "Fantastyka", 29.99f, 1);

            KsiazkaElektroniczna ksiazka4 =  new KsiazkaElektroniczna("Harry Potter 2", "J.K. Rowling", "Fantastyka", 99.99f, 1);

            

            Uzytkownik marmur = new Uzytkownik("marmur", "123", "marmur@gmail.com", "Bialystok");

            List<Ksiazka> ksiazki1 = [ksiazka1, ksiazka2, ksiazka3, ksiazka4];
            
            
            
             Ksiegarnia ksiegarnia = new Ksiegarnia();

             Zamowienia zamowienie = new Zamowienia(1324,ksiazki1,0);

             marmur.DodajZamowienie(zamowienie);

             
            ksiegarnia.DodajKsiazke(ksiazka1);
            ksiegarnia.DodajKsiazke(ksiazka2);
            ksiegarnia.DodajKsiazke(ksiazka3);
            ksiegarnia.DodajKsiazke(ksiazka4);
            
            
            
            Uzytkownik uzytkownik1 = new Uzytkownik("user1", "haslo1", "przyklad@gmail.com", "Adres 1");
            ksiegarnia.DodajUzytkownika(uzytkownik1);
            ksiegarnia.DodajUzytkownika(marmur);
            
           
            Pracownik pracownik1 = new Pracownik("admin", "admin123", "adminprzyklad@gmail.com");
            ksiegarnia.DodajPracownika(pracownik1);

            List<Ksiazka> wszystkieKsiazki = new List<Ksiazka> { ksiazka1, ksiazka2, ksiazka3, ksiazka4 };
            DataHelper.SaveKsiazkiToFile("ksiazki.txt", wszystkieKsiazki);

            
            List<Uzytkownik> wszyscyUzytkownicy = new List<Uzytkownik> { uzytkownik1, marmur };
            DataHelper.SaveUzytkownicyToFile("uzytkownicy.txt", wszyscyUzytkownicy);
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
        string login = InputExceptionHandler.BezpiecznieWczytajString();
        Console.WriteLine("Podaj hasło:");
        string haslo = InputExceptionHandler.BezpiecznieWczytajString();



        // Sprawdzanie czy użytkownik istnieje
        List<Uzytkownik> uzytkownicy = ksiegarnia.PobierzUzytkownikow();
        Uzytkownik? zalogowanyUzytkownik = null;

        foreach (var uzytkownik in uzytkownicy)
        {
            if (uzytkownik.Login == login && uzytkownik.Haslo == haslo)
            {
                zalogowanyUzytkownik = uzytkownik;
                break;
            }
        }



        if (zalogowanyUzytkownik != null)
        {
            Console.WriteLine($"Zalogowano jako użytkownik: {zalogowanyUzytkownik.Login}");
            
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
            Console.WriteLine("8. Podaj adres lub email");
            Console.WriteLine("9. Wyloguj");



            int opcja = StrNaInt();
            int opcja2;
            



            switch (opcja)
            {
                case 1:
                    ksiegarnia.WypiszKsiazki();
                    
                    break;
                case 2:
                {
                    Console.WriteLine("Podaj tytuł książki do znalezienia: ");

                    czescTytulu = InputExceptionHandler.BezpiecznieWczytajString();

                    ksiegarnia.WyszukajKsiazke(ksiegarnia.PobierzKsiazki(), czescTytulu);
                }
                    break;
                case 3:
                    {
                    Console.WriteLine("Podaj tytuł książki do dodania do koszyka: ");

                    czescTytulu = InputExceptionHandler.BezpiecznieWczytajString();

                    zalogowanyUzytkownik.DodajDoKoszyka(ksiegarnia.PobierzKsiazki(), czescTytulu);
                    }
                    break;
                case 4:
                    zalogowanyUzytkownik.ZlozZamowienie(ksiegarnia.PobierzKsiazki());
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
                {
                    Console.WriteLine("1. Adres\n2. email");
                    opcja2=StrNaInt();
                    switch(opcja2)
                    {
                        case 1:
                        {
                            Console.WriteLine("Podaj adres:");
                            zalogowanyUzytkownik.Adres = InputExceptionHandler.BezpiecznieWczytajString();
                            
                        }
                        break;
                        case 2:
                        {
                            Console.WriteLine("Podaj email: ");
                            zalogowanyUzytkownik.Email = InputExceptionHandler.BezpiecznieWczytajString();
                        }
                        break;
                    }
                }
                break;
                case 9:
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
        string login = InputExceptionHandler.BezpiecznieWczytajString();
        Console.WriteLine("Podaj hasło:");
        string haslo = InputExceptionHandler.BezpiecznieWczytajString();

        // Sprawdzanie istnienia pracownika
        List<Pracownik> pracownicy = ksiegarnia.PobierzPracownikow();
        Pracownik? zalogowanyPracownik = null;

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
           
            

            while(true)
            {
            Console.WriteLine("\nWybierz opcję:");
            Console.WriteLine("1. Wyświetl książki");
            Console.WriteLine("2. Wyszukaj książkę");
            Console.WriteLine("3. Dodaj książkę");
            Console.WriteLine("4. Usuń książkę");
            Console.WriteLine("5. Wyswietl zamowienia");
            Console.WriteLine("6. Wyloguj");

            int opcja;

            string czescTytulu;

            opcja = StrNaInt();

            switch(opcja)
            {
                case 1:
                {
                    ksiegarnia.WypiszKsiazki();
                }
                break;

                case 2:
                {
                     Console.WriteLine("Podaj tytuł książki do znalezienia: ");

                    czescTytulu = InputExceptionHandler.BezpiecznieWczytajString();

                    ksiegarnia.WyszukajKsiazke(ksiegarnia.PobierzKsiazki(), czescTytulu);

                }
                break;

                case 3:
                {
                    int fizCzyElektr, stan;
                    string tytul;
                    string autor;
                    string kategoria;
                    float cena;

                    Console.WriteLine("1-Elektroniczna, 2-Fizyczna");
                    fizCzyElektr = StrNaInt();
                    Console.WriteLine("Podaj Tytuł: ");
                    tytul = InputExceptionHandler.BezpiecznieWczytajString();
                    Console.WriteLine("Podaj autora: ");
                    autor = InputExceptionHandler.BezpiecznieWczytajString();
                    Console.WriteLine("Podaj kategorię: ");
                    kategoria = InputExceptionHandler.BezpiecznieWczytajString();
                    if(fizCzyElektr == 1)
                    {
                        Console.WriteLine("Podaj cenę książki: ");
                        cena = InputExceptionHandler.StrNaInt();
                        Console.WriteLine("Podaj stan książki elektronicznej 1-dostępna, 0-niedostępna: ");
                        stan = InputExceptionHandler.StrNaInt();

                        KsiazkaElektroniczna ksiazka = new KsiazkaElektroniczna(tytul, autor, kategoria, cena, stan);
                        ksiegarnia.DodajKsiazke(ksiazka);
                    }
                    if(fizCzyElektr == 2)
                    {
                        Console.WriteLine("Podaj cenę książki: ");
                        cena = InputExceptionHandler.StrNaInt();
                        Console.WriteLine("Podaj stan książki fizycznej 1-dostępna, 0-niedostępna: ");
                        stan = InputExceptionHandler.StrNaInt();

                        KsiazkaFizyczna ksiazka = new KsiazkaFizyczna(tytul, autor, kategoria, cena, stan);
                        ksiegarnia.DodajKsiazke(ksiazka);
                        DataHelper.SaveKsiazkiToFile("ksiazki.txt", ksiegarnia.PobierzKsiazki());
                    }
                    

                }
                break;
                case 4:
                {   
                    int yesNo;
                    
                    Console.WriteLine("Podaj tytuł książki do usunięcia: ");

                    czescTytulu = InputExceptionHandler.BezpiecznieWczytajString();

                        List<Ksiazka> ksiazkiPomocnicze = ksiegarnia.PobierzKsiazki();

                        for(int i=0; i<ksiegarnia.PobierzKsiazki().Count(); i++)
                        {
                            if (ksiazkiPomocnicze[i].Tytul.StartsWith(czescTytulu, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Usunąć książkę {ksiazkiPomocnicze[i].Tytul}?\n1. Tak\n2. Nie");
                                yesNo = InputExceptionHandler.StrNaInt();
                                if(yesNo==1)
                                {
                                    ksiegarnia.UsunKsiazke(ksiazkiPomocnicze[i], ksiegarnia.PobierzKsiazki());
                                }
                            }
                        }
                        DataHelper.SaveKsiazkiToFile("ksiazki.txt", ksiegarnia.PobierzKsiazki());
                }
                break;
                
                case 5:
                {
                    foreach (Uzytkownik uzytkownik in ksiegarnia.PobierzUzytkownikow())
                    {
                        Console.WriteLine($"Uzytkownik: {uzytkownik.Login}");
                        foreach (Zamowienia zamowienie in uzytkownik.Zamowienia)
                        {
                            Console.WriteLine($"Id: {zamowienie.idZamowienia}, status: {zamowienie.statusZamowienia}.\nKsiazki: ");
                            foreach(var ksiazka in zamowienie.ksiazki)
                            {
                                 
                                        if(ksiazka is KsiazkaElektroniczna ke)
                                        {
                                            
                                            Console.WriteLine($"Tytul: {ke.Tytul}, autor: {ke.Autor}, kategoria: {ke.Kategoria}, cena: {ke.CenaEle}, typ: elektroniczna, stan: {ke.Stan}, format: {ke.FormatKsiazki}.");
                                        }
                                        else if(ksiazka is KsiazkaFizyczna kf)
                                        {
                                    
                                            Console.WriteLine($"Tytul: {kf.Tytul}, autor: {kf.Autor}, kategoria: {kf.Kategoria}, cena: {kf.CenaFiz}, typ: fizyczna, stan: {kf.Stan}, format: {kf.FormatKsiazki}.");
                                        }
                                    
                            }
                        }
                    }
                }
                break;
                
                case 6:
                {
                    Console.WriteLine("Wylogowano.");
                    return;
                }
                
            }

        }
        }
        else
        {
            Console.WriteLine("Niepoprawny login lub hasło.");
        }
    } 
    
    
   


        
}


