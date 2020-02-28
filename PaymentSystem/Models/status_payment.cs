using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class status_payment
    {
        public status_payment()
        {
            payment_history = new HashSet<payment_history>();
        }

        public int id_status_payment { get; set; }
        public string name { get; set; }

        public virtual ICollection<payment_history> payment_history { get; set; }
    }
}
