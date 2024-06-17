using System;

public class Ksiazka
{
//gotowa klasa
    public string tytul { get; set; }
    public string autor { get; set; }
    public string kategoria { get; set; }

    public Ksiazka(string tytul, string autor, string kategoria)
    {
        this.tytul = tytul;
        this.autor = autor;
        this.kategoria = kategoria;
    }

    public virtual string GetDetails()
    {
        return $"Tytul: {tytul}, Autor: {autor}, Kategoria: {kategoria}";
    }

    public virtual int UpdateStan()
    {
        // Trzeba wypełnić logikę aktualizacji stanu książki  (!!!)
        return 0;
    }
}





  