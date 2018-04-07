using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class Characteristic
    {
        public Characteristic(int value, int maxBar, int quanBar)
        {
            this.value = value;
            bar = new Parameter(maxBar, quanBar);
        }

        public int value;
        public Parameter bar;
        //public int timer;
    }
}
