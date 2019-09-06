using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Util
{
    struct BoolStorage
    {
        public int Value { get; set; }

        public bool this[int index]
        {
            get => (Value & index) != 0;
            set => Value = (value) ? Value & index : Value | index;
        }
    }
}