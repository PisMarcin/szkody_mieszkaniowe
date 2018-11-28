using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    class Polisa
    {
        int numer_polisy; public int Numer_Polisy { get { return numer_polisy; } }
        DateTime waznosc_polisy; public DateTime Waznosc_Polisy { get { return waznosc_polisy; } }


        public bool czy_wazna()
        {
            if (waznosc_polisy >= DateTime.Today)
                return true;

            return false;
        }
        public Polisa(int Numer_Polisy, DateTime Waznosc_Polisy)
        {
            this.numer_polisy = Numer_Polisy;
            this.waznosc_polisy = Waznosc_Polisy;
        }
    }
}
