namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Programmiere das Spiel Hangman. User 1 soll ein Wort eingeben.
            //User 2 muss danach eine Eingabe machen entweder für einen Buchstaben oder das gesuchte Wort.
            //User 2 Gewinnt wenn er entweder alle Buchstaben oder das richte Wort erraten hat.
            //Ansonsten baut sich der Galgen auf mit folgender Ausgabe als Finale:

            //
            //"  ======||  "
            //"  |     ||  "
            //"  O     ||  "
            //" -x-    ||  "
            //"  x     ||  "
            //" | |    ||  "
            //"        ||  "
            //"============"
            //
            //Ist der Galgen fertig aufgebaut hat User 2 Verloren und User 1 Gewinnt 
            //Am Ende soll eine weitere Spielrunde angeboten werden.


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player One , gib ein Wort ein:");
                string wort = Console.ReadLine().ToLower();
                Console.Clear();

                string geraten = new string('_', wort.Length);
                int falscheVersuche = 0;

                while (falscheVersuche < 6 && geraten != wort)
                {
                    Console.WriteLine($"Wort: {geraten}");
                    Console.WriteLine($"Falsche Versuche: {falscheVersuche}/6");
                    Console.WriteLine("Player Two, rate einen Buchstaben oder das ganze Wort:");
                    string eingabe = Console.ReadLine().ToLower();

                    if (eingabe == wort)
                    {
                        geraten = wort;
                    }
                    else if (eingabe.Length == 1 && wort.Contains(eingabe))
                    {
                        for (int i = 0; i < wort.Length; i++)
                        {
                            if (wort[i] == eingabe[0])
                            {
                                geraten = geraten.Remove(i, 1).Insert(i, eingabe);
                            }
                        }
                    }
                    else
                    {
                        falscheVersuche++;
                        Console.WriteLine("Falsch!");
                    }
                }

                if (geraten == wort)
                {
                    Console.WriteLine($"Glückwunsch! Das Wort war: {wort}");
                }
                else
                {
                    Console.WriteLine($"Verloren! Das Wort war: {wort}");
                }

                Console.WriteLine("Nochmal spielen? (ja/nein)");
                if (Console.ReadLine().ToLower() != "ja") break;
            }

        }
    }
}