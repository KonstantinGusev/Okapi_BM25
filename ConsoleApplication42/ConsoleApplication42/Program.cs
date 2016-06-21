using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using ConsoleApplication42;

namespace ConsoleApplication144
{

    class Program
    {
        static void Main(string[] args)
        {

            Text text = new Text();
            text.SecondPathProgramm();

            /// "Анна Каренина"
            /// 1- этап
            //List<string> words = new List<string>();
            //var webClient = new WebClient();
            
            //webClient.Encoding = Encoding.GetEncoding(1251);
            //var text = webClient.DownloadString(
            //    "http://a-karenina.ru/files/book.txt");

           

          
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

