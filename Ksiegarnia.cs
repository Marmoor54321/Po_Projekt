public class Ksiegarnia
{
//niegotowa klasa

    
  private  List<Ksiazka> ksiazki = new List<Ksiazka>();

  private List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();

 

  private List<Pracownik> pracownicy = new List<Pracownik>();

  public Ksiegarnia()
  {
  
  }

  public Ksiegarnia(List<Ksiazka> ksiazki, List<Uzytkownik> uzytkownicy, List<Pracownik> pracownicy)
  {
    this.ksiazki = ksiazki;
    this.uzytkownicy = uzytkownicy;
   
    this.pracownicy = pracownicy;
  }

   public void DodajKsiazke(Ksiazka ksiazka)
    {
        ksiazki.Add(ksiazka);
    }

    public void DodajUzytkownika(Uzytkownik uzytkownik)
    {
        uzytkownicy.Add(uzytkownik);
    }

   
    public void DodajPracownika(Pracownik pracownik)
    {
        pracownicy.Add(pracownik);
    }

    public List<Ksiazka> PobierzKsiazki()
    {
        return ksiazki;
    }

    public List<Uzytkownik> PobierzUzytkownikow()
    {
        return uzytkownicy;
    }



    public List<Pracownik> PobierzPracownikow()
    {
      return pracownicy;
    }

    public void WypiszKsiazki()
    {
      for(int i=0; i<ksiazki.Count(); i++)
      {
        if(ksiazki[i] is KsiazkaElektroniczna ke)
                {

                    Console.WriteLine($"[{i+1}]Tytul: {ke.Tytul}, autor: {ke.Autor}, kategoria:{ke.Kategoria}, cena: {ke.CenaEle}. typ: elektroniczna, stan: {ke.Stan}.");
                }
                else if(ksiazki[i] is KsiazkaFizyczna kf)
                {
      
                    Console.WriteLine($"[{i+1}]Tytul: {kf.Tytul}, autor: {kf.Autor}, kategoria: {kf.Kategoria}, cena: {kf.CenaFiz}, typ: fizyczna, stan: {kf.Stan}.");
                }
      }
    }


}