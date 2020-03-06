using System;
using System.Collections.Generic;

namespace PaymentSystem.Models
{
    public partial class request
    {
        public int id_request { get; set; }
        public double income { get; set; }
        public string place_job { get; set; }
        public int client_id { get; set; }
        public int status_request_id { get; set; }
        public int type_acc_id { get; set; }

        public virtual client client_ { get; set; }
        public virtual status_request status_request_ { get; set; }
        public virtual type_acc type_acc_ { get; set; }
    }
}
