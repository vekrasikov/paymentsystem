using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class payment_history
    {
        public int id_payment_history { get; set; }
        public int payment_id { get; set; }
        public int status_payment_id { get; set; }
        public DateTime date_check { get; set; }
        public string rejection { get; set; }

        public virtual payment payment_ { get; set; }
        public virtual status_payment status_payment_ { get; set; }
    }
}
