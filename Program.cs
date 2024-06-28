using System;

class Allat
{
    public static int AktualisEv { get; set; }
    public static int KorHatar { get; set; }
    public string Neve { get; }
    public int SzuletesiEv { get; }
    public int Szepseg { get; set; }
    public int Viselkedese { get; set; }

    public Allat(string neve, int szulEv)
    {
        Neve = neve;
        SzuletesiEv = SzuletesiEv;
    }

    public int Pontszam()
    {
        int kor = AktualisEv - SzuletesiEv;
        if (kor >= KorHatar)
        {
            return 0;
        }
        return (KorHatar - kor) * Szepseg + kor * Viselkedese;
    }

    public override string ToString()
    {
        return $"Név: {Neve}, Pontszám: {Pontszam()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        int aktEv = 2024, korhatar = 10;
        // Az aktuális év és a korhatár megadása
        Allat.AktualisEv = aktEv;
        Allat.KorHatar = korhatar;
        AllatVerseny();
        Console.ReadKey();
    }

    private static void AllatVerseny()
    {
        // az allat nevű változó deklarálása
        Allat allat;
        string nev;
        int szuletesiEv, szepseg, viselkedese;
        int veletlenPontHatar = 10;
        // egy Random példány létrehozása
        Random rand = new Random();
        // számoláshoz szükséges kezdőértékek beállítása
        int osszVersenyzo = 0;
        int osszPont = 0;
        int maxPont = 0;

        Console.WriteLine("Kezdődik a verseny");
        char tovabb = 'i';
        while (tovabb == 'i')
        {
            Console.Write("Az állat neve: ");
            nev = Console.ReadLine();
            Console.Write("születési éve: ");
            while (!int.TryParse(Console.ReadLine(), out szuletesiEv) || szuletesiEv <= 0 || szuletesiEv > Allat.AktualisEv)
            {
                Console.Write("Hibás adat, kérem újra: ");
            }

            // véletlen pontértékek
            szepseg = rand.Next(veletlenPontHatar + 1);
            viselkedese = rand.Next(veletlenPontHatar + 1);

            // Allat példány létrehozása és pontok beállítása
            allat = new Allat(nev, szuletesiEv)
            {
                Szepseg = szepseg,
                Viselkedese = viselkedese
            };

            int pontszam = allat.Pontszam();
            osszPont += pontszam;
            osszVersenyzo++;
            if (pontszam > maxPont)
            {
                maxPont = pontszam;
            }

            Console.WriteLine(allat);
            Console.Write("Van még versenyző? (i/n): ");
            tovabb = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        Console.WriteLine($"össz versenyző: {osszVersenyzo}");
        if (osszVersenyzo > 0)
        {
            Console.WriteLine($"atlag pontszám: {(double)osszPont / osszVersenyzo}");
            Console.WriteLine($"max pontszám: {maxPont}");
        }
    }
}