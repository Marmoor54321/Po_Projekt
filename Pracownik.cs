public class Pracownik
{

    //gotowa klasa
    private string login{get; set;}
    private string haslo{get; set;}     
    private string email{get; set;}
        
        
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

    public Pracownik(string login, string haslo, string email)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
    }
    int wybor, wybor2=-1,wybor3,nowyStan=0;

    float nowaCena=0;

    //sprawdza czy podane hasło jest poprawne (niepotrzebne)
    /*
     public bool SprawdzHaslo(string haslo)
    {
        return this.haslo == haslo;
    }
    */

    //WAŻNE! metody pracownika trzeba zmodyfikować i przekleić do głównego programu w taki sposób, aby logika klasy była oddzielna od interface'u (inaczej mówiąc zesrałem się)
    //tzn. metody klasy w większości nie funkcjonują jako interfejs, a jedynie przetwarzają lub modyfikują dane
    //zrobiłem już tak w większości z uzytkownikiem

    //Wypisanie stanu magazynu lub modyfikowanie stanu i ceny, dodawanie książek
    public List<Ksiazka> StatusMagazynu(List<Ksiazka> ksiazki) 
    {

        
        while(wybor!=3)
        {
            Console.WriteLine("1-wypisanie stanu magazynu.\n2-Modyfikuj cenę lub stan.\n3-Wróć.");

            wybor = InputExceptionHandler.StrNaInt();

            switch(wybor)
            {   
            
            
                case 1:  //wypisanie stanu magazynu (niepotrzebne)
                {
                    
                }
                break;

                        

                case 2: //modyfikowanie stanu i ceny //trzeba zmienić logikę-wpisywać nazwę książki której dane chcesz zmienić zamiast jej indeksu 
                        //w Ksiegarnia jest metoda WyszukajKsiazke(), która ma od tego logikę

                {
                    Console.WriteLine("Wybierz numer ksiażki do zmiany stanu lub ceny.");

                    wybor2 = InputExceptionHandler.StrNaInt();

                    while(wybor2<0 || wybor2>ksiazki.Count())
                    {
                    Console.WriteLine("Niepoprawny numer. Wpisz ponownie: ");
                    wybor2 = InputExceptionHandler.StrNaInt();
                    }

                    Console.WriteLine("1-modyfikuj cenę\n2-modyfikuj stan.");

                    wybor3  = InputExceptionHandler.StrNaInt();
                    while(wybor3<1 || wybor3>2)
                    {
                    Console.WriteLine("Niepoprawny numer. Wpisz ponownie: ");
                    wybor3 = InputExceptionHandler.StrNaInt();
                    }



                    switch(wybor3)
                    {
                        case 1:
                        {
                    
                                Console.WriteLine("Podaj nową cenę.");

                                nowaCena = InputExceptionHandler.StrNaFloat();
                                while(nowaCena<0)
                                {
                                    Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                                    nowaCena = InputExceptionHandler.StrNaFloat();
                                }
                                if(ksiazki[wybor2] is KsiazkaFizyczna ksiazkafiz)
                                {
                                    ksiazkafiz.CenaFiz = nowaCena;
                                }
                                else if(ksiazki[wybor2] is KsiazkaElektroniczna ksiazkaelek)
                                {
                                ksiazkaelek.CenaEle = nowaCena;
                                }
                            
                        }
                        break;


                        case 2:
                        {
                        
                        
                            Console.WriteLine("Podaj nowy stan: ");

                            nowyStan = InputExceptionHandler.StrNaInt();
                            while(nowyStan<0)
                            {
                                Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                                nowyStan = InputExceptionHandler.StrNaInt();
                            }
                            if(ksiazki[wybor2] is KsiazkaFizyczna ksiazkafiz)
                            {
                                ksiazkafiz.Stan = nowyStan;
                            }
                            else if(ksiazki[wybor2] is KsiazkaElektroniczna ksiazkaelek)
                            {
                                while(nowyStan>2)
                                {
                                    Console.WriteLine("Ksiazka elektroniczna może być tylko 0-niedostępna, 1-dostępna. Wpisz ponownie: ");
                                    nowyStan = InputExceptionHandler.StrNaInt();
                                }
                            ksiazkaelek.Stan = nowyStan;
                            }

                        }
                        break;
                        
                    
                    }
                    Console.WriteLine("Zapisano zmiany.");
                    
                }
                break;
            }
            
        }
        return ksiazki;
    }

    //nie zaimplementowany kod

     int opcja1,opcja2;
    public List<Zamowienia> StanZamowien(List<Zamowienia> zamowienia)   //wyświetla lub modyfikuje stan zamówień
    {
        wybor=0;

        string okladka;

        while(wybor!=3)
        {
            Console.WriteLine("1-Wyswietl zamowienia.\n2-Zmien stan zamowienia.\n3-Wróć.");

            wybor= InputExceptionHandler.StrNaInt();
            while(wybor<1 || wybor >3)
            {
                Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                wybor=InputExceptionHandler.StrNaInt();
            }

            if(wybor==1)
            {
                for(int i=0; i<zamowienia.Count(); i++)
                {
                    Console.WriteLine($"Zamowienie [{i}] Id: {zamowienia[i].idZamowienia}, status przesyłki: {zamowienia[i].statusZamowienia}");

                    Console.WriteLine("Książki w zamówieniu: ");

                            

                    for(int j=0; j<zamowienia[i].ksiazki.Count();j++)
                    {

                        if(zamowienia[i].ksiazki[j] is KsiazkaFizyczna ksiazkafiz)
                            {
                                okladka="miękka okładka";
                                if(ksiazkafiz.FormatKsiazki==1)
                                {
                                    okladka = "twarda okładka";
                                }

                                Console.WriteLine($"[{j}] Książka fizyczna-{okladka}, tytuł: {zamowienia[i].ksiazki[j].Tytul}.");
                            }
                            else if(zamowienia[i].ksiazki[j] is KsiazkaElektroniczna ksiazkaelek)
                            {
                                okladka="e-book";
                                if(ksiazkaelek.FormatKsiazki==1)
                                {
                                    okladka = "audiobook";
                                }

                            Console.WriteLine($"[{j}] Książka elektroniczna-{okladka}, tytuł: {zamowienia[i].ksiazki[j].Tytul}");
                            }
                        
                    }
                }

            }
            
            

            if(wybor==2)
            {
               
                
                Console.WriteLine("Wybierz zamówienie do modyfikacji: ");
                opcja1 = InputExceptionHandler.StrNaInt();

                while(opcja1<0 || opcja1>zamowienia.Count()) 
                {
                    Console.WriteLine("Niepoprawne zamówienie. Wybierz ponownie: ");
                    opcja1 = InputExceptionHandler.StrNaInt();
                }

                Console.WriteLine("Podaj status przesyłki: ");
                opcja2 = InputExceptionHandler.StrNaInt();

                while(opcja2<0 || opcja2>4)
                {
                    Console.WriteLine("Niepoprawny status. Wpisz ponownie: ");
                    opcja2 = InputExceptionHandler.StrNaInt();
                }

                zamowienia[opcja1].statusZamowienia = opcja2;
            }
            
        }
        
        return zamowienia;
    }


       

 
}

