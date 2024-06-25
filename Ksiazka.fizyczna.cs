using System.Dynamic;

public class KsiazkaFizyczna : Ksiazka
{
    private float cenaFiz;
    private int stan;
    private int formatKsiazki; // 1 - twarda okładka, 2 - miękka okładka

    public float CenaFiz
    {
        get { return cenaFiz; }
        set { cenaFiz = value; }
    }

    public int Stan
    {
        get { return stan; }
        set { stan = value; }
    }

    public int FormatKsiazki
    {
        get { return formatKsiazki; }
        set { formatKsiazki = value; }
    }

    public KsiazkaFizyczna(string tytul, string autor, string kategoria, float cenaFiz, int stan)
        : base(tytul, autor, kategoria)
    {
        this.cenaFiz = cenaFiz;
        this.stan = stan;
    }

    // Pobieranie Getdetails z klasy bazowej 
    public override string GetDetails()
    {
        string format = FormatKsiazki == 1 ? "twarda okładka" : "miękka okładka";
        string dostepnosc = Stan == 1 ? "dostępna" : "niedostępna";
        return base.GetDetails() + $", Cena: {cenaFiz}, Format: {format}, Stan: {dostepnosc}";
    }

    /*
    public override int UpdateStan()
    {
        return stan;
    }
    */
}
