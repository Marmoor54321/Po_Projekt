public class KsiazkaElektroniczna : Ksiazka
{
    public float cenaEle { get; set; }
    
    public int formatKsiazki {get; set;}

    public int stan {get; set;}
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

    public override int UpdateStan()
    {
        // Trzeba wypełnić logikę aktualizacji stanu książki  (!!!)
        return 1; 
    }
}
