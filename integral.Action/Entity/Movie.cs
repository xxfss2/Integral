using System;
using System.Collections.Generic;
using System.Text;

namespace integral.Action
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime PlayDay { get; set; }
    }
}
