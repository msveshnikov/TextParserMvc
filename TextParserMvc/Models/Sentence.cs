using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextParserMvc.Models
{
    public class Sentence
    {
        private List<string> words;

        public List<string> Words
        {
            get { return words.OrderBy(x => x.ToLower()).ToList(); }
            set { this.words = value; }
        }
    }
}
