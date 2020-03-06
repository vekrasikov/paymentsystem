using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class type_acc
    {
        public type_acc()
        {
            Acc = new HashSet<Acc>();
            request = new HashSet<request>();
        }

        public int id_type_acc { get; set; }
        public string name { get; set; }

        public virtual ICollection<Acc> Acc { get; set; }
        public virtual ICollection<request> request { get; set; }
    }
}
