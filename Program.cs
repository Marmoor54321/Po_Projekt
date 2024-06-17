

//jakieś przykładowe klasy, można usunąć

KsiazkaFizyczna ksiazka1 =  new KsiazkaFizyczna("Wiedźmin", "Andrzej Sapkowski", "Akcja", 29.99f, 4, 1);

KsiazkaFizyczna ksiazka2 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 10, 1);

KsiazkaElektroniczna ksiazka3 =  new KsiazkaElektroniczna("Harry Potter", "J.K. Rowling", "Fantastyka", 29.99f, 1, 1);

KsiazkaElektroniczna ksiazka4 =  new KsiazkaElektroniczna("Harry Potter 2", "J.K. Rowling", "Fantastyka", 99.99f, 1, 0);

KsiazkaFizyczna ksiazka5 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 10, 1);

Uzytkownik marmur = new Uzytkownik("marmur", "123", "marmur@gmail.com", "Bialystok");

List<Ksiazka> ksiazki = [ksiazka1, ksiazka2, ksiazka3];

Zamowienia zamowienie = new Zamowienia(321, ksiazki,0);

List<Ksiazka> ksiazki2 = [ksiazka4, ksiazka5,ksiazka1];

Zamowienia zamowienie1 = new Zamowienia(456, ksiazki2, 0);

/*marmur.DodajZamowienie(zamowienie);

marmur.WyszukajKsiazke(zamowienie, "Wiedź");

marmur.DodajDoKoszyka(ksiazka1);

marmur.ZlozZamowienie();

marmur.WyswietlZamowienia();

*/

List<Zamowienia> listaZamowien = [zamowienie, zamowienie1];

Pracownik mateusz = new Pracownik("mateusz", "123", "mateusz@gmail.com");

mateusz.StanZamowien(listaZamowien);

        