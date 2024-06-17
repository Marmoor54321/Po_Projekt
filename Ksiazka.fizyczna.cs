public class KsiazkaFizyczna : Ksiazka
{

    //gotowa klasa
    public float cenaFiz { get; set; }
    public int stan { get; set; }
    public int formatKsiazki { get; set; } // 1 - twarda okładka, 2 - miękka okładka


    
    public KsiazkaFizyczna(string tytul, string autor, string kategoria, float cenaFiz, int stan, int formatKsiazki)
        : base(tytul, autor, kategoria)
    {
        this.cenaFiz = cenaFiz;
        this.stan = stan;
        this.formatKsiazki = formatKsiazki;
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