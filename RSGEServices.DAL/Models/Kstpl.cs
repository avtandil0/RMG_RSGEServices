using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class Kstpl
    {
        public int Id { get; set; }
        public string Kstplcode { get; set; }
        public string Oms250 { get; set; }
        public string Oms251 { get; set; }
        public string Oms252 { get; set; }
        public string Oms253 { get; set; }
        public string Oms254 { get; set; }
        public short ExtDlnivo { get; set; }
        public double ExtTotvrd { get; set; }
        public double ExtTarief { get; set; }
        public int CcMgr { get; set; }
        public DateTime Syscreated { get; set; }
        public string Bedrnr { get; set; }
        public string Class01 { get; set; }
        public string Class02 { get; set; }
        public int Syscreator { get; set; }
        public DateTime Sysmodified { get; set; }
        public string Class03 { get; set; }
        public int Sysmodifier { get; set; }
        public string Class04 { get; set; }
        public Guid Sysguid { get; set; }
        public byte Enabled { get; set; }
        public string UserField01 { get; set; }
        public string UserField02 { get; set; }
        public string UserField03 { get; set; }
        public string UserField04 { get; set; }
        public string UserField05 { get; set; }
        public double? UserNumber01 { get; set; }
        public double? UserNumber02 { get; set; }
        public double? UserNumber03 { get; set; }
        public double? UserNumber04 { get; set; }
        public double? UserNumber05 { get; set; }
        public byte[] Timestamp { get; set; }
        public short? Division { get; set; }
        public byte UseTransactionAccount { get; set; }
    }
}
