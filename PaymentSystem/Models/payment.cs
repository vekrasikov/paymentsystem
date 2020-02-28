using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class payment
    {
        public payment()
        {
            payment_history = new HashSet<payment_history>();
        }

        public int id_payment { get; set; }
        public int sender_id { get; set; }
        public int recipient_id { get; set; }
        public double sum { get; set; }
        public string comm { get; set; }

        public virtual Acc recipient_ { get; set; }
        public virtual Acc sender_ { get; set; }
        public virtual ICollection<payment_history> payment_history { get; set; }
    }
}
