using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.BLL.Models
{
    public class InvoiceModel
    {
        public string id { get; set; }
        public string rowOrder { get; set; }
        public int ID { get; set; }
        public int STATUS { get; set; }
        public string PersonalId { get; set; }
        public string WAS_REF { get; set; }
        public string F_SERIES { get; set; }
        public string F_NUMBER { get; set; }
        public DateTime REG_DT { get; set; }
        public DateTime OPERATION_DT { get; set; }
        public string S_USER_ID { get; set; }
        public string B_S_USER_ID { get; set; }
        public string SA_IDENT_NO { get; set; }
        public string ORG_NAME { get; set; }
        public string TANXA { get; set; }
        public string VAT { get; set; }
        public string K_ID { get; set; }
       
    }
}
