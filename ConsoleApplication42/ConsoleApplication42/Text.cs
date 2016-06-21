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

namespace ConsoleApplication42
{
    class Text
    {
        public List<string> sentencesCollection;
        public List<string> wordsCollection;
        private double length;
        public string result;

        public void SecondPathProgramm()
        {
            var webClient = new WebClient();

            webClient.Encoding = Encoding.GetEncoding(1251);
            var textStart = webClient.DownloadString(
                 "http://a-karenina.ru/files/book.txt");
                    

            foreach (var item in Rang(textStart).Take(10))
            {
                result += string.Format("{0} - {1}", item.Value, item.Importance) +Environment.NewLine;
            }
            Console.WriteLine(result);
        }

        
        //разбивка текста на предлoжения
        public List<string> Sentences(string text)
        {
            List<string> sentence = new List<string>();
            var regex = new Regex("[A-Z А-Я].*?(?=[.!?])");
            sentence =
               regex.Matches(text)
                   .OfType<Match>()
                   .Select(match => match.Value)
                   .ToList();
            
            return sentence;
        }

        //разбика предложений на слова
        public List<string> Words(string text)
        {
            List<string> words = new List<string>();
            var regex = new Regex("\\w+?\\b");

            words = regex.Matches(text)
                .OfType<Match>()
                .Select(s => s.Value)
                .Select(s => s.Trim())
                .Select(s => s.ToLower())
                .GroupBy(s => s)
                .Select(s => s.Key)
                .ToList();
            ;
            return words;
        }

        //рассчет idf
        public double CalculateIDF(string word)
        {
            var sentenceCount = sentencesCollection.Count;

            var wordCount = sentencesCollection
                .Count(s => s.ToLower().Contains(word));

            var result =
                Math.Log10((sentenceCount * 1.0 - wordCount + 0.5) / (wordCount + 0.5));

            return result;
        }

        public void CalculateLenght(string Text)
        {
            wordsCollection = Words(Text);
            sentencesCollection = Sentences(Text);
             length = Text.Length * 1.0 / this.sentencesCollection.Count;
            
        }

        public double Formula(string word, string sentence)
        {
            double wordFrequency = FrequencyWordsSentence(word, sentence);
            int sentenceCount = Words(sentence).Count;
            
            double result =
                (wordFrequency * (2.0 + 1)) /
                (wordFrequency + 2.0 * (1 - 0.75 + 0.75 * sentenceCount / length));

            return result;
        }


        public List<ValueResults> Calculate()
        {
            List<ValueResults> result = new List<ValueResults>();

            foreach (var sentence in sentencesCollection)
            {
                double score = 0;

                foreach (var word in this.wordsCollection)
                {
                    score += Formula(word, sentence) * CalculateIDF(word);
                }

                result.Add(new ValueResults(sentence, score));
            }

            return result;
        }

        private IEnumerable<ValueResults> Rang(string Text)
        {
            this.CalculateLenght(Text);
            var result = Sort(Calculate());

            return result;
        }

        private List<ValueResults> Sort(List<ValueResults> result)
        {
            return result
                .OrderByDescending(r => r.Importance)
                .ToList();
        }

        //частота слов в предложении
        private double FrequencyWordsSentence(string word, string text)
        {
            var Word = this.Words(text);
            if (Word.Contains(word))
            {
                var count = Word
                    .Select(w => w.Equals(word))
                    .Count();

                return count * 1.0 / Word.Count;
            }
            else
            {
                return 0;
            }
        }

    }
}