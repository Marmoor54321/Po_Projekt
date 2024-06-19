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
}
