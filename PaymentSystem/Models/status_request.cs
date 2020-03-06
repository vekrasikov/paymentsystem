using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class status_request
    {
        public status_request()
        {
            request = new HashSet<request>();
        }

        public int id_status_request { get; set; }
        public string name { get; set; }

        public virtual ICollection<request> request { get; set; }
    }
}
