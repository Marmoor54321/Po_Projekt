using System;
using System.Collections.Generic;
using System.IO;

public static class DataHelper
{
    public static void SaveKsiazkiToFile(string filePath, List<Ksiazka> ksiazki)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var ksiazka in ksiazki)
            {
                string linia_ksiazka = ConvertKsiazkaToString(ksiazka) ?? throw new NullReferenceException("Blad przy zapisie, ksiazka nie istnieje");
                writer.WriteLine(linia_ksiazka);
            }
        }
    }

    public static void SaveUzytkownicyToFile(string filePath, List<Uzytkownik> uzytkownicy)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var uzytkownik in uzytkownicy)
            {
                string linia_uzytkownik = uzytkownik.ToCsvString();
                writer.WriteLine(linia_uzytkownik);
            }
        }
    }

    private static string? ConvertKsiazkaToString(Ksiazka ksiazka)
    {
        if (ksiazka is KsiazkaElektroniczna ke)
        {
            return $"Elektroniczna,{ke.Tytul},{ke.Autor},{ke.Kategoria},{ke.CenaEle},{ke.FormatKsiazki},{ke.Stan}";
        }
        else if (ksiazka is KsiazkaFizyczna kf)
        {
            return $"Fizyczna,{kf.Tytul},{kf.Autor},{kf.Kategoria},{kf.CenaFiz},{kf.FormatKsiazki},{kf.Stan}";
        }
        return null;
    }
}
