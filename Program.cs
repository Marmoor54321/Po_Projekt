

//jakieś przykładowe klasy, można usunąć

KsiazkaFizyczna ksiazka1 =  new KsiazkaFizyczna("Wiedźmin", "Andrzej Sapkowski", "Akcja", 29.99f, 10, 1);

KsiazkaFizyczna ksiazka2 =  new KsiazkaFizyczna("Rok 1984", "George Orwell", "Fantastyka naukowa", 29.99f, 10, 1);

KsiazkaFizyczna ksiazka3 =  new KsiazkaFizyczna("Harry Potter", "J.K. Rowling", "Fantastyka", 29.99f, 10, 1);

Uzytkownik marmur = new Uzytkownik("marmur", "123", "marmur@gmail.com", "Bialystok");

List<Ksiazka> ksiazki = [ksiazka1, ksiazka2, ksiazka3];

Zamowienia zamowienie = new Zamowienia(321, ksiazki,0);

marmur.DodajZamowienie(zamowienie);

marmur.WyszukajKsiazke(zamowienie, "Wiedź");

marmur.DodajDoKoszyka(ksiazka1);

marmur.ZlozZamowienie();

marmur.WyswietlZamowienia();
        