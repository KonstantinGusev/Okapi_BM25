using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication144
{
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Serialization;



    class Program
    {
        static void Main(string[] args)
        {
            ///Разделение "Войны и мира на предложения"
            /// 1- этап
            var webClient = new WebClient();
            webClient.Encoding = Encoding.GetEncoding(1251);
            var text = webClient.DownloadString(
                "http://vojnaimir.ru/files/book1.txt");

            var regex = new Regex("[А-Яа-я0-9+\\.+\\s+\\?+\\!+]+(?!\\?\\!\\.\\s+[А-Я]+)");
            var words =
                regex.Matches(text)
                    .OfType<Match>()
                    .Select(match => match.Value)
                    .ToList();

            var list = words
                    .GroupBy(s => s)
                    .OrderByDescending(g => g.Count())
                    .Select(g => new
                    {
                        Word = g.Key,
                        P = g.Count() * 1.0 / words.Count
                    })
                    .Take(100)
                    .ToArray();

            foreach (var item in list)
            {
                Console.WriteLine("{0:F2}%\t{1}", item.P * 100, item.Word);
            }
            Console.ReadKey();
        }
    }
}

