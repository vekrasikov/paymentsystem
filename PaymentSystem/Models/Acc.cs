using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class Acc
    {
        public Acc()
        {
            autopaymentrecipient_ = new HashSet<autopayment>();
            autopaymentsender_ = new HashSet<autopayment>();
            paymentrecipient_ = new HashSet<payment>();
            paymentsender_ = new HashSet<payment>();
        }

        public int id_acc { get; set; }
        public double balance_acc { get; set; }
        public int client_id { get; set; }
        public int? credit_rate_id { get; set; }
        public DateTime date_open_acc { get; set; }
        public DateTime date_close_acc { get; set; }
        public int status_acc_id { get; set; }
        public int type_acc_id { get; set; }

        public virtual client client_ { get; set; }
        public virtual credit_rate credit_rate_ { get; set; }
        public virtual status_acc status_acc_ { get; set; }
        public virtual type_acc type_acc_ { get; set; }
        public virtual ICollection<autopayment> autopaymentrecipient_ { get; set; }
        public virtual ICollection<autopayment> autopaymentsender_ { get; set; }
        public virtual ICollection<payment> paymentrecipient_ { get; set; }
        public virtual ICollection<payment> paymentsender_ { get; set; }
    }
}
