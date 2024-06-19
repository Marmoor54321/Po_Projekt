using System.Dynamic;

public class KsiazkaFizyczna : Ksiazka
{

    //gotowa klasa
    private float cenaFiz { get; set; }
    private int stan { get; set; }
    private int formatKsiazki { get; set; } // 1 - twarda okładka, 2 - miękka okładka //format podaje klient przy zakupie, nie ustawiamy go przy tworzeniu obiektu

    public float CenaFiz
    {
        get {return cenaFiz;}
        set {cenaFiz = value;}
    }

    public int Stan
    {
        get {return stan;}
        set {stan = value;}
    }

    public int FormatKsiazki
    {
        get {return formatKsiazki;}
        set {formatKsiazki = value;}
    }
    
    public KsiazkaFizyczna(string tytul, string autor, string kategoria, float cenaFiz, int stan)
        : base(tytul, autor, kategoria)
    {
        this.cenaFiz = cenaFiz;
        this.stan = stan;
        
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", CenaFiz: {cenaFiz}, Stan: {stan}, Format: {formatKsiazki}";
    }

    /*
    public override int UpdateStan()
    {
        
        return stan;
    }
    */
}