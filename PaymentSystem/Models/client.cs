using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class client
    {
        public client()
        {
            Acc = new HashSet<Acc>();
            request = new HashSet<request>();
        }

        public int id_client { get; set; }
        public string fio { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string passport_s { get; set; }
        public string passport_n { get; set; }
        public bool verification { get; set; }

        public virtual ICollection<Acc> Acc { get; set; }
        public virtual ICollection<request> request { get; set; }
    }
}
