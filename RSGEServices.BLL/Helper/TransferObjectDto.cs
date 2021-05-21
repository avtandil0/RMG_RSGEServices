using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.BLL.Helper
{
    public class TransferObjectDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Dagbknr { get; set; }
        public string Comment { get; set; }
        public string Seller { get; set; }
        public double Amount { get; set; }
        public double Vat { get; set; }
        public string InvoiceNumber { get; set; }
        public string Reknr { get; set; }
        public string KstrlCode { get; set; }
        public string Project { get; set; }
       
    }
}
