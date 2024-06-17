using System.ComponentModel;

public class Zamowienia
{

//gotowa klasa
    public int idZamowienia;

    public List<Ksiazka> ksiazki = new List<Ksiazka>();

    public int statusZamowienia;

    public Zamowienia(int idZamowienia, List<Ksiazka> ksiazki, int statusZamowienia)
    {
        this.idZamowienia = idZamowienia;
        this.ksiazki = ksiazki;
        this.statusZamowienia = statusZamowienia;
    }

    float suma=0;
    public float Suma()
    {
        foreach(Ksiazka ksiazka in ksiazki)
        {
            if (ksiazka is KsiazkaElektroniczna ksiazkaElektroniczna)
            {
                //1-audiobook, 0-cyfrowa
                if (ksiazkaElektroniczna.formatKsiazki == 1)
                {
                    suma += ksiazkaElektroniczna.cenaEle + 5;
                }
                else 
                {
                    suma += ksiazkaElektroniczna.cenaEle;
                }
            }
            else 
            {
                //1-twarda okładka, 0-miękka okładka
                if (ksiazka is KsiazkaFizyczna ksiazkaFizyczna)
                {
                    if(ksiazkaFizyczna.formatKsiazki == 1)
                    {
                        suma += ksiazkaFizyczna.cenaFiz + 3;
                    }
                    else
                    {
                        suma += ksiazkaFizyczna.cenaFiz;                    
                    }
                }
            }
        }

        return suma;
    }
}