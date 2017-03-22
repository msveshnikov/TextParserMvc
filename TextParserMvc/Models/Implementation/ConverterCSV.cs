using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextParserMvc.Models
{
    public class ConverterCSV : IConvert
    {
        public string Convert(Text text)
        {
            int maxWords = text.Sentences.OrderByDescending(w => w.Words.Count).First().Words.Count;
            List<string> lines = new List<string>();

            string header = "";
            for (int i = 1; i <= maxWords; i++)
            {
                header += ", Word " + i;
            }
            lines.Add(header);

            for (int i = 1; i <= text.Sentences.Count; i++)
            {
                lines.Add("Sentence " + i + ", " + String.Join(", ", text.Sentences[i - 1].Words));
            }

            return String.Join("\r\n", lines);
        }
    }
}