using System.Text;

public class KsiazkaElektroniczna : Ksiazka
{
//gotowa klasa 
    private float cenaEle;
    
    private int formatKsiazki;

    private int stan;

     public float CenaEle
     {
        get {return cenaEle;}
        set {cenaEle = value;}
     }

     public int FormatKsiazki
     {
        get {return formatKsiazki;}
        set {formatKsiazki = value;}
     }
        
    public int Stan
    {
        get {return stan;}
        set {stan = value;}
    }


    //stan książki elektronicznej: 0-niedostępna, 1-dostępna, format: 0-ebook 1-audiobook
    //format podaje klient przy zakupie, nie ustawiamy go przy tworzeniu obiektu
    public KsiazkaElektroniczna(string tytul, string autor, string kategoria, float cenaEle, int stan)
        : base(tytul, autor, kategoria)
    {
        this.cenaEle = cenaEle;
        this.stan = stan;
        
    }

    
    /// nie uzyte
    
    public override string GetDetails()
    {
        return base.GetDetails() + $", CenaEle: {cenaEle}";
    }

/*
    public override int UpdateStan()
    {
        
        return 1; 
    }
    */

    
    private static Random random = new Random();

    /// <summary>
    /// tworzy losowy adres URL wyświetlany po zakupie książki elektronicznej
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public string GenerujLosoweUrl(int length = 10)
    {
        
        string litery = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder builder = new StringBuilder();

        
        for (int i = 0; i < length; i++)
        {
            builder.Append(litery[random.Next(litery.Length)]);
        }

        
        string losoweUrl= builder.ToString();
        string url = $"https://www.ksiegarnia.com/ksiazka_elektroniczna/{losoweUrl}";

        return url;
    }
}
