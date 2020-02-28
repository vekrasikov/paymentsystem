using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class credit_rate
    {
        public credit_rate()
        {
            Acc = new HashSet<Acc>();
        }

        public int id_credit_rate { get; set; }
        public string name { get; set; }
        public string condition { get; set; }
        public double procent { get; set; }
        public double credit_limit { get; set; }

        public virtual ICollection<Acc> Acc { get; set; }
    }
}
