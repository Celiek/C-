using System;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

//thumb vtop inlblk rel tdnone linkWithHash scale4 detailsLinkPromoted  do szukania


namespace Olx_scraper
{
    class Program
    {
        static void Main(string[] args)
        {   //inicjalizacja zmiennych
            string przedmiot;
            string strona ="/?page=";
            string wynik = "https://www.olx.pl/oferty/q-";
            int strony=0;


            //przedmiot wyszukiwań
            Console.WriteLine("Podaj nazwe : ");
            przedmiot = Console.ReadLine();
            wynik +=przedmiot;

            //przeszukiwanie n stron z ogłoszeniami
            Console.WriteLine("Podaj ilosc stron do przeszukania: ");
            strony = Convert.ToInt32(Console.ReadLine());

            
            int pomocnicza = 0;

        do{

                //ładowanie strony
                wynik += strona +=pomocnicza;
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc = web.Load(wynik);

            foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//a[contains(@class, 'thumb vtop')]"))
           {
               HtmlAttribute att =link.Attributes["href"];
                if(att.Value.Contains("#"))
                {
                    string[] substring = att.Value.Split('#');
                    Console.ForegroundColor = ConsoleColor.Blue; 
                    Console.WriteLine(substring[0]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(att.Value);
                    
                }

           }
           pomocnicza++;
        }
        while(pomocnicza <= strony);

        /*
        //strefa testów
        HtmlWeb olx = new HtmlWeb();
        //  HtmlAgilityPack.HtmlDocument olx = new HtmlAgilityPack.HtmlDocument();
        var htmlDoc = web.Load(wynik += strona);
        var olxwynik = htmlDoc.DocumentNode.SelectSingleNode("//a[contains(@class, 'thumb vtop')]");
        Console.WriteLine("Przerwa");
         //  olx.Attributes["href"];

        Console.WriteLine(olxwynik.Name + olxwynik.OuterHtml);
        */
        Console.ReadLine();

        }

       
    }
}
