using System;

namespace AccountServices.Domain.Entities
{
    public class Account
    {
        public Guid Guid { get; set; }
        public string HolderAccountName { get; set; }
        public double ValueBalance { get; set; }
        public double ValueLimit { get; set; }
        public bool Blocked { get; set; }

        public double GetTotalAmount()
        {
            return ValueBalance + ValueLimit;
        }

        public bool IsValid() =>
         !string.IsNullOrWhiteSpace(HolderAccountName);

    }
}
