using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Test_Minuto_Seguro.Interfaces;
using Test_Minuto_Seguro.Model;

namespace Test_Minuto_Seguro.Services
{
    public class FormatDataXml : IFormatDataXml
    {
        private readonly List<string> Prep = new List<string>();

        public FormatDataXml()
        {
            var newPrep = "afora|como|conforme|durante|exceto|feito|fora|mediante|menos|salvo|segundo|senao|tirante|visto|seus|minhas|essa|essas|sob|duns|dumas|uma|" +
                          "ante|apos|que|contra|desde|entre|para|perante|sobre|tras|abaixo|acerca|acima|alem|antes|inves|lado|par|apesar|suas|meus|esse|uns|ate|das|" +
                          "atras|atraves|acordo|debaixo|cima|dentro|depois|diante|frente|lugar|graças|perto|causa|entre|umas|minha|esses|com|por|sem|aos|dos|";

            Prep = newPrep.Split("|").ToList();
        }

        public BlogMinutoXml GetWordsHighestRelevanceByPostAndTotal(BlogMinutoXml xml)
        {
            string text;
            var listWords = new List<string>();
            var listItemXml = new List<ItemXml>();
            var itemXml = new ItemXml();
            foreach (var item in xml.Channel.Item.Take(10))
            {
                text = FilterHtmlChars(item.ContentEncoded);
                text = FilterSpaces(text);
                text = FilterAccentuation(text);
                text = FilterSpecialCharsAndNumbers(text);

                listWords = text.Split(" ").ToList();
                listWords = FilterArticlesAndPrep(listWords);

                itemXml = item;
                itemXml.TotalWord = listWords.Count();
                itemXml.CountMostRelevantWords = FilterTopTenWords(listWords);
                listItemXml.Add(itemXml);
            }
            xml.Channel.Item = listItemXml;
            return xml;
        }

        private string FilterHtmlChars(string text)
        {
            Regex regex = new Regex(@"<[^>]*>");
            return regex.Replace(text, "").ToLower();
        }

        private string FilterSpaces(string text)
        {
            Regex regex = new Regex(@"(\s){1,}");
            return regex.Replace(text, " ").ToLower();
        }

        private string FilterSpecialCharsAndNumbers(string text)
        {
            Regex regex = new Regex(@"[^a-zç\s]+?");
            return regex.Replace(text, String.Empty).Trim();
        }
        private string FilterAccentuation(string text) => new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(x => char.GetUnicodeCategory(x) != UnicodeCategory.NonSpacingMark)
                .ToArray());

        private List<string> FilterArticlesAndPrep(List<string> words) => words.Where(x => x.Length > 2 && !Prep.Contains(x)).ToList();

        private List<Words> FilterTopTenWords(List<string> words)
        {
            var listWord = (from p in words.OrderBy(x => x)
                    group p by p into g
                    select new Words { Word = g.Key, Count = g.Count() }
                    ).OrderByDescending(x => x.Count).Take(10).ToList();

            return listWord;
        }

    }
}
