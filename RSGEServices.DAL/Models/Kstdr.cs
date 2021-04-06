using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class Kstdr
    {
        public int Id { get; set; }
        public string Kstdrcode { get; set; }
        public string Oms250 { get; set; }
        public string Oms251 { get; set; }
        public string Oms252 { get; set; }
        public string Oms253 { get; set; }
        public string Oms254 { get; set; }
        public string Bedrnr { get; set; }
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
        public DateTime Syscreated { get; set; }
        public int Syscreator { get; set; }
        public DateTime Sysmodified { get; set; }
        public int Sysmodifier { get; set; }
        public Guid Sysguid { get; set; }
        public byte[] Timestamp { get; set; }
        public short? Division { get; set; }
    }
}
