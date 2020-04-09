using System;
using System.Collections.Generic;
using System.Text;

namespace QzBlazor.Models
{
    public class Printer
    {
        public string Name { get; set; }
        public string Driver { get; set; }
        public bool Default { get; set; }
        public int Density { get; set; }
    }
}
