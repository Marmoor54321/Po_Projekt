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


    //stan książki elektronicznej: 0-niedostępna, 1-dostępna
    
    public KsiazkaElektroniczna(string tytul, string autor, string kategoria, float cenaEle, int stan, int formatKsiazki)
        : base(tytul, autor, kategoria)
    {
        this.cenaEle = cenaEle;
        this.stan = stan;
        this.formatKsiazki = formatKsiazki;
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
