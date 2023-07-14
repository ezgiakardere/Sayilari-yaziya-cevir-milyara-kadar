using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    static void Main()
    {
        while (true)
        {
            int sayi, i = 0;
            do
            {
                Console.WriteLine("\nSayıyı gir: ");
                sayi = Convert.ToInt32(Console.ReadLine());

                while (sayi > 1000000000 || sayi < 0)
                {
                    Console.WriteLine("Hatalı sayı girdiniz.Tekrar girin");
                    Console.ReadKey();
                    Console.WriteLine("Sayıyı gir:");
                    sayi = Convert.ToInt32(Console.ReadLine());
                }
                break;
            } while (i == 1);


            string[] grup = { "", " bin", " milyon", "" };
            string[] birlik = { "", " bir", " iki", " üç", " dört", " beş", " altı", " yedi", " sekiz", " dokuz" };
            string[] onluk = { "", " on", " yirmi", " otuz", " kırk", " elli", " altmış", " yetmiş", " seksen", " doksan" };
            if (sayi == 0)
            {
                Console.Write("Sıfır");
            }
            string words = "";
            int grupNo = 0;

            while (sayi > 0)
            {
                int grupDegeri = sayi % 1000;
                sayi /= 1000;
                if (grupDegeri == 0)
                {
                    grupNo++;
                    continue;
                }
                string grupWords = "";

                if ((grupDegeri / 100) > 0)
                {
                    if (grupDegeri / 100 == 1)
                    {
                        grupWords += "yüz";
                    }
                    else
                    {
                        grupWords += birlik[grupDegeri / 100] + " yüz";
                    }
                    grupDegeri -= 100 * (grupDegeri / 100);
                }

                if (grupDegeri > 0)
                {
                    if (grupWords.Length != 0)
                        grupWords += " ";

                    if (grupDegeri < 10)
                    {
                        if (grupNo == 0 || grupDegeri != 1)
                            grupWords += birlik[grupDegeri];
                    }
                    else if (grupDegeri < 100)
                    {
                        grupWords += onluk[grupDegeri / 10];
                        if ((grupDegeri % 10) > 0)
                            grupWords += " " + birlik[grupDegeri % 10];
                    }
                }

                grupWords += grup[grupNo];

                if (words.Length != 0)
                    words = grupWords + " " + words;
                else
                    words = grupWords;

                grupNo++;
            }

            Console.WriteLine(words);
        }
    }
}
