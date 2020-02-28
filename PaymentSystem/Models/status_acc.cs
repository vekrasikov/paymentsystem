using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class status_acc
    {
        public status_acc()
        {
            Acc = new HashSet<Acc>();
        }

        public int id_status_acc { get; set; }
        public string name { get; set; }

        public virtual ICollection<Acc> Acc { get; set; }
    }
}
