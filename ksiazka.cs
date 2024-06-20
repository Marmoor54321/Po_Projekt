using System;

public class Ksiazka
{
//gotowa klasa
    private string tytul; 
    private string autor;
    private string kategoria; 

     public string Tytul
    {
        get { return tytul; }
        set { tytul = value; }
    }

    public string Autor
    {
        get { return autor; }
        set { autor = value; }
    }

    public string Kategoria
    {
        get { return kategoria; }
        set { kategoria = value; }
    }
   
   
    public Ksiazka(string tytul, string autor, string kategoria)
    {
        this.tytul = tytul;
        this.autor = autor;
        this.kategoria = kategoria;
    }

    //nie używałem tej funkcji bo zapomniałem że istnieje (yay)
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





  