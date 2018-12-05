using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_modul1
{
    public class Policy
    {
        int NoPolicy; 
        public int NoPolicy { get { return NoPolicy; } }
        DateTime ExpiryPolicy; 
        public DateTime ExpiryPolicy { get { return ExpiryPolicy; } }


        public bool IsValid()
        {
            if (ExpiryPolicy >= DateTime.Today)
                return true;

            return false;
        }
        public Polisa(int NoPolicy, DateTime ExpiryPolicy)
        {
            this.NoPolicy = NoPolicy;
            this.ExpiryPolicy = ExpiryPolicy;
        }
    }
}
