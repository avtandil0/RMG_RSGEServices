﻿using System;
using System.Collections.Generic;

namespace RSGEServices.DAL.Models
{
    public partial class Cicmpy
    {
        public int Id { get; set; }
        public Guid CmpWwn { get; set; }
        public string CmpCode { get; set; }
        public Guid? CntId { get; set; }
        public Guid? CmpParent { get; set; }
        public string CmpName { get; set; }
        public string CmpFadd1 { get; set; }
        public string CmpFadd2 { get; set; }
        public string CmpFadd3 { get; set; }
        public string CmpFpc { get; set; }
        public string CmpFcity { get; set; }
        public string CmpFcounty { get; set; }
        public string StateCode { get; set; }
        public string CmpFctry { get; set; }
        public string CmpEMail { get; set; }
        public string CmpWeb { get; set; }
        public string CmpFax { get; set; }
        public string CmpTel { get; set; }
        public string SctCode { get; set; }
        public string SubSector { get; set; }
        public string SizCode { get; set; }
        public DateTime? CmpDateCust { get; set; }
        public string CmpNote { get; set; }
        public int? CmpAccMan { get; set; }
        public Guid? CmpReseller { get; set; }
        public string Administration { get; set; }
        public string CmpType { get; set; }
        public string CmpStatus { get; set; }
        public Guid? DivisionDebtorId { get; set; }
        public Guid? DivisionCreditorId { get; set; }
        public DateTime? Datefield1 { get; set; }
        public DateTime? Datefield2 { get; set; }
        public DateTime? Datefield3 { get; set; }
        public DateTime? Datefield4 { get; set; }
        public DateTime? Datefield5 { get; set; }
        public double Numberfield1 { get; set; }
        public double Numberfield2 { get; set; }
        public double Numberfield3 { get; set; }
        public double Numberfield4 { get; set; }
        public double Numberfield5 { get; set; }
        public byte YesNofield1 { get; set; }
        public byte YesNofield2 { get; set; }
        public byte YesNofield3 { get; set; }
        public byte YesNofield4 { get; set; }
        public byte YesNofield5 { get; set; }
        public string Textfield1 { get; set; }
        public string Textfield2 { get; set; }
        public string Textfield3 { get; set; }
        public string Textfield4 { get; set; }
        public string Textfield5 { get; set; }
        public int? CmpRating { get; set; }
        public string CmpOrigin { get; set; }
        public byte[] Logo { get; set; }
        public string LogoFileName { get; set; }
        public Guid? DocumentId { get; set; }
        public string ClassificationId { get; set; }
        public DateTime TypeSince { get; set; }
        public DateTime? StatusSince { get; set; }
        public DateTime? WebAccessSince { get; set; }
        public bool? ProcessedByBackgroundJob { get; set; }
        public string Debnr { get; set; }
        public string Crdnr { get; set; }
        public string Debcode { get; set; }
        public string Crdcode { get; set; }
        public string Aspserver { get; set; }
        public string Aspdatabase { get; set; }
        public string AspwebServer { get; set; }
        public string AspwebSite { get; set; }
        public DateTime Syscreated { get; set; }
        public int Syscreator { get; set; }
        public DateTime Sysmodified { get; set; }
        public int Sysmodifier { get; set; }
        public Guid Sysguid { get; set; }
        public byte[] Timestamp { get; set; }
        public string SearchCode { get; set; }
        public string Telex { get; set; }
        public string PostBankNumber { get; set; }
        public int? NoteId { get; set; }
        public byte Blocked { get; set; }
        public string LayoutCode { get; set; }
        public double BalanceDebit { get; set; }
        public double BalanceCredit { get; set; }
        public double SalesOrderAmount { get; set; }
        public short PageNumber { get; set; }
        public double AmountOpen { get; set; }
        public byte Factoring { get; set; }
        public string Isocountry { get; set; }
        public byte LiableToPayVat { get; set; }
        public byte BackOrders { get; set; }
        public string CostCenter { get; set; }
        public string AddressNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public string RouteCode { get; set; }
        public double InvoiceDiscount { get; set; }
        public string PaymentConditionSearchCode { get; set; }
        public string SearchCodeGoods { get; set; }
        public string ExpenseCode { get; set; }
        public string Iconumber { get; set; }
        public string BankNumber2 { get; set; }
        public string Area { get; set; }
        public string InvoiceLayout { get; set; }
        public string InvoiceName { get; set; }
        public string Status { get; set; }
        public double InvoiceThreshold { get; set; }
        public string Location { get; set; }
        public string Vatsource { get; set; }
        public byte CalculatePenaltyInterest { get; set; }
        public string IntermediaryAssociate { get; set; }
        public byte SendPenaltyInvoices { get; set; }
        public string CentralizationAccount { get; set; }
        public string Currency { get; set; }
        public string BankAccountNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string InvoiceDebtor { get; set; }
        public double CreditLine { get; set; }
        public double Discount { get; set; }
        public DateTime? DateLastReminder { get; set; }
        public string VatNumber { get; set; }
        public string PurchaseReceipt { get; set; }
        public string OffSetAccount { get; set; }
        public string JournalCode { get; set; }
        public byte Reminder { get; set; }
        public string PaymentCondition { get; set; }
        public string PriceList { get; set; }
        public string ItemCode { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTime? CheckDate { get; set; }
        public string StatFactor { get; set; }
        public string VatCode { get; set; }
        public byte ChangeVatCode { get; set; }
        public string IntrastatSystem { get; set; }
        public byte ChangeIntraStatSystem { get; set; }
        public string TransActionA { get; set; }
        public byte ChangeTransActionA { get; set; }
        public string TransActionB { get; set; }
        public byte ChangeTransActionB { get; set; }
        public string DestinationCountry { get; set; }
        public byte ChangeDestinationCountry { get; set; }
        public string Transport { get; set; }
        public byte ChangeTransport { get; set; }
        public string CityOfLoadUnload { get; set; }
        public byte ChangeCityOfLoadUnload { get; set; }
        public string DeliveryTerms { get; set; }
        public byte ChangeDeliveryTerms { get; set; }
        public string TransShipment { get; set; }
        public byte ChangeTransShipment { get; set; }
        public string TriangularCountry { get; set; }
        public byte ChangeTriangularCountry { get; set; }
        public string IntRegion { get; set; }
        public byte ChangeIntRegion { get; set; }
        public string Collect { get; set; }
        public short InvoiceCopies { get; set; }
        public short PaymentDay1 { get; set; }
        public short PaymentDay2 { get; set; }
        public short PaymentDay3 { get; set; }
        public short PaymentDay4 { get; set; }
        public short PaymentDay5 { get; set; }
        public string FiscalCode { get; set; }
        public string CreditCard { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string TextField6 { get; set; }
        public string TextField7 { get; set; }
        public string TextField8 { get; set; }
        public string TextField9 { get; set; }
        public string TextField10 { get; set; }
        public int AccountEmployeeId { get; set; }
        public string CreditabilityScenario { get; set; }
        public string VatLiability { get; set; }
        public byte Attention { get; set; }
        public string Category { get; set; }
        public string StatementAddress { get; set; }
        public byte StatementPrint { get; set; }
        public short StatementNumber { get; set; }
        public DateTime? StatementDate { get; set; }
        public string DefaultSelCode { get; set; }
        public string GroupPayments { get; set; }
        public double BoelimitAmount { get; set; }
        public double BoemaxAmount { get; set; }
        public byte ExtraDuty { get; set; }
        public string RegionCd { get; set; }
        public string Region { get; set; }
        public string IntermediaryAssociateId { get; set; }
        public short CompanyType { get; set; }
        public int? SalesPersonNumber { get; set; }
        public string AccountTypeCode { get; set; }
        public string StatementFrequency { get; set; }
        public string AccountRating { get; set; }
        public byte FinanceCharge { get; set; }
        public string ParentAccount { get; set; }
        public byte IsParentAccount { get; set; }
        public string ShipVia { get; set; }
        public string Upszone { get; set; }
        public string Terms { get; set; }
        public byte IsTaxable { get; set; }
        public string TaxCode { get; set; }
        public string TaxCode2 { get; set; }
        public string TaxCode3 { get; set; }
        public string ExemptNumber { get; set; }
        public byte AllowSubstituteItem { get; set; }
        public byte AllowBackOrders { get; set; }
        public byte AllowPartialShipment { get; set; }
        public byte DunningLetter { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string TaxSchedule { get; set; }
        public string CreditCardDescription { get; set; }
        public string CreditCardHolder { get; set; }
        public byte? DefaultInvoiceForm { get; set; }
        public string LocationShort { get; set; }
        public string TaxId { get; set; }
        public byte BillParent { get; set; }
        public decimal? Balance { get; set; }
        public string PhoneExtention { get; set; }
        public byte AutomaticPayment { get; set; }
        public string CustomerCode { get; set; }
        public double PurchaseOrderAmount { get; set; }
        public string CountryOfOrigin { get; set; }
        public byte ChangeCountryOfOrigin { get; set; }
        public string CountryOfAssembly { get; set; }
        public byte ChangeCountryOfAssembly { get; set; }
        public byte PurchaseOrderConfirmation { get; set; }
        public byte RecepientOfCommissions { get; set; }
        public string CreditorType { get; set; }
        public double PercentageToBePaid { get; set; }
        public DateTime? SignDate { get; set; }
        public string ImportOriginCode { get; set; }
        public string ParticipantNumber { get; set; }
        public byte CertifiedSupplier { get; set; }
        public int? FederalIdnumber { get; set; }
        public string FederalIdtype { get; set; }
        public string FederalCategory { get; set; }
        public byte AutoDistribute { get; set; }
        public string SupplierStatus { get; set; }
        public string Fobcode { get; set; }
        public byte PrintPrice { get; set; }
        public byte Acknowledge { get; set; }
        public byte Confirmed { get; set; }
        public string LandedCostCode { get; set; }
        public string LandedCostCode2 { get; set; }
        public string LandedCostCode3 { get; set; }
        public string LandedCostCode4 { get; set; }
        public string LandedCostCode5 { get; set; }
        public string LandedCostCode6 { get; set; }
        public string LandedCostCode7 { get; set; }
        public string LandedCostCode8 { get; set; }
        public string LandedCostCode9 { get; set; }
        public string LandedCostCode10 { get; set; }
        public byte? DefaultPoform { get; set; }
        public string PayeeName { get; set; }
        public string CommodityCode1 { get; set; }
        public string CommodityCode2 { get; set; }
        public string CommodityCode3 { get; set; }
        public string CommodityCode4 { get; set; }
        public string CommodityCode5 { get; set; }
        public int SecurityLevel { get; set; }
        public string ChamberOfCommerce { get; set; }
        public string DunsNumber { get; set; }
        public string TextField11 { get; set; }
        public string TextField12 { get; set; }
        public string TextField13 { get; set; }
        public string TextField14 { get; set; }
        public string TextField15 { get; set; }
        public string TextField16 { get; set; }
        public string TextField17 { get; set; }
        public string TextField18 { get; set; }
        public string TextField19 { get; set; }
        public string TextField20 { get; set; }
        public string TextField21 { get; set; }
        public string TextField22 { get; set; }
        public string TextField23 { get; set; }
        public string TextField24 { get; set; }
        public string TextField25 { get; set; }
        public string TextField26 { get; set; }
        public string TextField27 { get; set; }
        public string TextField28 { get; set; }
        public string TextField29 { get; set; }
        public string TextField30 { get; set; }
        public string PhoneQueue { get; set; }
        public string CmpDirectory { get; set; }
        public Guid? Guidfield1 { get; set; }
        public Guid? Guidfield2 { get; set; }
        public Guid? Guidfield3 { get; set; }
        public Guid? Guidfield4 { get; set; }
        public Guid? Guidfield5 { get; set; }
        public int? NumIntField1 { get; set; }
        public int? NumIntField2 { get; set; }
        public int? NumIntField3 { get; set; }
        public int? NumIntField4 { get; set; }
        public int? NumIntField5 { get; set; }
        public string FedIdtype { get; set; }
        public string FedCategory { get; set; }
        public string RuleItem { get; set; }
        public bool? Substitute { get; set; }
        public short? Division { get; set; }
        public bool? AutoAllocate { get; set; }
        public string Category01 { get; set; }
        public string Category02 { get; set; }
        public string Category03 { get; set; }
        public string Category04 { get; set; }
        public string Category05 { get; set; }
        public string Category06 { get; set; }
        public string Category07 { get; set; }
        public string Category08 { get; set; }
        public string Category09 { get; set; }
        public string Category10 { get; set; }
        public string Category11 { get; set; }
        public string Category12 { get; set; }
        public string Category13 { get; set; }
        public string Category14 { get; set; }
        public string Category15 { get; set; }
        public string FedIdnumber { get; set; }
        public bool? AddExtraReceiptToOrder { get; set; }
        public bool? IsTaxExempted { get; set; }
        public string InvoiceMethod { get; set; }
        public bool? AttachUbl { get; set; }
        public string Mailbox { get; set; }
        public bool? UseAvalaraTaxation { get; set; }
        public bool? IsCommissionable { get; set; }
        public string TerritoryCode { get; set; }
        public bool? IncoTermConfirmPrices { get; set; }
        public bool? IncoTermAcknowledgeOrder { get; set; }
        public string IncoTermCode { get; set; }
        public string IncoTermProperty { get; set; }
        public byte ApplyShippingCharges { get; set; }
        public string VatServices { get; set; }
        public byte ChangeVatServices { get; set; }
        public string AvalaraEntityUseCode { get; set; }
        public Guid? SyncId { get; set; }
        public string CollectiveInvoicesGrouping { get; set; }
        public string LayoutPath { get; set; }
        public string CipaymentCondition { get; set; }
        public bool? UseCollectiveInvoices { get; set; }
        public string Gln { get; set; }
        public string WithholdingCertificate { get; set; }
        public byte IsPayerRejected { get; set; }
        public DateTime? CzwebAccessSince { get; set; }
        public double? DaysFromNow { get; set; }
        public string WithholdingPayer { get; set; }
        public string CspickItcwdatabaseNameSalesDb { get; set; }
        public byte CspickItcwdebtorIsSalesDb { get; set; }
        public string CspickItcwsqlserverSalesDb { get; set; }
        public string CspickItcwwarehouseSalesDb { get; set; }
        public byte CspickItcwallowStockInfo { get; set; }
        public byte CspickItcwimportWarehouse { get; set; }
        public string Cspickitcwcompany { get; set; }
        public string Cspickitcwid { get; set; }
        public byte CspickitcwimportSelectionCode { get; set; }
        public string CspickItcwdatabaseName { get; set; }
        public string CspickItcwdefaultLocation { get; set; }
        public string CspickItcwsqlserverCwdb { get; set; }
        public byte CspickItcwwarehouse { get; set; }
        public string CspickItcwdebtorInCwdb { get; set; }
        public string CspickItcwwarehouseInCwdb { get; set; }
        public byte CspickItcwstock { get; set; }
        public string CspickItcwpurchaseJournal { get; set; }
        public byte CspickitsplitLot { get; set; }
        public byte CspickitcwimportDebtors { get; set; }
        public DateTime? Cspickitcwpostartdate { get; set; }
        public string Cspickitsscc1 { get; set; }
        public string Cspickitsscc2 { get; set; }
        public string CspickItuseMultiLayerSscc { get; set; }
        public string CspickItskutype { get; set; }
        public int CspickItshelfLife { get; set; }
        public string CspickItpickAndPack { get; set; }
        public string SplitPaymentAccount { get; set; }
        public string GroupTaxNumber { get; set; }
        public bool? AggregateContract { get; set; }
        public string EinvoiceEmail { get; set; }
        public string EinvoiceSubmissionFormat { get; set; }
        public string RegistrationCode { get; set; }
        public string AdministrationReference { get; set; }
        public string Cspickitcwfid { get; set; }
        public string Cspickitcwfidpw { get; set; }
    }
}
