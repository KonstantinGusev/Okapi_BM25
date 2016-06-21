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
            ///Разделение "Анна Каренина"
            /// 1- этап
            List<string> words = new List<string>();
            var webClient = new WebClient();
            
            webClient.Encoding = Encoding.GetEncoding(1251);
            var text = webClient.DownloadString(
                "http://a-karenina.ru/files/book.txt");

            var regex = new Regex("[A-Z А-Я].*?(?=[.!?])");
            var sentence =
                regex.Matches(text)
                    .OfType<Match>()
                    .Select(match => match.Value)
                    .ToList();

            //второй этап разделение предложений на строки
            var regex2 = new Regex("\\w+?\\b");
            var list =
                sentence
                .OfType<Match>()
                .Select(m => m.Value)
                .Select(m => m.Trim())
                .Select(m => m.ToLower)
                .GroupBy(m => m)
                .Select(m => m.Key)
                .ToList();
            //var list = sentence
            //        .GroupBy(s => s)
            //        .OrderByDescending(g => g.Count())
            //        .Select(g => new
            //        {
            //            //            Word = g.Key,
                        //            P = g.Count() * 1.0 / sentence.Count
                        //        })
                        // .Take(100)
                        //.ToArray();

                        //foreach (var item in list)
                        //{

                        //    Console.WriteLine("{0:F2}%\t{1}", item.P * 100, item.Word);
                        //}
                        //Console.ReadKey();
                    }
    }
}

