
using System.Collections.Generic;
using System.IO;
using System.Text;

//vytvoření slovníku
var slovnik = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

string cesta = "C:\\Users\\user\\Desktop\\C# 2\\PatydomaciUkol.txt";

bool jeKonec = false;
while (!jeKonec)
{
    Console.WriteLine("1-Přidat slovo");
    Console.WriteLine("2-Smazat slovo");
    Console.WriteLine("3-vypsat překlad");
    Console.WriteLine("4-vypsat všechna slova");
    Console.WriteLine("0-konec");
    int volba = Convert.ToInt32(Console.ReadLine());
    switch (volba)
    {
        case 0:
            File.Delete(cesta);
            jeKonec = true;
            break;
        case 1:
            {
                Console.WriteLine("napiš slovo, které chceš přidat");
                string slovo = Console.ReadLine();
                if (slovnik.ContainsKey(slovo))
                {
                    Console.WriteLine("Toto slovo už ve slovníku je");
                }
                else
                {
                    Console.WriteLine("Napiš překlad: ");
                    string preklad = Console.ReadLine();
                    slovnik.Add(slovo, preklad);
                    File.WriteAllLines(cesta, slovnik.Select(x => "[" + x.Key + " " + x.Value + "]"));

                }
                break;
            }
        case 2:
            {
                Console.WriteLine("Zadej slovo, které chceš smazat");
                string slovo = Console.ReadLine();
                
                if (!slovnik.Remove(slovo))
                {
                    Console.WriteLine("Slovo neexistuje");
                    File.WriteAllLines(cesta, slovnik.Select(x => "[" + x.Key + " " + x.Value + "]"));

                }

                break;
            }
        case 3:
            {
                Console.WriteLine("Zadej slovo, které chceš vypsat");
                string slovo = Console.ReadLine();

                if (slovnik.ContainsKey(slovo))
                {
                    Console.WriteLine(slovo + ": " + slovnik[slovo]);
                }
                else
                {
                    Console.WriteLine("Tohle slovo ve slovníku není");
                }
                break;
            }
        case 4:
            {
                foreach (var item in slovnik)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
                break;
            }
       
    }
}

//Linq slouží k vyhledávání v kolekcích - pole, seznam, slovník (where, select)