using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextParserMvc.Models
{
    public class Parser
    {
        public Text Parse(string text)
        {
            Text result = new Text();
            result.Sentences = new List<Sentence>();

            var sentences = text.Split(new string[] { ".", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sentences)
            {
                Sentence sentence = new Sentence();
                var words = s.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                sentence.Words = words.ToList();
                result.Sentences.Add(sentence);
            }

            return result;
        }
    }
}