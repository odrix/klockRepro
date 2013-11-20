using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class  Word
    {
        public Word(int index, int length)
        {
            Index = index;
            Length = length;
        }

        public int Index { get; private set; }
        public int Length { get; private set; }
    }
}
