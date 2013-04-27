using System;
using System.Collections.Generic;
using System.Text;

namespace integral.Action
{
    public class Limit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public bool CanRepeater { get; set; }
        public bool NeedIntegral { get; set; }
        public int Integral { get; set; }
        public int ShengjiJiangli { get; set; }
    }
}
