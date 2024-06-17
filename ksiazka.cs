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

    // Dodałem opcję zmiany stanu dla pracownika poprzez bezpośrednią zmianę wartości zamiast korzystania z metody.
    //Wydaje mi się że to jest źle, ale nie chce mi się poprawiać. Może pod koniec robienia projektu poprawimy (pewnie tak zostanie)

    /*
    public virtual int UpdateStan()
    {
        
        return 0;
    }
    */
}





  