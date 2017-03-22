using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextParserMvc.Models;

namespace TextParserMvc
{
    public interface IConvert
    {
        string Convert(Text text);
    }
}
