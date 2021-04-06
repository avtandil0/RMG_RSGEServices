using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class Amutak
    {
        public int Id { get; set; }
        public short? Bkjrcode { get; set; }
        public string Periode { get; set; }
        public string Dagbknr { get; set; }
        public string Volgnr5 { get; set; }
        public double Beginsaldo { get; set; }
        public double Eindsaldo { get; set; }
        public string Bkstnr { get; set; }
        public string Oms25 { get; set; }
        public DateTime? Datum { get; set; }
        public string Debnr { get; set; }
        public string Crdnr { get; set; }
        public double Bedrag { get; set; }
        public string Valcode { get; set; }
        public double Koers { get; set; }
        public double ValBdr { get; set; }
        public string Weeknummer { get; set; }
        public string Transreknr { get; set; }
        public string Transper { get; set; }
        public string Betaalref { get; set; }
        public string Betwijze { get; set; }
        public string Betcond { get; set; }
        public string Kredbep { get; set; }
        public double Bdrkredbep { get; set; }
        public double Bdrkredbp2 { get; set; }
        public DateTime? Vervdatfak { get; set; }
        public DateTime? Vervdatkrd { get; set; }
        public DateTime? Vervdtkrd2 { get; set; }
        public double Percentag { get; set; }
        public double Percentag2 { get; set; }
        public double GrekBdr { get; set; }
        public byte Storno { get; set; }
        public string MatchFakt { get; set; }
        public string Reknr { get; set; }
        public string Oorsprong { get; set; }
        public string Banksubtyp { get; set; }
        public byte StructM { get; set; }
        public string BtwNummer { get; set; }
        public string AdresCd { get; set; }
        public string AdresNr { get; set; }
        public DateTime? Afldat { get; set; }
        public string Guids { get; set; }
        public string Status { get; set; }
        public string Docnumber { get; set; }
        public DateTime? Docdate { get; set; }
        public string Entryorigin { get; set; }
        public int DelResIdentry { get; set; }
        public byte Crdnote { get; set; }
        public DateTime Syscreated { get; set; }
        public string MatchNr { get; set; }
        public int Syscreator { get; set; }
        public int? Amktext { get; set; }
        public DateTime Sysmodified { get; set; }
        public double BedrVvaf1 { get; set; }
        public double BedrVvaf2 { get; set; }
        public int Sysmodifier { get; set; }
        public Guid Sysguid { get; set; }
        public double BedrVvaf3 { get; set; }
        public byte[] Timestamp { get; set; }
        public double BedrVvaf4 { get; set; }
        public double BedrVvaf5 { get; set; }
        public double Wisselkrs { get; set; }
        public string Kstplcode { get; set; }
        public string Kstdrcode { get; set; }
        public string Faktuurnr { get; set; }
        public Guid? DocumentId { get; set; }
        public Guid? DocAttachmentId { get; set; }
        public Guid? CmpWwn { get; set; }
        public string Project { get; set; }
        public byte BlockOutstandingItem { get; set; }
        public Guid? Orderdebtor { get; set; }
        public string Bankacc { get; set; }
        public string Entrytype { get; set; }
        public string Freefield1 { get; set; }
        public string Freefield2 { get; set; }
        public string Freefield3 { get; set; }
        public double? Freefield4 { get; set; }
        public double? Freefield5 { get; set; }
        public string CashRegisterAccount { get; set; }
        public string Selcode { get; set; }
        public short? Division { get; set; }
    }
}
