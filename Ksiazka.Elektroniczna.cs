public class KsiazkaElektroniczna : Ksiazka
{
    public float cenaEle { get; set; }
    
    public int formatKsiazki {get; set;}

    public KsiazkaElektroniczna(string tytul, string autor, string kategoria, float cenaEle)
        : base(tytul, autor, kategoria)
    {
        this.cenaEle = cenaEle;
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
