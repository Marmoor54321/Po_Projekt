public class Pracownik
{
    private string login{get; set;}
    private string haslo{get; set;}
    private string email{get; set;}

    public Pracownik(string login, string haslo, string email)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
    }
    int wybor;
    bool validInput=false;
    public List<Ksiazka> statusMagazynu(List<Ksiazka> ksiazki)
    {
        wybor = StrNaInt();
        

        switch(wybor)
        {
            case 1:
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
                        Console.WriteLine($"[{i}] Typ: elektroniczna, tytuł: {ksiazkaelek.tytul}, autor: {ksiazkaelek.autor}, ilość w magazynie: {ksiazkaelek.stan}, cena: {ksiazkaelek.cenaEle}.");  
                    }
                }
            }
            break;

            case 2: //modyfikowanie stanu i ceny
            {
                 Console.WriteLine("Wybierz numer ksiażki do zmiany stanu lub ceny.");

                 while(!validInput)
                {
                    Console.WriteLine("Wybierz opcję: ");


                    
                    Console.WriteLine("1-Zmiana stanu");
                    Console.WriteLine("2-Zmiana ceny");

                    wybor = StrNaInt();

                    switch(wybor)
                    {
                        case 1:
                        {
                            
                        }
                        break;
                    }
                }

            }
            break;
        }
        return ksiazki;
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
                Console.WriteLine("Niepoprawna opcja.");
            }
        }
}
}

