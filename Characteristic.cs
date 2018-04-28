using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class Characteristic
    {
        public Characteristic(int value)
        {
            this.value = value;
            bar = new Parameter(100, 0);
        }

        public int value;

        /// <summary>
        /// шкала развития характеристики
        /// </summary>
        public Parameter bar;

        public int GetValue() { return value; }

        public void SetValue(int kol) { value = kol; }

        //public void IncreaseValue(int kol)
        //{
        //    if (kol >= 0) value += kol;
        //    if ((kol < 0) && ((value + 1) < (-kol))) value = 1;
        //    else if
        //}
    }
}
