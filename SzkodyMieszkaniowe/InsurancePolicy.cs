using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkodyMieszkaniowe
{
    public  class InsurancePolicy
    {
        public  Guid Id { get; private set; }
        public  DateTime ExpiryDate { get; private set; }
        public  DateTime CreateAt { get; private set; }

        public InsurancePolicy()
        {
            
        }
        public InsurancePolicy(Guid id, DateTime expiryDate)
        {
            Id = id;
            ExpiryDate = expiryDate;
            CreateAt = DateTime.UtcNow;
        }
        public  void SetExpiryDate(DateTime expiryDate)
        {
            if (ExpiryDate == expiryDate)
            {
                return;
            }
            ExpiryDate = expiryDate;
        }

        public  bool IsValid()
        {
            if (ExpiryDate >= DateTime.Today)
            {
                return true;
            }

            return false;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
