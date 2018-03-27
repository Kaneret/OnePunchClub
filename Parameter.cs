using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePunchClub
{
    public class Parameter
    {
        public Parameter(int kol)
        {
            maximum = kol;
            quanity = kol;
        }

        public Parameter(int max, int quan)
        {
            maximum = max;
            quanity = quan;
        }

        private int maximum;
        private int quanity;

        public void RestoreQuanity(double percent)
        {
            if (quanity < maximum) quanity += (int)(maximum * percent);
            if (quanity > maximum) quanity = maximum;
        }

        public void DecreaseQuanity(int wane)
        {
            if (quanity > 0) quanity -= wane;
            if (quanity < 0) quanity = 0;
        }

        public void DecreaseQuanity(double percent)
        {
            if (quanity > 0) quanity -= (int)(maximum * percent);
            if (quanity < 0) quanity = 0;
        }

        public int GetMaximum() => this.maximum;

        public void SetMaximum(int kol) { this.maximum = kol; }

        public int GetQuanity() => this.quanity;

        public void SetQuanity(int kol) { this.quanity = kol; }
    }
}
