using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextParserMvc.Models
{
    public class Sentence
    {
        private List<string> words; // if duplicate words should be removed, use HashSet<string>

        public List<string> Words
        {
            // always return sorted case insensitive
            get { return words.OrderBy(x => x.ToLower()).ToList(); }
            set { this.words = value; }
        }
    }
}
