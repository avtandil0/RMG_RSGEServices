using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RSGEServices.DAL.Models
{
    public partial class _150Context : DbContext
    {
        public _150Context()
        {
        }

        public _150Context(DbContextOptions<_150Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Amutak> Amutak { get; set; }
        public virtual DbSet<Amutas> Amutas { get; set; }
        public virtual DbSet<BankTransactions> BankTransactions { get; set; }
        public virtual DbSet<Btwtrs> Btwtrs { get; set; }
        public virtual DbSet<Cicmpy> Cicmpy { get; set; }
        public virtual DbSet<Dagbk> Dagbk { get; set; }
        public virtual DbSet<Gbkmut> Gbkmut { get; set; }
        public virtual DbSet<Grtbk> Grtbk { get; set; }
        public virtual DbSet<Kstdr> Kstdr { get; set; }
        public virtual DbSet<Kstpl> Kstpl { get; set; }
        public virtual DbSet<Prproject> Prproject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=150;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amutak>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("amutak");

                entity.HasIndex(e => e.Entrytype)
                    .HasName("EntryType");

                entity.HasIndex(e => e.Orderdebtor)
                    .HasName("ix_orderdebtor");

                entity.HasIndex(e => e.Sysguid)
                    .IsUnique();

                entity.HasIndex(e => new { e.Dagbknr, e.Bkstnr })
                    .HasName("PTI_amutak_3");

                entity.HasIndex(e => new { e.Dagbknr, e.Status, e.Sysguid })
                    .HasName("JournalStatusEntryGuid");

                entity.HasIndex(e => new { e.Bkjrcode, e.Dagbknr, e.Bkstnr, e.Id })
                    .HasName("amkbks")
                    .IsUnique();

                entity.HasIndex(e => new { e.Bkjrcode, e.Periode, e.Dagbknr, e.Volgnr5 })
                    .HasName("amutak")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.Crdnr, e.Bkjrcode, e.Periode, e.Id })
                    .HasName("amkcrd")
                    .HasFilter("([crdnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Debnr, e.Bkjrcode, e.Periode, e.Id })
                    .HasName("amkdeb")
                    .HasFilter("([debnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Entryorigin, e.Faktuurnr, e.Debnr, e.Bkstnr })
                    .HasName("IX_amutak_InvoiceProcess");

                entity.HasIndex(e => new { e.Id, e.Dagbknr, e.Crdnr, e.Oms25 })
                    .HasName("PTI_amutak_2");

                entity.HasIndex(e => new { e.Status, e.Bkjrcode, e.Periode, e.Dagbknr, e.Volgnr5, e.Id })
                    .HasName("amksta")
                    .IsUnique();

                entity.HasIndex(e => new { e.Volgnr5, e.Beginsaldo, e.Eindsaldo, e.Bedrag, e.Docdate, e.Dagbknr, e.Status, e.Entrytype })
                    .HasName("PTI_amutak_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdresCd)
                    .HasColumnName("adres_cd")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdresNr)
                    .HasColumnName("adres_nr")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Afldat)
                    .HasColumnName("afldat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amktext).HasColumnName("amktext");

                entity.Property(e => e.Bankacc)
                    .HasColumnName("bankacc")
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.Banksubtyp)
                    .HasColumnName("banksubtyp")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bdrkredbep)
                    .HasColumnName("bdrkredbep")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bdrkredbp2)
                    .HasColumnName("bdrkredbp2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf1)
                    .HasColumnName("bedr_vvaf1")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf2)
                    .HasColumnName("bedr_vvaf2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf3)
                    .HasColumnName("bedr_vvaf3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf4)
                    .HasColumnName("bedr_vvaf4")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf5)
                    .HasColumnName("bedr_vvaf5")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bedrag)
                    .HasColumnName("bedrag")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Beginsaldo)
                    .HasColumnName("beginsaldo")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Betaalref)
                    .HasColumnName("betaalref")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Betcond)
                    .HasColumnName("betcond")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Betwijze)
                    .HasColumnName("betwijze")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bkjrcode).HasColumnName("bkjrcode");

                entity.Property(e => e.Bkstnr)
                    .HasColumnName("bkstnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BlockOutstandingItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.BtwNummer)
                    .HasColumnName("btw_nummer")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CashRegisterAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.CmpWwn).HasColumnName("cmp_wwn");

                entity.Property(e => e.Crdnote)
                    .HasColumnName("crdnote")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Crdnr)
                    .HasColumnName("crdnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dagbknr)
                    .HasColumnName("dagbknr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debnr)
                    .HasColumnName("debnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DelResIdentry)
                    .HasColumnName("DEL_res_identry")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DocAttachmentId).HasColumnName("DocAttachmentID");

                entity.Property(e => e.Docdate)
                    .HasColumnName("docdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Docnumber)
                    .HasColumnName("docnumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Eindsaldo)
                    .HasColumnName("eindsaldo")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Entryorigin)
                    .HasColumnName("entryorigin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Entrytype)
                    .IsRequired()
                    .HasColumnName("entrytype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Faktuurnr)
                    .HasColumnName("faktuurnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield1)
                    .HasColumnName("freefield1")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield2)
                    .HasColumnName("freefield2")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield3)
                    .HasColumnName("freefield3")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield4).HasColumnName("freefield4");

                entity.Property(e => e.Freefield5).HasColumnName("freefield5");

                entity.Property(e => e.GrekBdr)
                    .HasColumnName("grek_bdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Guids)
                    .HasColumnName("guids")
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Koers)
                    .HasColumnName("koers")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Kredbep)
                    .HasColumnName("kredbep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstdrcode)
                    .HasColumnName("kstdrcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstplcode)
                    .HasColumnName("kstplcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MatchFakt)
                    .HasColumnName("match_fakt")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MatchNr)
                    .HasColumnName("match_nr")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oms25)
                    .HasColumnName("oms25")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oorsprong)
                    .HasColumnName("oorsprong")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Orderdebtor).HasColumnName("orderdebtor");

                entity.Property(e => e.Percentag)
                    .HasColumnName("percentag")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Percentag2)
                    .HasColumnName("percentag2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Periode)
                    .HasColumnName("periode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Selcode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Storno)
                    .HasColumnName("storno")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.StructM)
                    .HasColumnName("struct_m")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Transper)
                    .HasColumnName("transper")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Transreknr)
                    .HasColumnName("transreknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValBdr)
                    .HasColumnName("val_bdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Valcode)
                    .HasColumnName("valcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vervdatfak)
                    .HasColumnName("vervdatfak")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdatkrd)
                    .HasColumnName("vervdatkrd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdtkrd2)
                    .HasColumnName("vervdtkrd2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Volgnr5)
                    .HasColumnName("volgnr5")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Weeknummer)
                    .HasColumnName("weeknummer")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Wisselkrs)
                    .HasColumnName("wisselkrs")
                    .HasDefaultValueSql("(0.0)");
            });

            modelBuilder.Entity<Amutas>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("amutas");

                entity.HasIndex(e => e.Bkstnr)
                    .HasName("PTI_amutas_4")
                    .HasFilter("([bkstnr] IS NOT NULL)");

                entity.HasIndex(e => e.CspickItcwdeliveryNoteCwdb)
                    .HasName("CSPickITCWDelNoteOrsrg");

                entity.HasIndex(e => e.CspickItcwinvoiceNumberCwdb)
                    .HasName("CSPickITCWInvoice");

                entity.HasIndex(e => e.Kstplcode)
                    .HasName("ix_amutas_kstplcode")
                    .HasFilter("([kstplcode] IS NOT NULL)");

                entity.HasIndex(e => new { e.Artcode, e.Id })
                    .HasName("amitem")
                    .HasFilter("([artcode] IS NOT NULL)");

                entity.HasIndex(e => new { e.Id, e.DocAttachmentId })
                    .HasName("PTI_amutas_1");

                entity.HasIndex(e => new { e.Id, e.DocumentId })
                    .HasName("PTI_amutas_2");

                entity.HasIndex(e => new { e.Project, e.Id })
                    .HasName("amproj")
                    .IsUnique();

                entity.HasIndex(e => new { e.Dagbknr, e.Valcode, e.Transtype })
                    .HasName("PTI_amutas_3");

                entity.HasIndex(e => new { e.Bkjrcode, e.Dagbknr, e.Bkstnr, e.Id })
                    .HasName("amsdag")
                    .IsUnique();

                entity.HasIndex(e => new { e.Crdnr, e.Bkjrcode, e.Periode, e.Id })
                    .HasName("amscrd")
                    .HasFilter("([crdnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Debnr, e.Bkjrcode, e.Periode, e.Id })
                    .HasName("amsdeb")
                    .HasFilter("([debnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Reknr, e.Bkjrcode, e.Periode, e.Id })
                    .HasName("amsrek")
                    .IsUnique();

                entity.HasIndex(e => new { e.Bkjrcode, e.Periode, e.Dagbknr, e.Volgnr5, e.Regel })
                    .HasName("amutas")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aantal)
                    .HasColumnName("aantal")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.AdresCd)
                    .HasColumnName("adres_cd")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AdresNr)
                    .HasColumnName("adres_nr")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Afldat)
                    .HasColumnName("afldat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amstext).HasColumnName("amstext");

                entity.Property(e => e.Artcode)
                    .HasColumnName("artcode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BankTransactionGuid).HasColumnName("BankTransactionGUID");

                entity.Property(e => e.Bankacc)
                    .HasColumnName("bankacc")
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.Bdrkredbep)
                    .HasColumnName("bdrkredbep")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bdrkredbp2)
                    .HasColumnName("bdrkredbp2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf1)
                    .HasColumnName("bedr_vvaf1")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf2)
                    .HasColumnName("bedr_vvaf2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf3)
                    .HasColumnName("bedr_vvaf3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf4)
                    .HasColumnName("bedr_vvaf4")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BedrVvaf5)
                    .HasColumnName("bedr_vvaf5")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bedrag)
                    .HasColumnName("bedrag")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Betaalref)
                    .HasColumnName("betaalref")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Betcond)
                    .HasColumnName("betcond")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Betwijze)
                    .HasColumnName("betwijze")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bkjrcode).HasColumnName("bkjrcode");

                entity.Property(e => e.Bkstnr)
                    .HasColumnName("bkstnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BkstnrVrz)
                    .HasColumnName("bkstnr_vrz")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BlockOutstandingItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.BtwBdr)
                    .HasColumnName("btw_bdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwCode)
                    .HasColumnName("btw_code")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BtwGrond)
                    .HasColumnName("btw_grond")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwNummer)
                    .HasColumnName("btw_nummer")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Btwvrtnr)
                    .HasColumnName("btwvrtnr")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CashRegisterAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.CmpWwn).HasColumnName("cmp_wwn");

                entity.Property(e => e.CompCode)
                    .HasColumnName("comp_code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Crdnote)
                    .HasColumnName("crdnote")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Crdnr)
                    .HasColumnName("crdnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwdeliveryNoteCwdb)
                    .HasColumnName("CSPickITCWDeliveryNoteCWDB")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwinvoiceNumberCwdb)
                    .HasColumnName("CSPickITCWInvoiceNumberCWDB")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcworsrgIdcwdb).HasColumnName("CSPickITCWOrsrgIDCWDB");

                entity.Property(e => e.Dagbknr)
                    .HasColumnName("dagbknr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debnr)
                    .HasColumnName("debnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocAttachmentId).HasColumnName("DocAttachmentID");

                entity.Property(e => e.Docdate)
                    .HasColumnName("docdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Docnumber)
                    .HasColumnName("docnumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ElectronicInvoiceStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Entryorigin)
                    .HasColumnName("entryorigin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exvalbdr)
                    .HasColumnName("exvalbdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Exvalcode)
                    .HasColumnName("exvalcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Facode)
                    .HasColumnName("facode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Faktuurnr)
                    .HasColumnName("faktuurnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield1)
                    .HasColumnName("freefield1")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield2)
                    .HasColumnName("freefield2")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield3)
                    .HasColumnName("freefield3")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield4).HasColumnName("freefield4");

                entity.Property(e => e.Freefield5).HasColumnName("freefield5");

                entity.Property(e => e.Guids)
                    .HasColumnName("guids")
                    .HasMaxLength(38)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IbtdeliveryNr)
                    .HasColumnName("IBTDeliveryNr")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IntArea)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntDeliveryMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntLandAssembly)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IntLandDestOrig)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntLandIso)
                    .HasColumnName("IntLandISO")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntPort)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntStandardCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntStatNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IntSystem)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransA)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransShipment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransportMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Koers)
                    .HasColumnName("koers")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Koers3)
                    .HasColumnName("koers3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Kredbep)
                    .HasColumnName("kredbep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstdrcode)
                    .HasColumnName("kstdrcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstplcode)
                    .HasColumnName("kstplcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Levverw)
                    .HasColumnName("levverw")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MatchNr)
                    .HasColumnName("match_nr")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NatmovCode)
                    .HasColumnName("natmov_code")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OfficialAmountDc)
                    .HasColumnName("OfficialAmountDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialBasisDc)
                    .HasColumnName("OfficialBasisDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialExchangeRate).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Oms25)
                    .HasColumnName("oms25")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Orderdebtor).HasColumnName("orderdebtor");

                entity.Property(e => e.PayrollSubtype)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Periode)
                    .HasColumnName("periode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pricelist)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Projmutnr)
                    .HasColumnName("projmutnr")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Regel)
                    .HasColumnName("regel")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResId)
                    .HasColumnName("res_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Resperiod)
                    .HasColumnName("resperiod")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Serialnumber)
                    .HasColumnName("serialnumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Shipment)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Storno)
                    .HasColumnName("storno")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxAmount2).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount3).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount4).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount5).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis2).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis3).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis4).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis5).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxCode2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode4)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode5)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transbkjr).HasColumnName("transbkjr");

                entity.Property(e => e.Transsubtype)
                    .HasColumnName("transsubtype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Transtype)
                    .HasColumnName("transtype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValBdr)
                    .HasColumnName("val_bdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.ValbtwBdr)
                    .HasColumnName("valbtw_bdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Valcode)
                    .HasColumnName("valcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Verschil)
                    .HasColumnName("verschil")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vervdatfak)
                    .HasColumnName("vervdatfak")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdatkrd)
                    .HasColumnName("vervdatkrd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdtkrd2)
                    .HasColumnName("vervdtkrd2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Volgnr5)
                    .HasColumnName("volgnr5")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VolgnrPfb)
                    .HasColumnName("volgnr_pfb")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vooruitbet)
                    .HasColumnName("vooruitbet")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Voucher)
                    .HasColumnName("voucher")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Warehouse)
                    .HasColumnName("warehouse")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WarehouseLocation)
                    .HasColumnName("warehouse_location")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Weeknummer)
                    .HasColumnName("weeknummer")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Wisselkrs)
                    .HasColumnName("wisselkrs")
                    .HasDefaultValueSql("(0.0)");
            });

            modelBuilder.Entity<BankTransactions>(entity =>
            {
                entity.HasIndex(e => e.BankChargeLink)
                    .HasName("BankCharge");

                entity.HasIndex(e => e.InvoiceNumber)
                    .HasName("InvoiceNumbers")
                    .HasFilter("([InvoiceNumber] IS NOT NULL)");

                entity.HasIndex(e => e.MatchId)
                    .HasName("ForeignKeyMatch")
                    .HasFilter("([MatchID] IS NOT NULL)");

                entity.HasIndex(e => e.OrderNumber)
                    .HasName("OrderNumber")
                    .HasFilter("([OrderNumber] IS NOT NULL)");

                entity.HasIndex(e => e.SupplierInvoiceNumber)
                    .HasName("IX_SupplierInvoiceNumber")
                    .HasFilter("([SupplierInvoiceNumber] IS NOT NULL)");

                entity.HasIndex(e => e.Sysguid)
                    .HasName("BankTransactionGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.Bedrnr, e.Sysmodified })
                    .HasName("IX_sysmodified");

                entity.HasIndex(e => new { e.Bedrnr, e.Timestamp })
                    .HasName("IX_timestamp");

                entity.HasIndex(e => new { e.InvoiceCode, e.SequenceNumber })
                    .HasName("NonHistoricalInvoice");

                entity.HasIndex(e => new { e.OffsetLedgerAccountNumber, e.EntryNumber })
                    .HasName("PTI_BankTransactions_7");

                entity.HasIndex(e => new { e.Type, e.TransactionNumber })
                    .HasName("TransactionNumber");

                entity.HasIndex(e => new { e.ValueDate, e.OwnBankAccount })
                    .HasName("BankValueDate");

                entity.HasIndex(e => new { e.BatchNumber, e.Type, e.Status })
                    .HasName("BatchNumber");

                entity.HasIndex(e => new { e.DepositDate, e.DepositNumber, e.OwnBankAccount })
                    .HasName("BankDeposit");

                entity.HasIndex(e => new { e.OffsetReference, e.Status, e.Type })
                    .HasName("OffsetReference");

                entity.HasIndex(e => new { e.PaymentType, e.Type, e.Status })
                    .HasName("IX_PaymentType");

                entity.HasIndex(e => new { e.StatementDate, e.StatementNumber, e.OwnBankAccount })
                    .HasName("BankStatement");

                entity.HasIndex(e => new { e.Status, e.Type, e.AmountTc })
                    .HasName("StatusTypeAmountTC");

                entity.HasIndex(e => new { e.AmountDc, e.Type, e.OwnBankAccount, e.Status })
                    .HasName("PTI_BankTransactions_5");

                entity.HasIndex(e => new { e.CreditorNumber, e.InvoiceNumber, e.Type, e.Status })
                    .HasName("CreditorInvoices");

                entity.HasIndex(e => new { e.DebtorNumber, e.InvoiceNumber, e.Type, e.Status })
                    .HasName("DebtorInvoices");

                entity.HasIndex(e => new { e.OffsetBankAccount, e.Type, e.DebtorNumber, e.CreditorNumber })
                    .HasName("OffsetBankAccount");

                entity.HasIndex(e => new { e.Type, e.EntryGuid, e.TransactionType, e.Status })
                    .HasName("PTI_BankTransactions_3");

                entity.HasIndex(e => new { e.CreditorNumber, e.Status, e.Tccode, e.InvoiceNumber, e.EntryNumber })
                    .HasName("PTI_BankTransactions_2");

                entity.HasIndex(e => new { e.DebtorNumber, e.Status, e.Tccode, e.InvoiceNumber, e.EntryNumber })
                    .HasName("PTI_BankTransactions_4");

                entity.HasIndex(e => new { e.OwnBankAccount, e.Type, e.StatementDate, e.Status, e.FileName })
                    .HasName("OwnBankAccount");

                entity.HasIndex(e => new { e.Type, e.InvoiceDate, e.CreditorNumber, e.DebtorNumber, e.Status })
                    .HasName("IX_InvoiceDate");

                entity.HasIndex(e => new { e.TransactionType, e.ValueDate, e.LedgerAccount, e.Tccode, e.AmountTc, e.AmountDc })
                    .HasName("JournalOpenBal");

                entity.HasIndex(e => new { e.CreditorNumber, e.Type, e.MatchId, e.AmountDc, e.Status, e.EntryGuid, e.EntryNumber, e.OffsetLedgerAccountNumber, e.ProcessingDate })
                    .HasName("AP");

                entity.HasIndex(e => new { e.DebtorNumber, e.Type, e.MatchId, e.AmountDc, e.Status, e.EntryGuid, e.EntryNumber, e.OffsetLedgerAccountNumber, e.ProcessingDate })
                    .HasName("AR");

                entity.HasIndex(e => new { e.Tccode, e.AmountTc, e.StatementType, e.StatementNumber, e.Type, e.OwnBankAccount, e.LedgerAccount, e.TransactionType, e.Status, e.ValueDate })
                    .HasName("PTI_BankTransactions_6");

                entity.HasIndex(e => new { e.Id, e.OwnBankAccount, e.Tccode, e.AmountTc, e.OffsetBankAccount, e.OffsetReference, e.InvoiceNumber, e.ValueDate, e.PaymentType, e.OrderNumber, e.PaymentDays, e.Type, e.CreditorNumber, e.Status })
                    .HasName("PTI_BankTransactions_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvanceInvoiceNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AmountDc)
                    .HasColumnName("AmountDC")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AmountTc)
                    .HasColumnName("AmountTC")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Approved).HasColumnType("datetime");

                entity.Property(e => e.Approved2).HasColumnType("datetime");

                entity.Property(e => e.Approver).HasDefaultValueSql("(0)");

                entity.Property(e => e.BatchNumber).HasDefaultValueSql("(0)");

                entity.Property(e => e.Bedrnr)
                    .HasColumnName("bedrnr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Blocked).HasDefaultValueSql("(0)");

                entity.Property(e => e.CntId).HasColumnName("cnt_id");

                entity.Property(e => e.CreditCardAuthCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardResult)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardTransId)
                    .HasColumnName("CreditCardTransID")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CreditorNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DebtorNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DepositDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DocAttachmentId).HasColumnName("DocAttachmentID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EntryNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExchangeRate).HasDefaultValueSql("(1)");

                entity.Property(e => e.ExternalNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraCurrencyAmount).HasDefaultValueSql("(0)");

                entity.Property(e => e.ExtraCurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FileName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.HumanResourceId).HasColumnName("HumanResourceID");

                entity.Property(e => e.ImportAutoMatch)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.InstrumentBank)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InstrumentStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Journalized).HasColumnType("datetime");

                entity.Property(e => e.LedgerAccount)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LinkId).HasColumnName("LinkID");

                entity.Property(e => e.MandateReference)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MatchId).HasColumnName("MatchID");

                entity.Property(e => e.MaturityDays).HasDefaultValueSql("(0)");

                entity.Property(e => e.OfficialAmountDc)
                    .HasColumnName("OfficialAmountDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialBasisDc)
                    .HasColumnName("OfficialBasisDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialExchangeRate).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OffsetAddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetAddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetAddressLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetBankAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetBankCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OffsetBankName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetBankSwiftcode)
                    .HasColumnName("OffsetBankSWIFTCode")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OffsetCity)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OffsetIdentificationNumberBank)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OffsetLedgerAccountNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OffsetName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetPostalCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetReference)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OwnBankAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.OwnBankAccountRef)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.OwnReference).IsUnicode(false);

                entity.Property(e => e.PaymentCondition)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Processed).HasColumnType("datetime");

                entity.Property(e => e.ProcessingDate).HasColumnType("datetime");

                entity.Property(e => e.ReportingDate).HasColumnType("datetime");

                entity.Property(e => e.SequenceNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementDate).HasColumnType("datetime");

                entity.Property(e => e.StatementLineNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.StatementNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.StatementType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SupplierInvoiceNumber)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxInvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.TaxInvoiceNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tccode)
                    .HasColumnName("TCCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TermPercentage).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValueDate).HasColumnType("datetime");

                entity.Property(e => e.Vatcode)
                    .HasColumnName("VATCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Warehouse)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Btwtrs>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("btwtrs");

                entity.HasIndex(e => new { e.CodeIv, e.Id })
                    .HasName("btinvr")
                    .IsUnique();

                entity.HasIndex(e => new { e.CompanyCode, e.Btwtrans })
                    .HasName("btwtrs")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.Creditor, e.CompanyCode })
                    .HasName("ix_creditor_company");

                entity.HasIndex(e => new { e.RekBtwVk, e.Id })
                    .HasName("btwvrk")
                    .IsUnique();

                entity.HasIndex(e => new { e.Reknr, e.Id })
                    .HasName("btwink")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccInvtax)
                    .HasColumnName("acc_invtax")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccInvtcr)
                    .HasColumnName("acc_invtcr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccInvtdb)
                    .HasColumnName("acc_invtdb")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AutofatturaCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BtwReg)
                    .HasColumnName("btw_reg")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.BtwVrij)
                    .HasColumnName("btw_vrij")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BtwVt)
                    .HasColumnName("btw_vt")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Btwlist)
                    .HasColumnName("btwlist")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Btwoms)
                    .HasColumnName("btwoms")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Btwper)
                    .HasColumnName("btwper")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Btwtrans)
                    .HasColumnName("btwtrans")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Calculationbasis)
                    .IsRequired()
                    .HasColumnName("calculationbasis")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.CodeIv)
                    .HasColumnName("code_iv")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CredBtwcd)
                    .HasColumnName("cred_btwcd")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Creditor)
                    .HasColumnName("creditor")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Crednota)
                    .HasColumnName("crednota")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exclus)
                    .HasColumnName("exclus")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvestPer)
                    .HasColumnName("invest_per")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Landcode)
                    .HasColumnName("landcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LevyPer)
                    .HasColumnName("levy_per")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.NonDeductibleAccount)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NonDeductiblePercentage).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Oms300)
                    .HasColumnName("oms30_0")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Oms301)
                    .HasColumnName("oms30_1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Oms302)
                    .HasColumnName("oms30_2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Oms303)
                    .HasColumnName("oms30_3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Oms304)
                    .HasColumnName("oms30_4")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PayPeriod)
                    .HasColumnName("pay_period")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PerpertualService)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PurchaseType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.RekBtwVk)
                    .HasColumnName("rek_btw_vk")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rent)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RoundingScheme)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Taxkey)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Taxsubkey)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Taxtype)
                    .IsRequired()
                    .HasColumnName("taxtype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('V')");

                entity.Property(e => e.Tegreknr)
                    .HasColumnName("tegreknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UseCashSystem)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Vatsection)
                    .HasColumnName("VATSection")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VatsplitPayment).HasColumnName("VATSplitPayment");

                entity.Property(e => e.VattoBeClaimed)
                    .HasColumnName("VATToBeClaimed")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VattoClaimSuspenseGl)
                    .HasColumnName("VATToClaimSuspenseGL")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VattoPaySuspenseGl)
                    .HasColumnName("VATToPaySuspenseGL")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Verlegdbtw)
                    .HasColumnName("verlegdbtw")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Cicmpy>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("cicmpy");

                entity.HasIndex(e => e.ClassificationId)
                    .HasName("cicmpy_ClassificationID")
                    .HasFilter("([ClassificationId] IS NOT NULL)");

                entity.HasIndex(e => e.CmpCode)
                    .HasName("AccountCode")
                    .IsUnique();

                entity.HasIndex(e => e.CmpFadd1)
                    .HasName("cicmpy_cmp_fadd1")
                    .HasFilter("([cmp_fadd1] IS NOT NULL)");

                entity.HasIndex(e => e.CmpFctry)
                    .HasName("IXcountry_cicmpy");

                entity.HasIndex(e => e.CmpFpc)
                    .HasName("cicmpy_cmp_fpc");

                entity.HasIndex(e => e.CmpOrigin)
                    .HasName("cicmpy_cmp_origin");

                entity.HasIndex(e => e.CmpWwn)
                    .HasName("cicmpy")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.Crdnr)
                    .HasName("ix_crdnr")
                    .HasFilter("([crdnr] IS NOT NULL)");

                entity.HasIndex(e => e.Debnr)
                    .HasName("ix_debnr");

                entity.HasIndex(e => e.DivisionCreditorId)
                    .HasName("DivisionCreditor")
                    .HasFilter("([DivisionCreditorID] IS NOT NULL)");

                entity.HasIndex(e => e.DivisionDebtorId)
                    .HasName("DivisionDebtor");

                entity.HasIndex(e => e.Numberfield1)
                    .HasName("cicmpy_numberfield1");

                entity.HasIndex(e => e.Textfield1)
                    .HasName("cicmpy_textfield1");

                entity.HasIndex(e => e.Textfield2)
                    .HasName("cicmpy_textfield2");

                entity.HasIndex(e => e.Textfield3)
                    .HasName("cicmpy_textfield3");

                entity.HasIndex(e => e.Textfield4)
                    .HasName("cicmpy_textfield4");

                entity.HasIndex(e => e.Textfield5)
                    .HasName("cicmpy_textfield5");

                entity.HasIndex(e => e.VatNumber)
                    .HasName("ix_VatNumber")
                    .HasFilter("([VatNumber] IS NOT NULL)");

                entity.HasIndex(e => new { e.CmpTel, e.Id })
                    .HasName("cpix10")
                    .IsUnique();

                entity.HasIndex(e => new { e.CmpType, e.CmpName })
                    .HasName("cicmpy_type_name");

                entity.HasIndex(e => new { e.InvoiceDebtor, e.Administration })
                    .HasName("ix_InvoiceDebtor");

                entity.HasIndex(e => new { e.WebAccessSince, e.ProcessedByBackgroundJob })
                    .HasName("WebAccess");

                entity.HasIndex(e => new { e.CmpAccMan, e.CmpName, e.Id })
                    .HasName("cpix12")
                    .IsUnique();

                entity.HasIndex(e => new { e.CmpFcity, e.CmpName, e.Id })
                    .HasName("cmpix8")
                    .IsUnique();

                entity.HasIndex(e => new { e.CmpName, e.CmpType, e.CmpStatus })
                    .HasName("AccountName");

                entity.HasIndex(e => new { e.CmpParent, e.CmpName, e.Id })
                    .HasName("cpix11")
                    .IsUnique();

                entity.HasIndex(e => new { e.CmpParent, e.CmpStatus, e.CmpType })
                    .HasName("Parent");

                entity.HasIndex(e => new { e.CmpParent, e.CmpStatus, e.Crdcode })
                    .HasName("PTI_cicmpy_2");

                entity.HasIndex(e => new { e.CmpParent, e.CmpStatus, e.Debcode })
                    .HasName("PTI_cicmpy_1");

                entity.HasIndex(e => new { e.CmpReseller, e.CmpName, e.Id })
                    .HasName("cpix17")
                    .IsUnique();

                entity.HasIndex(e => new { e.CmpReseller, e.CmpStatus, e.CmpType })
                    .HasName("Reseller");

                entity.HasIndex(e => new { e.CmpType, e.CmpReseller, e.TypeSince })
                    .HasName("reseller_since");

                entity.HasIndex(e => new { e.SecurityLevel, e.CmpType, e.CmpStatus })
                    .HasName("ix_SecurityLevel_TypeStatus");

                entity.HasIndex(e => new { e.Syscreator, e.CmpType, e.CmpStatus })
                    .HasName("CreatedByStatus");

                entity.HasIndex(e => new { e.Timestamp, e.Administration, e.CmpType })
                    .HasName("ix_timestamp");

                entity.HasIndex(e => new { e.CmpType, e.CmpStatus, e.CmpRating, e.TypeSince })
                    .HasName("cicmpy_rating");

                entity.HasIndex(e => new { e.CmpType, e.SctCode, e.SizCode, e.CmpName })
                    .HasName("cicmpy_type_sector_size_name");

                entity.HasIndex(e => new { e.TypeSince, e.CmpType, e.Administration, e.CmpCode })
                    .HasName("TypeSinceAdminEx");

                entity.HasIndex(e => new { e.Administration, e.CmpType, e.CmpStatus, e.CmpCode, e.CmpName })
                    .HasName("admin_type_status_since");

                entity.HasIndex(e => new { e.Crdcode, e.Crdnr, e.CmpName, e.CmpType, e.CmpStatus })
                    .HasName("ix_crdcode");

                entity.HasIndex(e => new { e.Debcode, e.Debnr, e.CmpName, e.CmpType, e.CmpStatus })
                    .HasName("ix_debcode");

                entity.HasIndex(e => new { e.Id, e.CmpName, e.CmpFadd1, e.CmpFcity, e.CmpFctry, e.Crdnr, e.BankAccountNumber, e.CmpStatus, e.Crdcode })
                    .HasName("PTI_cicmpy_3");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountEmployeeId).HasDefaultValueSql("(0)");

                entity.Property(e => e.AccountRating)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountTypeCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Acknowledge).HasDefaultValueSql("(0)");

                entity.Property(e => e.AddExtraReceiptToOrder)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AddressNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Administration)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('000')");

                entity.Property(e => e.AdministrationReference)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AllowBackOrders).HasDefaultValueSql("(0)");

                entity.Property(e => e.AllowPartialShipment).HasDefaultValueSql("(0)");

                entity.Property(e => e.AllowSubstituteItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.AmountOpen).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.ApplyShippingCharges).HasDefaultValueSql("(0)");

                entity.Property(e => e.Area)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Aspdatabase)
                    .HasColumnName("ASPDatabase")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Aspserver)
                    .HasColumnName("ASPServer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AspwebServer)
                    .HasColumnName("ASPWebServer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AspwebSite)
                    .HasColumnName("ASPWebSite")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AttachUbl).HasColumnName("AttachUBL");

                entity.Property(e => e.Attention).HasDefaultValueSql("(0)");

                entity.Property(e => e.AutoDistribute).HasDefaultValueSql("(0)");

                entity.Property(e => e.AutomaticPayment).HasDefaultValueSql("(1)");

                entity.Property(e => e.AvalaraEntityUseCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BackOrders).HasDefaultValueSql("(0)");

                entity.Property(e => e.Balance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.BalanceCredit).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BalanceDebit).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.BankNumber2)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.BillParent).HasDefaultValueSql("(0)");

                entity.Property(e => e.Blocked).HasDefaultValueSql("(0)");

                entity.Property(e => e.BoelimitAmount)
                    .HasColumnName("BOELimitAmount")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BoemaxAmount)
                    .HasColumnName("BOEMaxAmount")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.CalculatePenaltyInterest).HasDefaultValueSql("(0)");

                entity.Property(e => e.Category)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Category01)
                    .HasColumnName("Category_01")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category02)
                    .HasColumnName("Category_02")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category03)
                    .HasColumnName("Category_03")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category04)
                    .HasColumnName("Category_04")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category05)
                    .HasColumnName("Category_05")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category06)
                    .HasColumnName("Category_06")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category07)
                    .HasColumnName("Category_07")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category08)
                    .HasColumnName("Category_08")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category09)
                    .HasColumnName("Category_09")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category10)
                    .HasColumnName("Category_10")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category11)
                    .HasColumnName("Category_11")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category12)
                    .HasColumnName("Category_12")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category13)
                    .HasColumnName("Category_13")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category14)
                    .HasColumnName("Category_14")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Category15)
                    .HasColumnName("Category_15")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CentralizationAccount)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CertifiedSupplier).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChamberOfCommerce)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ChangeCityOfLoadUnload).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeCountryOfAssembly).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeCountryOfOrigin).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeDeliveryTerms).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeDestinationCountry).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeIntRegion).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeIntraStatSystem).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeTransActionA).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeTransActionB).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeTransShipment).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeTransport).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeTriangularCountry).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeVatCode).HasDefaultValueSql("(0)");

                entity.Property(e => e.ChangeVatServices).HasDefaultValueSql("(1)");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CipaymentCondition)
                    .HasColumnName("CIPaymentCondition")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CityOfLoadUnload)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ClassificationId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpAccMan).HasColumnName("cmp_acc_man");

                entity.Property(e => e.CmpCode)
                    .HasColumnName("cmp_code")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpDateCust)
                    .HasColumnName("cmp_date_cust")
                    .HasColumnType("datetime");

                entity.Property(e => e.CmpDirectory)
                    .HasColumnName("cmp_Directory")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CmpEMail)
                    .HasColumnName("cmp_e_mail")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFadd1)
                    .HasColumnName("cmp_fadd1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFadd2)
                    .HasColumnName("cmp_fadd2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFadd3)
                    .HasColumnName("cmp_fadd3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFax)
                    .HasColumnName("cmp_fax")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFcity)
                    .HasColumnName("cmp_fcity")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFcounty)
                    .HasColumnName("cmp_fcounty")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CmpFctry)
                    .HasColumnName("cmp_fctry")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpFpc)
                    .HasColumnName("cmp_fpc")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CmpName)
                    .HasColumnName("cmp_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmpNote)
                    .HasColumnName("cmp_note")
                    .HasColumnType("text");

                entity.Property(e => e.CmpOrigin)
                    .HasColumnName("cmp_origin")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpParent).HasColumnName("cmp_parent");

                entity.Property(e => e.CmpRating).HasColumnName("cmp_rating");

                entity.Property(e => e.CmpReseller).HasColumnName("cmp_reseller");

                entity.Property(e => e.CmpStatus)
                    .HasColumnName("cmp_status")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpTel)
                    .HasColumnName("cmp_tel")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CmpType)
                    .HasColumnName("cmp_type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CmpWeb)
                    .HasColumnName("cmp_web")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CmpWwn)
                    .HasColumnName("cmp_wwn")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CntId).HasColumnName("cnt_id");

                entity.Property(e => e.Collect)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CollectiveInvoicesGrouping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comment1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Comment2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CommodityCode1)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommodityCode2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommodityCode3)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommodityCode4)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CommodityCode5)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyType).HasDefaultValueSql("(0)");

                entity.Property(e => e.Confirmed).HasDefaultValueSql("(0)");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOfAssembly)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Crdcode)
                    .HasColumnName("crdcode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Crdnr)
                    .HasColumnName("crdnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditCard)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardDescription)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreditCardHolder)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CreditLine).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.CreditabilityScenario)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreditorType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwallowStockInfo).HasColumnName("CSPickITCWAllowStockInfo");

                entity.Property(e => e.CspickItcwdatabaseName)
                    .HasColumnName("CSPickITCWDatabaseName")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CspickItcwdatabaseNameSalesDb)
                    .HasColumnName("CSPickITCWDatabaseNameSalesDB")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CspickItcwdebtorInCwdb)
                    .HasColumnName("CSPickITCWDebtorInCWDB")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwdebtorIsSalesDb).HasColumnName("CSPickITCWDebtorIsSalesDB");

                entity.Property(e => e.CspickItcwdefaultLocation)
                    .HasColumnName("CSPickITCWDefaultLocation")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwimportWarehouse)
                    .HasColumnName("CSPickITCWImportWarehouse")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CspickItcwpurchaseJournal)
                    .HasColumnName("CSPickITCWPurchaseJournal")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwsqlserverCwdb)
                    .HasColumnName("CSPickITCWSQLServerCWDB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CspickItcwsqlserverSalesDb)
                    .HasColumnName("CSPickITCWSQLServerSalesDB")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CspickItcwstock).HasColumnName("CSPickITCWStock");

                entity.Property(e => e.CspickItcwwarehouse).HasColumnName("CSPickITCWWarehouse");

                entity.Property(e => e.CspickItcwwarehouseInCwdb)
                    .HasColumnName("CSPickITCWWarehouseInCWDB")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwwarehouseSalesDb)
                    .HasColumnName("CSPickITCWWarehouseSalesDB")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItpickAndPack)
                    .HasColumnName("CSPickITPickAndPack")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.CspickItshelfLife).HasColumnName("CSPickITShelfLife");

                entity.Property(e => e.CspickItskutype)
                    .HasColumnName("CSPickITSKUType")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItuseMultiLayerSscc)
                    .HasColumnName("CSPickITUseMultiLayerSSCC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Cspickitcwcompany)
                    .HasColumnName("CSPICKITCWCompany")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cspickitcwfid)
                    .HasColumnName("CSPICKITCWFID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cspickitcwfidpw)
                    .HasColumnName("CSPICKITCWFIDPW")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cspickitcwid)
                    .HasColumnName("CSPICKITCWID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CspickitcwimportDebtors).HasColumnName("CSPICKITCWImportDebtors");

                entity.Property(e => e.CspickitcwimportSelectionCode).HasColumnName("CSPICKITCWImportSelectionCode");

                entity.Property(e => e.Cspickitcwpostartdate)
                    .HasColumnName("CSPICKITCWPOStartdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CspickitsplitLot)
                    .HasColumnName("CSPICKITSplitLot")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cspickitsscc1)
                    .HasColumnName("CSPICKITSSCC1")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cspickitsscc2)
                    .HasColumnName("CSPICKITSSCC2")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CzwebAccessSince)
                    .HasColumnName("CZWebAccessSince")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateLastReminder).HasColumnType("datetime");

                entity.Property(e => e.Datefield1)
                    .HasColumnName("datefield1")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefield2)
                    .HasColumnName("datefield2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefield3)
                    .HasColumnName("datefield3")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefield4)
                    .HasColumnName("datefield4")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefield5)
                    .HasColumnName("datefield5")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debcode)
                    .HasColumnName("debcode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Debnr)
                    .HasColumnName("debnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefaultPoform).HasColumnName("DefaultPOForm");

                entity.Property(e => e.DefaultSelCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryMethod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryTerms)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DestinationCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Discount).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.DivisionCreditorId).HasColumnName("DivisionCreditorID");

                entity.Property(e => e.DivisionDebtorId).HasColumnName("DivisionDebtorID");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.DunningLetter).HasDefaultValueSql("(0)");

                entity.Property(e => e.DunsNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.EinvoiceEmail)
                    .HasColumnName("EInvoiceEmail")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EinvoiceSubmissionFormat)
                    .HasColumnName("EInvoiceSubmissionFormat")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ExemptNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExpenseCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ExtraDuty).HasDefaultValueSql("(0)");

                entity.Property(e => e.Factoring).HasDefaultValueSql("(0)");

                entity.Property(e => e.FedCategory)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FedIdnumber)
                    .HasColumnName("FedIDNumber")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FedIdtype)
                    .HasColumnName("FedIDType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FederalCategory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FederalIdnumber).HasColumnName("FederalIDNumber");

                entity.Property(e => e.FederalIdtype)
                    .HasColumnName("FederalIDType")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FinanceCharge).HasDefaultValueSql("(0)");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fobcode)
                    .HasColumnName("FOBCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Gln)
                    .HasColumnName("GLN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroupPayments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupTaxNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Guidfield1).HasColumnName("GUIDField1");

                entity.Property(e => e.Guidfield2).HasColumnName("GUIDField2");

                entity.Property(e => e.Guidfield3).HasColumnName("GUIDField3");

                entity.Property(e => e.Guidfield4).HasColumnName("GUIDField4");

                entity.Property(e => e.Guidfield5).HasColumnName("GUIDField5");

                entity.Property(e => e.Iconumber)
                    .HasColumnName("ICONumber")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ImportOriginCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IncoTermCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IncoTermProperty)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IntRegion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntermediaryAssociate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntermediaryAssociateId)
                    .HasColumnName("IntermediaryAssociateID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntrastatSystem)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceCopies).HasDefaultValueSql("(0)");

                entity.Property(e => e.InvoiceDebtor)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceDiscount).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.InvoiceLayout)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InvoiceName)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceThreshold).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.IsParentAccount).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsPayerRejected).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsTaxExempted).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsTaxable).HasDefaultValueSql("(0)");

                entity.Property(e => e.Isocountry)
                    .HasColumnName("ISOCountry")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JournalCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode10)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode2)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode3)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode4)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode5)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode6)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode7)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode8)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LandedCostCode9)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LayoutCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LayoutPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LiableToPayVat)
                    .HasColumnName("LiableToPayVAT")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LocationShort)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LogoFileName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Mailbox)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NoteId).HasColumnName("NoteID");

                entity.Property(e => e.Numberfield1)
                    .HasColumnName("numberfield1")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Numberfield2)
                    .HasColumnName("numberfield2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Numberfield3)
                    .HasColumnName("numberfield3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Numberfield4)
                    .HasColumnName("numberfield4")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Numberfield5)
                    .HasColumnName("numberfield5")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OffSetAccount)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PageNumber).HasDefaultValueSql("(0)");

                entity.Property(e => e.ParentAccount)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ParticipantNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayeeName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentCondition)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentConditionSearchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentDay1).HasDefaultValueSql("(0)");

                entity.Property(e => e.PaymentDay2).HasDefaultValueSql("(0)");

                entity.Property(e => e.PaymentDay3).HasDefaultValueSql("(0)");

                entity.Property(e => e.PaymentDay4).HasDefaultValueSql("(0)");

                entity.Property(e => e.PaymentDay5).HasDefaultValueSql("(0)");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PercentageToBePaid).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.PhoneExtention)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneQueue)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PostBankNumber)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.PriceList)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PrintPrice).HasDefaultValueSql("(0)");

                entity.Property(e => e.PurchaseOrderAmount).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.PurchaseOrderConfirmation).HasDefaultValueSql("(0)");

                entity.Property(e => e.PurchaseReceipt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RecepientOfCommissions).HasDefaultValueSql("(0)");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegionCd)
                    .HasColumnName("RegionCD")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegistrationCode)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Reminder).HasDefaultValueSql("(0)");

                entity.Property(e => e.RouteCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RuleItem)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SalesOrderAmount).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.SctCode)
                    .HasColumnName("sct_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SearchCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SearchCodeGoods)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SecurityLevel).HasDefaultValueSql("(10)");

                entity.Property(e => e.SendPenaltyInvoices).HasDefaultValueSql("(0)");

                entity.Property(e => e.ShipVia)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SignDate).HasColumnType("datetime");

                entity.Property(e => e.SizCode)
                    .HasColumnName("siz_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SplitPaymentAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.StatFactor)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementAddress)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementDate).HasColumnType("datetime");

                entity.Property(e => e.StatementFrequency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatementNumber).HasDefaultValueSql("(0)");

                entity.Property(e => e.StatementPrint).HasDefaultValueSql("(0)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StatusSince)
                    .HasColumnName("status_since")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubSector)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SupplierStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SyncId).HasColumnName("SyncID");

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxId)
                    .HasColumnName("TaxID")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TaxSchedule)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telex)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Terms)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TerritoryCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TextField10)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField11)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField12)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField13)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField14)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField15)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField16)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField17)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField18)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField19)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField20)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField21)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField22)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField23)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField24)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField25)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField26)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField27)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField28)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField29)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField30)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField6)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField7)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField8)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField9)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Textfield1)
                    .HasColumnName("textfield1")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Textfield2)
                    .HasColumnName("textfield2")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Textfield3)
                    .HasColumnName("textfield3")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Textfield4)
                    .HasColumnName("textfield4")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Textfield5)
                    .HasColumnName("textfield5")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransActionA)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransActionB)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TransShipment)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Transport)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TriangularCountry)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeSince)
                    .HasColumnName("type_since")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Upszone)
                    .HasColumnName("UPSZone")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UseAvalaraTaxation)
                    .IsRequired()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VatCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VatLiability)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VatNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VatServices)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vatsource)
                    .HasColumnName("VATSource")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WebAccessSince).HasColumnType("datetime");

                entity.Property(e => e.WithholdingCertificate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.WithholdingPayer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.YesNofield1).HasDefaultValueSql("(0)");

                entity.Property(e => e.YesNofield2).HasDefaultValueSql("(0)");

                entity.Property(e => e.YesNofield3).HasDefaultValueSql("(0)");

                entity.Property(e => e.YesNofield4).HasDefaultValueSql("(0)");

                entity.Property(e => e.YesNofield5).HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Dagbk>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("dagbk");

                entity.HasIndex(e => e.Dagbknr)
                    .HasName("dagbk")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.Reknr, e.TypeDgbk, e.Dagbknr })
                    .HasName("dbkgbk")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Afk)
                    .HasColumnName("afk")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Banknr)
                    .HasColumnName("banknr")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BlockOutstandingItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.Blokbkst)
                    .HasColumnName("blokbkst")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Blokdat)
                    .HasColumnName("blokdat")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Blokkeer)
                    .HasColumnName("blokkeer")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Boeksaldo)
                    .HasColumnName("boeksaldo")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwAfh)
                    .HasColumnName("btw_afh")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Chckeinds)
                    .HasColumnName("chckeinds")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Crednota)
                    .HasColumnName("crednota")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dagbknr)
                    .HasColumnName("dagbknr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dagkoers)
                    .HasColumnName("dagkoers")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DatumRec)
                    .HasColumnName("datum_rec")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debcrd)
                    .HasColumnName("debcrd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DefReknr)
                    .HasColumnName("def_reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Docdate)
                    .HasColumnName("docdate")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Docnumber)
                    .HasColumnName("docnumber")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield1)
                    .HasColumnName("freefield1")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield10)
                    .HasColumnName("freefield10")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield11)
                    .HasColumnName("freefield11")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield12)
                    .HasColumnName("freefield12")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield13)
                    .HasColumnName("freefield13")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield14)
                    .HasColumnName("freefield14")
                    .HasColumnType("datetime");

                entity.Property(e => e.Freefield15)
                    .HasColumnName("freefield15")
                    .HasColumnType("datetime");

                entity.Property(e => e.Freefield16)
                    .HasColumnName("freefield16")
                    .HasColumnType("datetime");

                entity.Property(e => e.Freefield17)
                    .HasColumnName("freefield17")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield18)
                    .HasColumnName("freefield18")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield19)
                    .HasColumnName("freefield19")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield2)
                    .HasColumnName("freefield2")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield20)
                    .HasColumnName("freefield20")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield3)
                    .HasColumnName("freefield3")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield4)
                    .HasColumnName("freefield4")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield5)
                    .HasColumnName("freefield5")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield6)
                    .HasColumnName("freefield6")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield7)
                    .HasColumnName("freefield7")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield8)
                    .HasColumnName("freefield8")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield9)
                    .HasColumnName("freefield9")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Handmatig)
                    .HasColumnName("handmatig")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Kredlimiet)
                    .HasColumnName("kredlimiet")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.LbkstOntv)
                    .HasColumnName("lbkst_ontv")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LbkstUitg)
                    .HasColumnName("lbkst_uitg")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lbkstnr)
                    .HasColumnName("lbkstnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lverwnr)
                    .HasColumnName("lverwnr")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Oms250)
                    .HasColumnName("oms25_0")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms251)
                    .HasColumnName("oms25_1")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms252)
                    .HasColumnName("oms25_2")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms253)
                    .HasColumnName("oms25_3")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms254)
                    .HasColumnName("oms25_4")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PettyCash)
                    .HasColumnName("petty_cash")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Projdb)
                    .HasColumnName("projdb")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Pstbnknr)
                    .HasColumnName("pstbnknr")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RekBetow)
                    .HasColumnName("rek_betow")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RekInc)
                    .HasColumnName("rek_inc")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SaldoRec)
                    .HasColumnName("saldo_rec")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Sceaction)
                    .HasColumnName("sceaction")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Scecode)
                    .HasColumnName("scecode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxDate)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('D')");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TypeDgbk)
                    .HasColumnName("type_dgbk")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeTrans)
                    .HasColumnName("type_trans")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UseIntercompany).HasDefaultValueSql("(0)");

                entity.Property(e => e.Valcode)
                    .HasColumnName("valcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Verwsaldo)
                    .HasColumnName("verwsaldo")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.VolgnrRec)
                    .HasColumnName("volgnr_rec")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Wijzval)
                    .HasColumnName("wijzval")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Wisselmem)
                    .HasColumnName("wisselmem")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Gbkmut>(entity =>
            {
                entity.ToTable("gbkmut");

                entity.HasIndex(e => e.Bkstnr)
                    .HasFilter("([bkstnr] IS NOT NULL)");

                entity.HasIndex(e => e.BkstnrSub)
                    .HasName("IX_gbkmut_SOnr");

                entity.HasIndex(e => e.CmpWwn);

                entity.HasIndex(e => e.CspickItcwinvoiceNumberCwdb)
                    .HasName("CSPickITInvoiceIX");

                entity.HasIndex(e => e.Docnumber)
                    .HasName("docnumber")
                    .HasFilter("([docnumber] IS NOT NULL)");

                entity.HasIndex(e => e.Faktuurnr)
                    .HasName("IX_gbkmut_OurRef")
                    .HasFilter("([faktuurnr] IS NOT NULL)");

                entity.HasIndex(e => e.Orderdebtor);

                entity.HasIndex(e => e.ReconcileNumber);

                entity.HasIndex(e => e.Shipment)
                    .HasName("IX_gbkmut_ShipmentItem");

                entity.HasIndex(e => e.TransactionGuid)
                    .IsUnique();

                entity.HasIndex(e => e.TransactionGuid2)
                    .HasFilter("([TransactionGuid2] IS NOT NULL)");

                entity.HasIndex(e => e.Unitcode)
                    .HasName("IX_gbkmut_unitcode")
                    .HasFilter("([Unitcode] IS NOT NULL)");

                entity.HasIndex(e => e.Verwerknrl)
                    .HasName("IX_gbkmut_Processed");

                entity.HasIndex(e => new { e.Artcode, e.Facode })
                    .HasName("IX_gbkmut_facode");

                entity.HasIndex(e => new { e.BkstnrSub, e.CspickItcworsrgIdcwdb })
                    .HasName("CSPickITSalesOrderOrsrgID");

                entity.HasIndex(e => new { e.CashRegisterAccount, e.Datum })
                    .HasName("IX_gbkmut_CashRegisterAccount")
                    .HasFilter("([CashRegisterAccount] IS NOT NULL)");

                entity.HasIndex(e => new { e.CspickItcwdeliveryNoteCwdb, e.CspickItcworsrgIdcwdb })
                    .HasName("CSPickITDeliveryNoteOrsrgID");

                entity.HasIndex(e => new { e.EntryGuid, e.Regel })
                    .HasName("IX_gbkmut_EntryGuid")
                    .HasFilter("([EntryGuid] IS NOT NULL)");

                entity.HasIndex(e => new { e.EntryGuid, e.Transtype })
                    .HasName("PTI_gbkmut_1");

                entity.HasIndex(e => new { e.Id, e.DocAttachmentId })
                    .HasName("PTI_gbkmut_6");

                entity.HasIndex(e => new { e.Id, e.DocumentId })
                    .HasName("PTI_gbkmut_7");

                entity.HasIndex(e => new { e.Datum, e.ResId, e.CompCode })
                    .HasName("IX_gbkmut_Payroll");

                entity.HasIndex(e => new { e.Syscreated, e.Syscreator, e.Dagbknr })
                    .HasName("IX_gbkmut_syscreated_syscreator_journal");

                entity.HasIndex(e => new { e.Artcode, e.Reknr, e.Datum, e.Transtype })
                    .HasName("IX_gbkmut_Items");

                entity.HasIndex(e => new { e.Kstdrcode, e.Reknr, e.Datum, e.Transtype })
                    .HasName("IX_gbkmut_CostUnit")
                    .HasFilter("([kstdrcode] IS NOT NULL)");

                entity.HasIndex(e => new { e.Kstplcode, e.Reknr, e.Datum, e.Transtype })
                    .HasName("IX_gbkmut_CostCenter")
                    .HasFilter("([kstplcode] IS NOT NULL)");

                entity.HasIndex(e => new { e.Project, e.Reknr, e.Datum, e.Transtype })
                    .HasName("IX_gbkmut_Project");

                entity.HasIndex(e => new { e.ResId, e.Reknr, e.Datum, e.Transtype })
                    .HasName("IX_gbkmut_Resource");

                entity.HasIndex(e => new { e.Artcode, e.Datum, e.Bkstnr, e.Type, e.LineType })
                    .HasName("IX_gbkmut_LastRevaluation");

                entity.HasIndex(e => new { e.BankTransactionGuid, e.Transtype, e.Reknr, e.Debnr, e.Crdnr })
                    .HasName("IX_gbkmut_BankTransactionGUID")
                    .HasFilter("([BankTransactionGUID] IS NOT NULL)");

                entity.HasIndex(e => new { e.Bkjrcode, e.Reknr, e.Periode, e.Datum, e.Id })
                    .HasName("gbmrkp")
                    .IsUnique();

                entity.HasIndex(e => new { e.Reknr, e.BdrHfl, e.Datum, e.ReminderCount, e.Transtype })
                    .HasName("PTI_gbkmut_2");

                entity.HasIndex(e => new { e.BkstnrSub, e.Regel, e.BudVers, e.Transtype, e.Transsubtype, e.Freefield1 })
                    .HasName("IX_gbkmut_MRP");

                entity.HasIndex(e => new { e.CompanyCode, e.Timestamp, e.TransactionType, e.EntryGuid, e.Transtype, e.Verwerknrl })
                    .HasName("IX_gbkmut_CompanyTS");

                entity.HasIndex(e => new { e.Warehouse, e.WarehouseLocation, e.Artcode, e.Reknr, e.Transtype, e.Datum })
                    .HasName("IX_gbkmut_WarehouseLocation");

                entity.HasIndex(e => new { e.EntryGuid, e.Faktuurnr, e.Datum, e.Transtype, e.BdrHfl, e.Debnr, e.Crdnr })
                    .HasName("entry_invoice");

                entity.HasIndex(e => new { e.Transtype, e.Transsubtype, e.Freefield1, e.Project, e.StartTime, e.EndTime, e.BudVers })
                    .HasName("IX_prod_gbkmut");

                entity.HasIndex(e => new { e.BdrHfl, e.Valcode, e.BdrVal, e.Docdate, e.ReminderCount, e.Transsubtype, e.Reknr, e.BudVers, e.Transtype })
                    .HasName("PTI_gbkmut_3");

                entity.HasIndex(e => new { e.Reknr, e.Datum, e.Dagbknr, e.Transtype, e.Transsubtype, e.ReminderCount, e.Verwerknrl, e.Reviewed, e.Checked })
                    .HasName("IX_gbkmut_GLCard");

                entity.HasIndex(e => new { e.BudVers, e.CompanyCode, e.Bkjrcode, e.Reknr, e.Periode, e.Verwerknrl, e.Transtype, e.Transsubtype, e.AmountCentral, e.BdrHfl })
                    .HasName("IX_gbkmut_Budget");

                entity.HasIndex(e => new { e.Crdnr, e.Reknr, e.Faktuurnr, e.Datum, e.BdrHfl, e.Transtype, e.Transsubtype, e.Entryorigin, e.CompanyCode, e.ReminderCount })
                    .HasName("IX_gbkmut_AP")
                    .HasFilter("([crdnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Transtype, e.Transsubtype, e.Freefield1, e.ResId, e.Checked, e.BlockItem, e.Reviewed, e.ReminderCount, e.Warehouse, e.TransactionGuid2 })
                    .HasName("IX_gbkmut_InternalUse");

                entity.HasIndex(e => new { e.Warehouse, e.Artcode, e.Reknr, e.StockTrackingNumber, e.Datum, e.Transtype, e.Transsubtype, e.Aantal, e.BdrHfl, e.WarehouseLocation })
                    .HasName("IX_gbkmut_Warehouse");

                entity.HasIndex(e => new { e.Dagbknr, e.BdrHfl, e.Crdnr, e.Aantal, e.BkstnrSub, e.Faktuurnr, e.ReconcileNumber, e.Reknr, e.Artcode, e.Transtype, e.Transsubtype })
                    .HasName("PTI_gbkmut_5");

                entity.HasIndex(e => new { e.Debnr, e.Reknr, e.Faktuurnr, e.Datum, e.BdrHfl, e.AmountCentral, e.Transtype, e.Transsubtype, e.Entryorigin, e.CompanyCode, e.ReminderCount })
                    .HasName("IX_gbkmut_AR")
                    .HasFilter("([debnr] IS NOT NULL)");

                entity.HasIndex(e => new { e.Transtype, e.Transsubtype, e.Freefield1, e.Selcode, e.Warehouse, e.BlockItem, e.Datum, e.Docdate, e.BkstnrSub, e.Reknr, e.Afldat })
                    .HasName("IX_gbkmut_Transtype");

                entity.HasIndex(e => new { e.Warehouse, e.Artcode, e.Reknr, e.StockTrackingNumber, e.Datum, e.Transtype, e.Transsubtype, e.Aantal, e.BdrHfl, e.WarehouseLocation, e.Facode })
                    .HasName("CSPickIT_IX_gbkmut_SBItem");

                entity.HasIndex(e => new { e.Id, e.Datum, e.Bkstnr, e.BdrHfl, e.Crdnr, e.Valcode, e.BudVers, e.Transtype, e.Transsubtype, e.Freefield1, e.Artcode, e.Aantal })
                    .HasName("PTI_gbkmut_4");

                entity.HasIndex(e => new { e.Reknr, e.Periode, e.BdrHfl, e.Kstplcode, e.Kstdrcode, e.Artcode, e.BudVers, e.ResId, e.Project, e.Bkjrcode, e.Transtype, e.Transsubtype })
                    .HasName("EGN_Dashboard1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aantal)
                    .HasColumnName("aantal")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Afldat)
                    .HasColumnName("afldat")
                    .HasColumnType("datetime");

                entity.Property(e => e.AllocationType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AmountCentral).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Artcode)
                    .HasColumnName("artcode")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Backflush).HasColumnName("backflush");

                entity.Property(e => e.BankTransactionGuid).HasColumnName("BankTransactionGUID");

                entity.Property(e => e.Bankacc)
                    .HasColumnName("bankacc")
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.BdrHfl)
                    .HasColumnName("bdr_hfl")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BdrVal)
                    .HasColumnName("bdr_val")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bdrkredbep)
                    .HasColumnName("bdrkredbep")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Bdrkredbp2)
                    .HasColumnName("bdrkredbp2")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Betaalref)
                    .HasColumnName("betaalref")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Betcond)
                    .HasColumnName("betcond")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bkjrcode).HasColumnName("bkjrcode");

                entity.Property(e => e.Bkstnr)
                    .HasColumnName("bkstnr")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BkstnrSub)
                    .HasColumnName("bkstnr_sub")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BlockItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.BtwBdr3)
                    .HasColumnName("btw_bdr_3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwCode)
                    .HasColumnName("btw_code")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BtwGrond)
                    .HasColumnName("btw_grond")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwGrval)
                    .HasColumnName("btw_grval")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BtwNummer)
                    .HasColumnName("btw_nummer")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Btwper)
                    .HasColumnName("btwper")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.BudVers)
                    .HasColumnName("bud_vers")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CashRegisterAccount)
                    .HasMaxLength(34)
                    .IsUnicode(false);

                entity.Property(e => e.Checked).HasDefaultValueSql("(0)");

                entity.Property(e => e.CmpWwn).HasColumnName("cmp_wwn");

                entity.Property(e => e.CompCode)
                    .HasColumnName("comp_code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Correction)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Crdnr)
                    .HasColumnName("crdnr")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwdeliveryNoteCwdb)
                    .HasColumnName("CSPickITCWDeliveryNoteCWDB")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcwinvoiceNumberCwdb)
                    .HasColumnName("CSPickITCWInvoiceNumberCWDB")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItcworsrgIdcwdb).HasColumnName("CSPickITCWOrsrgIDCWDB");

                entity.Property(e => e.CspickIthandTerminalId)
                    .HasColumnName("CSPickITHandTerminalID")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItlockProcessId)
                    .HasColumnName("CSPickITLockProcessID")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickItlockResource).HasColumnName("CSPickITLockResource");

                entity.Property(e => e.CspickItlockTime)
                    .HasColumnName("CSPickITLockTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CspickItmodifyQuantity).HasColumnName("CSPickITModifyQuantity");

                entity.Property(e => e.CspickItorderPicker).HasColumnName("CSPickITOrderPicker");

                entity.Property(e => e.CspickItqtyOrdered).HasColumnName("CSPickITQtyOrdered");

                entity.Property(e => e.CspickItquantityPicked).HasColumnName("CSPickITQuantityPicked");

                entity.Property(e => e.CspickItstate)
                    .HasColumnName("CSPickITState")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickIttransactionGuid).HasColumnName("CSPickITTransactionGUID");

                entity.Property(e => e.CspickIttransferLineId).HasColumnName("CSPickITTransferLineID");

                entity.Property(e => e.CurrencyAliasAc)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dagbknr)
                    .HasColumnName("dagbknr")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.DbkVerwnr)
                    .HasColumnName("dbk_verwnr")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Debnr)
                    .HasColumnName("debnr")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocAttachmentId).HasColumnName("DocAttachmentID");

                entity.Property(e => e.Docdate)
                    .HasColumnName("docdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Docnumber)
                    .HasColumnName("docnumber")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Entryorigin)
                    .HasColumnName("entryorigin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ExternalNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ExternalNumberRecordId).HasColumnName("ExternalNumberRecordID");

                entity.Property(e => e.Exvalbdr)
                    .HasColumnName("exvalbdr")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Exvalcode)
                    .HasColumnName("exvalcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Facode)
                    .HasColumnName("facode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Faktuurnr)
                    .HasColumnName("faktuurnr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield1)
                    .HasColumnName("freefield1")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield2)
                    .HasColumnName("freefield2")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield3)
                    .HasColumnName("freefield3")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Freefield4).HasColumnName("freefield4");

                entity.Property(e => e.Freefield5).HasColumnName("freefield5");

                entity.Property(e => e.IbtdeliveryNr)
                    .HasColumnName("IBTDeliveryNr")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ImSerialNr)
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.ImportationNr)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IntArea)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntDeliveryMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntLandAssembly)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IntLandDestOrig)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IntLandIso)
                    .HasColumnName("IntLandISO")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IntPort)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntStandardCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntStatNr)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IntSystem)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransA)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransB)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransShipment)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IntTransportMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Koers)
                    .HasColumnName("koers")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Koers3)
                    .HasColumnName("koers3")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Kredbep)
                    .HasColumnName("kredbep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstdrcode)
                    .HasColumnName("kstdrcode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstplcode)
                    .HasColumnName("kstplcode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastReminderDate).HasColumnType("datetime");

                entity.Property(e => e.LastReminderLayout)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OfficialAmountDc)
                    .HasColumnName("OfficialAmountDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialBasisDc)
                    .HasColumnName("OfficialBasisDC")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.OfficialExchangeRate).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Oms25)
                    .HasColumnName("oms25")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oorsprong)
                    .HasColumnName("oorsprong")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Operation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Orderdebtor).HasColumnName("orderdebtor");

                entity.Property(e => e.OriginalQuantity).HasColumnName("Original_Quantity");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PayrollSubtype)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Periode)
                    .HasColumnName("periode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PositionNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pricelist)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Raplist)
                    .HasColumnName("raplist")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rapnr)
                    .HasColumnName("rapnr")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rate).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Reasoncode)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Regel)
                    .HasColumnName("regel")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Regelcode)
                    .HasColumnName("regelcode")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReminderCount).HasDefaultValueSql("(0)");

                entity.Property(e => e.ReminderLayout).HasDefaultValueSql("(0)");

                entity.Property(e => e.ReportingDate).HasColumnType("datetime");

                entity.Property(e => e.ResId)
                    .HasColumnName("res_id")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.RevaluationCurrency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reviewed).HasDefaultValueSql("(0)");

                entity.Property(e => e.Routing)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Selcode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Shipment)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StatNr)
                    .HasColumnName("stat_nr")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.StatementDate).HasColumnType("datetime");

                entity.Property(e => e.StatementNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StockTrackingNumber)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Storno)
                    .HasColumnName("storno")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxAmount2).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount3).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount4).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxAmount5).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis2).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis3).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis4).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxBasis5).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.TaxCode2)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode4)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxCode5)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TaxDate).HasColumnType("datetime");

                entity.Property(e => e.Tegreknr)
                    .HasColumnName("tegreknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TransactionGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType).HasDefaultValueSql("(0)");

                entity.Property(e => e.Transsubtype)
                    .HasColumnName("transsubtype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Transtype)
                    .HasColumnName("transtype")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Unitcode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Valcode)
                    .HasColumnName("valcode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VatAmountCentral).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.VatBaseAmountCentral).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Vervdatfak)
                    .HasColumnName("vervdatfak")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdatkrd)
                    .HasColumnName("vervdatkrd")
                    .HasColumnType("datetime");

                entity.Property(e => e.Vervdtkrd2)
                    .HasColumnName("vervdtkrd2")
                    .HasColumnType("datetime");

                entity.Property(e => e.Verwerknrl)
                    .HasColumnName("verwerknrl")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.VlgnGbk2)
                    .HasColumnName("vlgn_gbk2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Volgnr5)
                    .HasColumnName("volgnr5")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Warehouse)
                    .HasColumnName("warehouse")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WarehouseLocation)
                    .HasColumnName("warehouse_location")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Wisselkrs)
                    .HasColumnName("wisselkrs")
                    .HasDefaultValueSql("(0.0)");
            });

            modelBuilder.Entity<Grtbk>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("grtbk");

                entity.HasIndex(e => e.AccountCode);

                entity.HasIndex(e => e.Oms250)
                    .HasName("GLDecription_0");

                entity.HasIndex(e => e.Oms251)
                    .HasName("GLDecription_1")
                    .HasFilter("([oms25_1] IS NOT NULL)");

                entity.HasIndex(e => e.Oms252)
                    .HasName("GLDecription_2")
                    .HasFilter("([oms25_2] IS NOT NULL)");

                entity.HasIndex(e => e.Oms253)
                    .HasName("GLDecription_3");

                entity.HasIndex(e => e.Oms254)
                    .HasName("GLDecription_4");

                entity.HasIndex(e => e.Reknr)
                    .HasName("grtbk");

                entity.HasIndex(e => e.ReknrNaf)
                    .HasName("PTI_grtbk_1");

                entity.HasIndex(e => new { e.CompanyCode, e.Reknr })
                    .HasName("IX_grtbk_Clustered")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.Omzrek, e.Reknr })
                    .HasName("IX_GLSubType");

                entity.HasIndex(e => new { e.Reknr, e.BalVw })
                    .HasName("PTI_grtbk_5");

                entity.HasIndex(e => new { e.ReknrL, e.Id })
                    .HasName("gbkrek");

                entity.HasIndex(e => new { e.Id, e.Oms250, e.Blokkeer, e.Reknr })
                    .HasName("PTI_grtbk_4");

                entity.HasIndex(e => new { e.Reknr, e.Oms250, e.BalVw, e.Omzrek, e.Subtotrek })
                    .HasName("PTI_grtbk_2");

                entity.HasIndex(e => new { e.Id, e.Oms250, e.Subtotrek, e.Blokkeer, e.Reknr, e.Omzrek })
                    .HasName("PTI_grtbk_3");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Aandacht)
                    .HasColumnName("aandacht")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Aantallen)
                    .HasColumnName("aantallen")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ActRek)
                    .HasColumnName("act_rek")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AfletMut)
                    .HasColumnName("aflet_mut")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Afletteren)
                    .HasColumnName("afletteren")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Afsreknr)
                    .HasColumnName("afsreknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Alternativeledger)
                    .HasColumnName("alternativeledger")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AnalytAcc)
                    .HasColumnName("analyt_acc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AssociateGl)
                    .HasColumnName("AssociateGL")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BalVw)
                    .HasColumnName("bal_vw")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BkjrMut).HasColumnName("bkjr_mut");

                entity.Property(e => e.Bkjrcode).HasColumnName("bkjrcode");

                entity.Property(e => e.Blokkeer)
                    .HasColumnName("blokkeer")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Blznr)
                    .HasColumnName("blznr")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BtwCode)
                    .HasColumnName("btw_code")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CentrAccount)
                    .HasColumnName("centr_account")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Class01)
                    .HasColumnName("Class_01")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class02)
                    .HasColumnName("Class_02")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class03)
                    .HasColumnName("Class_03")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class04)
                    .HasColumnName("Class_04")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class05)
                    .HasColumnName("Class_05")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class06)
                    .HasColumnName("Class_06")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class07)
                    .HasColumnName("Class_07")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class08)
                    .HasColumnName("Class_08")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class09)
                    .HasColumnName("Class_09")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class10)
                    .HasColumnName("Class_10")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class11)
                    .HasColumnName("Class_11")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Class12)
                    .HasColumnName("Class_12")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Debcrd)
                    .HasColumnName("debcrd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ExcludeVatlisting).HasColumnName("ExcludeVATListing");

                entity.Property(e => e.Freefield1)
                    .HasColumnName("freefield1")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield10)
                    .HasColumnName("freefield10")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield11)
                    .HasColumnName("freefield11")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield12)
                    .HasColumnName("freefield12")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield13)
                    .HasColumnName("freefield13")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield14)
                    .HasColumnName("freefield14")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield15)
                    .HasColumnName("freefield15")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Freefield16)
                    .HasColumnName("freefield16")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield17)
                    .HasColumnName("freefield17")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield18)
                    .HasColumnName("freefield18")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield19)
                    .HasColumnName("freefield19")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield2)
                    .HasColumnName("freefield2")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield20)
                    .HasColumnName("freefield20")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Freefield3)
                    .HasColumnName("freefield3")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield4)
                    .HasColumnName("freefield4")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield5)
                    .HasColumnName("freefield5")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield6)
                    .HasColumnName("freefield6")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield7)
                    .HasColumnName("freefield7")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield8)
                    .HasColumnName("freefield8")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Freefield9)
                    .HasColumnName("freefield9")
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Gbktext).HasColumnName("gbktext");

                entity.Property(e => e.Herwaard)
                    .HasColumnName("herwaard")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.IntBalanceDebit)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsPersonalAccount).HasDefaultValueSql("(0)");

                entity.Property(e => e.Kstdrrek)
                    .HasColumnName("kstdrrek")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Kstplrek)
                    .HasColumnName("kstplrek")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Mineraal)
                    .HasColumnName("mineraal")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Msiccode)
                    .HasColumnName("MSICCode")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OffBalSubClassCredit)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oms250)
                    .HasColumnName("oms25_0")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oms251)
                    .HasColumnName("oms25_1")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oms252)
                    .HasColumnName("oms25_2")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oms253)
                    .HasColumnName("oms25_3")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Oms254)
                    .HasColumnName("oms25_4")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Omzrek)
                    .HasColumnName("omzrek")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PercNaf)
                    .HasColumnName("perc_naf")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.PercPrive)
                    .HasColumnName("perc_prive")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Prnbifunc)
                    .HasColumnName("prnbifunc")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Projectrek)
                    .HasColumnName("projectrek")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Reknr)
                    .HasColumnName("reknr")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Reknr2)
                    .HasColumnName("reknr_2")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReknrL)
                    .HasColumnName("reknr_l")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReknrNaf)
                    .HasColumnName("reknr_naf")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReknrPriv)
                    .HasColumnName("reknr_priv")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SchemeType)
                    .HasColumnName("scheme_type")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShowNotes).HasDefaultValueSql("((0))");

                entity.Property(e => e.Statusdate)
                    .HasColumnName("statusdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StdKstdr)
                    .HasColumnName("std_kstdr")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StdKstpl)
                    .HasColumnName("std_kstpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SubclassPass)
                    .HasColumnName("subclass_pass")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Subtotrek)
                    .HasColumnName("subtotrek")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.TaxonomyCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TypeAdjustmentInflation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeCom)
                    .HasColumnName("type_com")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeRek)
                    .HasColumnName("type_rek")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TypeRek2)
                    .HasColumnName("type_rek2")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UseCostcenterAllocation).HasDefaultValueSql("(1)");

                entity.Property(e => e.UseCreditor).HasDefaultValueSql("(0)");

                entity.Property(e => e.UseDebtor).HasDefaultValueSql("(0)");

                entity.Property(e => e.UseIbactive)
                    .HasColumnName("UseIBActive")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.UseIntercompany).HasDefaultValueSql("(0)");

                entity.Property(e => e.UseItem).HasDefaultValueSql("(0)");

                entity.Property(e => e.UseProject).HasDefaultValueSql("(0)");

                entity.Property(e => e.UseResource).HasDefaultValueSql("(0)");

                entity.Property(e => e.Verdicht)
                    .HasColumnName("verdicht")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.WijzReg)
                    .HasColumnName("wijz_reg")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Wisselrek)
                    .HasColumnName("wisselrek")
                    .HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Kstdr>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("kstdr");

                entity.HasIndex(e => e.Kstdrcode)
                    .HasName("kstdr")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.Bedrnr, e.Kstdrcode, e.Id })
                    .HasName("kstbnr")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bedrnr)
                    .HasColumnName("bedrnr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Kstdrcode)
                    .HasColumnName("kstdrcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oms250)
                    .HasColumnName("oms25_0")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms251)
                    .HasColumnName("oms25_1")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms252)
                    .HasColumnName("oms25_2")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms253)
                    .HasColumnName("oms25_3")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Oms254)
                    .HasColumnName("oms25_4")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UserField01)
                    .HasColumnName("UserField_01")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField02)
                    .HasColumnName("UserField_02")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField03)
                    .HasColumnName("UserField_03")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField04)
                    .HasColumnName("UserField_04")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField05)
                    .HasColumnName("UserField_05")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserNumber01).HasColumnName("UserNumber_01");

                entity.Property(e => e.UserNumber02).HasColumnName("UserNumber_02");

                entity.Property(e => e.UserNumber03).HasColumnName("UserNumber_03");

                entity.Property(e => e.UserNumber04).HasColumnName("UserNumber_04");

                entity.Property(e => e.UserNumber05).HasColumnName("UserNumber_05");
            });

            modelBuilder.Entity<Kstpl>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("kstpl");

                entity.HasIndex(e => e.Kstplcode)
                    .HasName("kstpl")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bedrnr)
                    .HasColumnName("bedrnr")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CcMgr)
                    .HasColumnName("cc_mgr")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Class01)
                    .HasColumnName("Class_01")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('<none>')");

                entity.Property(e => e.Class02)
                    .HasColumnName("Class_02")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('<none>')");

                entity.Property(e => e.Class03)
                    .HasColumnName("Class_03")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('<none>')");

                entity.Property(e => e.Class04)
                    .HasColumnName("Class_04")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('<none>')");

                entity.Property(e => e.Enabled).HasDefaultValueSql("(1)");

                entity.Property(e => e.ExtDlnivo)
                    .HasColumnName("ext_dlnivo")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.ExtTarief)
                    .HasColumnName("ext_tarief")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.ExtTotvrd)
                    .HasColumnName("ext_totvrd")
                    .HasDefaultValueSql("(0.0)");

                entity.Property(e => e.Kstplcode)
                    .HasColumnName("kstplcode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oms250)
                    .HasColumnName("oms25_0")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oms251)
                    .HasColumnName("oms25_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oms252)
                    .HasColumnName("oms25_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oms253)
                    .HasColumnName("oms25_3")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Oms254)
                    .HasColumnName("oms25_4")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator)
                    .HasColumnName("syscreator")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier)
                    .HasColumnName("sysmodifier")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UserField01)
                    .HasColumnName("UserField_01")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField02)
                    .HasColumnName("UserField_02")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField03)
                    .HasColumnName("UserField_03")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField04)
                    .HasColumnName("UserField_04")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserField05)
                    .HasColumnName("UserField_05")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserNumber01).HasColumnName("UserNumber_01");

                entity.Property(e => e.UserNumber02).HasColumnName("UserNumber_02");

                entity.Property(e => e.UserNumber03).HasColumnName("UserNumber_03");

                entity.Property(e => e.UserNumber04).HasColumnName("UserNumber_04");

                entity.Property(e => e.UserNumber05).HasColumnName("UserNumber_05");
            });

            modelBuilder.Entity<Prproject>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("PRProject");

                entity.HasIndex(e => e.Idcustomer)
                    .HasName("PRProject_IDCustomer");

                entity.HasIndex(e => e.ParentProject)
                    .HasName("PTI_PRProject_2");

                entity.HasIndex(e => e.ProjectNr)
                    .HasName("PRProject")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.ProjectNr, e.Division })
                    .HasName("PRProjectIdx1")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProjectNr, e.Idcustomer })
                    .HasName("PRProjectIdx2")
                    .IsUnique();

                entity.HasIndex(e => new { e.ProjectNr, e.ParentProject })
                    .HasName("PTI_PRProject_3");

                entity.HasIndex(e => new { e.ProjectNr, e.ItemCode, e.Type })
                    .HasName("PTI_PRProject_1");

                entity.HasIndex(e => new { e.Type, e.ProjectNr, e.ItemCode })
                    .HasName("IX_PRProject_Type_ProjectNr");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BackFlushing).HasDefaultValueSql("(0)");

                entity.Property(e => e.Compression)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Costunit)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CspickitlatestTryInService)
                    .HasColumnName("CSPICKITLatestTryInService")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateField1).HasColumnType("datetime");

                entity.Property(e => e.DateField2).HasColumnType("datetime");

                entity.Property(e => e.DateField3).HasColumnType("datetime");

                entity.Property(e => e.DateField4).HasColumnType("datetime");

                entity.Property(e => e.DateField5).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Division)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dlconfirmation).HasColumnName("DLConfirmation");

                entity.Property(e => e.Dlevaluation).HasColumnName("DLEvaluation");

                entity.Property(e => e.Dlproposal).HasColumnName("DLProposal");

                entity.Property(e => e.DrawingNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EstCost).HasDefaultValueSql("(0)");

                entity.Property(e => e.EstCostCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EstRev).HasDefaultValueSql("(0)");

                entity.Property(e => e.EstRevCcy)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HourlyRate).HasDefaultValueSql("(0.0)");

                entity.Property(e => e.HourlyRateBasis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HourlyRateBasisExt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

                entity.Property(e => e.IditemNumbers).HasColumnName("IDItemNumbers");

                entity.Property(e => e.IdjobActivity).HasColumnName("IDJobActivity");

                entity.Property(e => e.Idjobgroup).HasColumnName("IDJobgroup");

                entity.Property(e => e.Idreseller).HasColumnName("IDReseller");

                entity.Property(e => e.ImageFilename)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.InitialEndDate).HasColumnType("datetime");

                entity.Property(e => e.InitialStartDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Labour)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Machine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Magcode)
                    .HasColumnName("magcode")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Material)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaterialLine)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.ParentProject)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.Poyes).HasColumnName("POYes");

                entity.Property(e => e.ProjectNr)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Release)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Syscreated)
                    .HasColumnName("syscreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Syscreator).HasColumnName("syscreator");

                entity.Property(e => e.Sysguid)
                    .HasColumnName("sysguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Sysmodified)
                    .HasColumnName("sysmodified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sysmodifier).HasColumnName("sysmodifier");

                entity.Property(e => e.TextField1)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField2)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField3)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField4)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.TextField5)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                //entity.Property(e => e.Vatamount).HasColumnName("VATAmount");

                //entity.Property(e => e.VatpoOriginalCurrency).HasColumnName("VATPO_OriginalCurrency");

                entity.Property(e => e.WipAccount)
                    .HasColumnName("WIP_Account")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WipMethod)
                    .HasColumnName("WIP_Method")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WipRevenue)
                    .HasColumnName("WIP_Revenue")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
