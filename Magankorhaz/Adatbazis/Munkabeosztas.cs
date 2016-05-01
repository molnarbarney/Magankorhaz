using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    public class Munkabeosztas
    {
        public int Id { get; set; }
        public bool Hetfo { get; set; }
        public bool Kedd { get; set; }
        public bool Szerda { get; set; }
        public bool Csutortok { get; set; }
        public bool Pentek { get; set; }
        public bool Szombat { get; set; }
        public bool Vasarnap { get; set; }
    }
}