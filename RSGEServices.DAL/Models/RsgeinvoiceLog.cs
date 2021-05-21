using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class RsgeinvoiceLog
    {
        public int Id { get; set; }
        public string RsgeinvoiceId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateChanged { get; set; }
    }
}
