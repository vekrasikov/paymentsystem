using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class autopayment
    {
        public int id_autopayment { get; set; }
        public int sender_id { get; set; }
        public int recipient_id { get; set; }
        public double sum { get; set; }
        public string comm { get; set; }
        public DateTime date_payment { get; set; }
        public int autopayment_range_id { get; set; }
        public bool freezing { get; set; }

        public virtual autopayment_range autopayment_range_ { get; set; }
        public virtual Acc recipient_ { get; set; }
        public virtual Acc sender_ { get; set; }
    }
}
