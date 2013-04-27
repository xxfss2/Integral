using System;
using System.Collections.Generic;
using System.Text;

namespace integral.Action
{
    public class JifenChange
    {
        public int Id { get; set; }
        public string QQ { get; set; }
        public JifenChangeType Type { get; set; }
        public bool IsAdd { get; set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }
        public string FromQQ { get; set; }
    }
}
