public class Pracownik
{

    //niegotowa klasa
    //trzeba dodać opcję dodawania i usuwania książek, mozna to wrzucić do StanMagazynu()
    private string login{get; set;}
    private string haslo{get; set;}
    private string email{get; set;}

    public Pracownik(string login, string haslo, string email)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
    }
    int wybor, wybor2=-1,wybor3,nowyStan=0;

    float nowaCena=0;

    //Wypisanie stanu magazynu lub modyfikowanie stanu i ceny
    public List<Ksiazka> statusMagazynu(List<Ksiazka> ksiazki) 
    {

        
        while(wybor!=3)
        {
            Console.WriteLine("1-wypisanie stanu magazynu.\n2-Modyfikuj cenę lub stan.\n3-Wróć.");

            wybor = StrNaInt();

            switch(wybor)
            {   
            
            
                case 1:  //wypisanie stanu magazynu
                {
                    for(int i=0; i<ksiazki.Count(); i++)
                    {
                        if(ksiazki[i] is KsiazkaFizyczna ksiazkafiz)
                        {
                            Console.WriteLine($"[{i}] Typ: fizyczna, tytuł: {ksiazkafiz.tytul}, autor: {ksiazkafiz.autor}, ilość w magazynie: {ksiazkafiz.stan}, cena: {ksiazkafiz.cenaFiz}.");
                        }
                        else if(ksiazki[i] is KsiazkaElektroniczna ksiazkaelek)
                        {
                            //stan książki elektronicznej: 0-niedostępna, 1-dostępna
                            Console.WriteLine($"[{i}] Typ: elektroniczna, tytuł: {ksiazkaelek.tytul}, autor: {ksiazkaelek.autor}, dostepna?: {ksiazkaelek.stan}, cena: {ksiazkaelek.cenaEle}.");  
                        }
                    }
                }
                break;

                case 2: //modyfikowanie stanu i ceny
                {
                    Console.WriteLine("Wybierz numer ksiażki do zmiany stanu lub ceny.");

                    wybor2 = StrNaInt();

                    while(wybor2<0 || wybor2>ksiazki.Count())
                    {
                    Console.WriteLine("Niepoprawny numer. Wpisz ponownie: ");
                    wybor2 = StrNaInt();
                    }

                    Console.WriteLine("1-modyfikuj cenę\n2-modyfikuj stan.");

                    wybor3  = StrNaInt();
                    while(wybor3<1 || wybor3>2)
                    {
                    Console.WriteLine("Niepoprawny numer. Wpisz ponownie: ");
                    wybor3 = StrNaInt();
                    }



                    switch(wybor3)
                    {
                        case 1:
                        {
                    
                                Console.WriteLine("Podaj nową cenę.");

                                nowaCena = StrNaFloat();
                                while(nowaCena<0)
                                {
                                    Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                                    nowaCena = StrNaFloat();
                                }
                                if(ksiazki[wybor2] is KsiazkaFizyczna ksiazkafiz)
                                {
                                    ksiazkafiz.cenaFiz = nowaCena;
                                }
                                else if(ksiazki[wybor2] is KsiazkaElektroniczna ksiazkaelek)
                                {
                                ksiazkaelek.cenaEle = nowaCena;
                                }
                            
                        }
                        break;


                        case 2:
                        {
                        
                        
                            Console.WriteLine("Podaj nowy stan: ");

                            nowyStan = StrNaInt();
                            while(nowyStan<0)
                            {
                                Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                                nowyStan = StrNaInt();
                            }
                            if(ksiazki[wybor2] is KsiazkaFizyczna ksiazkafiz)
                            {
                                ksiazkafiz.stan = nowyStan;
                            }
                            else if(ksiazki[wybor2] is KsiazkaElektroniczna ksiazkaelek)
                            {
                                while(nowyStan>2)
                                {
                                    Console.WriteLine("Ksiazka elektroniczna może być tylko 0-niedostępna, 1-dostępna. Wpisz ponownie: ");
                                    nowyStan = StrNaInt();
                                }
                            ksiazkaelek.stan = nowyStan;
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

     int opcja1,opcja2;
    public List<Zamowienia> StanZamowien(List<Zamowienia> zamowienia)   //wyświetla lub modyfikuje stan zamówień
    {
        wybor=0;

        string okladka;

        while(wybor!=3)
        {
            Console.WriteLine("1-Wyswietl zamowienia.\n2-Zmien stan zamowienia.\n3-Wróć.");

            wybor=StrNaInt();
            while(wybor<1 || wybor >3)
            {
                Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                wybor=StrNaInt();
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
                                if(ksiazkafiz.formatKsiazki==1)
                                {
                                    okladka = "twarda okładka";
                                }

                                Console.WriteLine($"[{j}] Książka fizyczna-{okladka}, tytuł: {zamowienia[i].ksiazki[j].tytul}");
                            }
                            else if(zamowienia[i].ksiazki[j] is KsiazkaElektroniczna ksiazkaelek)
                            {
                                okladka="e-book";
                                if(ksiazkaelek.formatKsiazki==1)
                                {
                                    okladka = "audiobook";
                                }

                            Console.WriteLine($"[{j}] Książka elektroniczna-{okladka}, tytuł: {zamowienia[i].ksiazki[j].tytul}");
                            }
                        
                    }
                }

            }
            
            

            if(wybor==2)
            {
               
                
                Console.WriteLine("Wybierz zamówienie do modyfikacji: ");
                opcja1 = StrNaInt();

                while(opcja1<0 || opcja1>zamowienia.Count()); //to nie działa nie wiem dlaczego, jutro to naprawię
                {
                    Console.WriteLine("Niepoprawne zamówienie. Wybierz ponownie: ");
                    opcja1 = StrNaInt();
                }

                Console.WriteLine("Podaj status przesyłki: ");
                opcja2 = StrNaInt();

                while(opcja2<0 || opcja2>4)
                {
                    Console.WriteLine("Niepoprawny status. Wpisz ponownie: ");
                    opcja2 = StrNaInt();
                }


            }
            
        }
        
        return zamowienia;
    }


        public int StrNaInt()
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

    public float StrNaFloat()
    {
        float wejscie;
        
        while(!float.TryParse(Console.ReadLine(), out wejscie))
        {
            Console.WriteLine("Niepoprawna wartość. Wpisz ponownie: ");
        }
        return wejscie;
    }
}

