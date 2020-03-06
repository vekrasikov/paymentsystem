using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class autopayment_range
    {
        public autopayment_range()
        {
            autopayment = new HashSet<autopayment>();
        }

        public int id_autopayment_range { get; set; }
        public string name { get; set; }
        public int periodicity { get; set; }

        public virtual ICollection<autopayment> autopayment { get; set; }
    }
}
