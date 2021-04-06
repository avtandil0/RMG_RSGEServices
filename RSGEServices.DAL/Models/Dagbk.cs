using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class Dagbk
    {
        public int Id { get; set; }
        public string Dagbknr { get; set; }
        public string Oms250 { get; set; }
        public string Oms251 { get; set; }
        public string Oms252 { get; set; }
        public string Oms253 { get; set; }
        public string Oms254 { get; set; }
        public string Afk { get; set; }
        public string TypeDgbk { get; set; }
        public string BtwAfh { get; set; }
        public string Banknr { get; set; }
        public byte Blokbkst { get; set; }
        public byte Chckeinds { get; set; }
        public byte Blokdat { get; set; }
        public string Pstbnknr { get; set; }
        public string Reknr { get; set; }
        public string DefReknr { get; set; }
        public string RekBetow { get; set; }
        public string Valcode { get; set; }
        public byte Dagkoers { get; set; }
        public byte Wijzval { get; set; }
        public double Boeksaldo { get; set; }
        public double Verwsaldo { get; set; }
        public string Lbkstnr { get; set; }
        public int Lverwnr { get; set; }
        public string Scecode { get; set; }
        public byte Sceaction { get; set; }
        public string Crednota { get; set; }
        public string Debcrd { get; set; }
        public byte Blokkeer { get; set; }
        public byte Handmatig { get; set; }
        public string TypeTrans { get; set; }
        public string LbkstOntv { get; set; }
        public string LbkstUitg { get; set; }
        public double SaldoRec { get; set; }
        public string VolgnrRec { get; set; }
        public DateTime? DatumRec { get; set; }
        public byte Wisselmem { get; set; }
        public byte PettyCash { get; set; }
        public byte Projdb { get; set; }
        public double Kredlimiet { get; set; }
        public string RekInc { get; set; }
        public byte Docnumber { get; set; }
        public byte Docdate { get; set; }
        public byte BlockOutstandingItem { get; set; }
        public string Freefield1 { get; set; }
        public string Freefield2 { get; set; }
        public string Freefield3 { get; set; }
        public string Freefield4 { get; set; }
        public string Freefield5 { get; set; }
        public string Freefield6 { get; set; }
        public string Freefield7 { get; set; }
        public double Freefield8 { get; set; }
        public double Freefield9 { get; set; }
        public double Freefield10 { get; set; }
        public double Freefield11 { get; set; }
        public double Freefield12 { get; set; }
        public double Freefield13 { get; set; }
        public DateTime? Freefield14 { get; set; }
        public DateTime? Freefield15 { get; set; }
        public DateTime? Freefield16 { get; set; }
        public byte Freefield17 { get; set; }
        public byte Freefield18 { get; set; }
        public byte Freefield19 { get; set; }
        public byte Freefield20 { get; set; }
        public DateTime Syscreated { get; set; }
        public int Syscreator { get; set; }
        public DateTime Sysmodified { get; set; }
        public int Sysmodifier { get; set; }
        public Guid Sysguid { get; set; }
        public byte[] Timestamp { get; set; }
        public byte UseIntercompany { get; set; }
        public short? Division { get; set; }
        public string TaxDate { get; set; }
    }
}
