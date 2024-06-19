public static class InputExceptionHandler
{
    public static int StrNaInt()
    {
        string wyborStr;
        int wejscie;

        while(true)
            {


                wyborStr = BezpiecznieWczytajString();
                try
                {
                    wejscie = int.Parse(wyborStr);
                    return wejscie;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Wystąpił nieoczekiwany błąd: " + ex.Message);
                    Console.WriteLine("Niepoprawna opcja. Wpisz ponownie: ");
                }
            }
    }

    public static string BezpiecznieWczytajString()
{
    string input = null;

    while (string.IsNullOrEmpty(input))
    {
        try
        {
            
            input = Console.ReadLine()?.Trim(); //trim usuwa puste znaki na końcu i na początku

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Niepoprawna wartość. Wprowadź co najmniej jeden znak.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił wyjątek podczas wczytywania danych: {ex.Message}");
        }
    }

    return input;
}


public static float StrNaFloat()
    {
        float wejscie;
        
        while(!float.TryParse(Console.ReadLine(), out wejscie))
        {
            Console.WriteLine("Niepoprawna wartość. Wpisz ponownie: ");
        }
        return wejscie;
    }
}

