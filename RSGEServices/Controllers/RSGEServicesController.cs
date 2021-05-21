using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using NtosService;
using RSGEServices.BLL.Helper;
using RSGEServices.BLL.Models;
using RSGEServices.BLL.Services.Interfaces;
using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;

namespace RSGEServices.Controllers
{
    [Route("api/rsgeservices")]
    [ApiController]
    public class RSGEServicesController : ControllerBase
    {
        //private readonly int USER_ID = 783;
        //private readonly int UN_ID = 731937;
        //private readonly string USER_NAME = "26001004282:206322102";
        //private readonly string USER_PASS = "123456";


        private readonly int USER_ID = 255926;
        private readonly int UN_ID = 1243416;
        //private readonly string USER_NAME = "sps kavkasiis samto jgufi";//
        //private readonly string USER_PASS = "CMG2020";


        //private readonly int USER_ID = 810377;
        //private readonly int UN_ID = 1243416; //კავკასიის სამთო ჯგუფი 815779 
        //private readonly string USER_NAME = "bmosidze";
        //private readonly string USER_PASS = "785207";//Ikako0321

        //private readonly string USER_NAME = "service:01002002543";
        //private readonly string USER_PASS = "NewPass1";

        private readonly string USER_NAME = "test1:404908775";
        private readonly string USER_PASS = "NewPass1";

        private readonly string TIN = "404908775";

        //private readonly string USER_NAME = "404908775";
        //private readonly string USER_PASS = "Ikako0321";

        private readonly IInvoiceService invoiceService;
        private IRepositoryWrapper _repoWrapper;


        public RSGEServicesController(IRepositoryWrapper repoWrapper,IInvoiceService invoiceService)
        {
            this._repoWrapper = repoWrapper;
            this.invoiceService = invoiceService;
        }

        [HttpGet]
        [Route("get_un_id_from_user_id")]
        public async Task<int> get_un_id_from_user_id()
        {
            var invoices = await invoiceService.get_un_id_from_user_idAsync(this.USER_ID, 
                this.USER_NAME, this.USER_PASS);


            return 5;
        }

        [HttpGet]
        [Route("Get_un_id_from_tin")]
        public async Task<int> Get_un_id_from_tin()
        {
            var invoices = await invoiceService.Get_un_id_from_tin(this.USER_ID,this.TIN, 
                this.USER_NAME, this.USER_PASS);


            return invoices.Result.get_un_id_from_tinResult;
        }

        [HttpGet]
        [Route("Get_ser_users")]
        public async Task<get_ser_usersResponse> Get_ser_users()
        {
            var invoices = await invoiceService.Get_ser_users(this.USER_NAME, this.USER_PASS);


            return invoices.Result;
        }

        [HttpGet]
        [Route("getTin")]
        public async Task<get_tin_from_un_idResponse> getTin()
        {
            var invoices = await invoiceService.Get_tin_from_un_id(this.USER_ID, this.UN_ID, 
                this.USER_NAME, this.USER_PASS);


            return invoices.Result;
        }

        [HttpGet]
        [Route("getBuyerInvoicesR")]
        public async Task<string> GetBuyerInvoicesR()
        {
            var invoices = await invoiceService.Get_buyer_invoices_rAsync(this.USER_ID, this.UN_ID, 15,
                this.USER_NAME, this.USER_PASS);

            string jsonText = JsonConvert.SerializeXmlNode(invoices.Result.Any1.FirstChild);

            return jsonText;
        }

        [HttpGet]
        [Route("getBuyerInvoices")]
        public async Task<string> GetBuyerInvoices(DateTime followDateFrom, DateTime followDateTo, string desc)
        {
            var invoices = await invoiceService.Get_buyer_invoicesAsync(this.USER_ID, this.UN_ID,
                DateTime.MinValue, DateTime.MaxValue, followDateFrom, followDateTo,
                "","", desc?? "","",
                this.USER_NAME, this.USER_PASS);

            string jsonText = JsonConvert.SerializeXmlNode(invoices.Result.Any1.FirstChild);

            return jsonText;
        }

        [HttpGet]
        [Route("getInvoiceDesc/{id}")]
        public async Task<string> Get_invoice_descAsync(int id)
        {
            var invoices = await invoiceService.Get_invoice_descAsync(this.USER_ID, id, 
                this.USER_NAME, this.USER_PASS);

            string jsonText = JsonConvert.SerializeXmlNode(invoices.Result.Any1.FirstChild);

            return jsonText;
        }

        [HttpPost]
        [Route("transaction")]
        public async Task<Result> Transaction(TransferObjectDto transferObjectDto)
        {
            var exists = _repoWrapper.RsgeInvoiceLogRepository
                            .FindByCondition(r => r.RsgeinvoiceId == transferObjectDto.Id)
                            .FirstOrDefault(); 

            if(exists != null)
            {
                return new Result(false, 0, "ინვოისი უკვე გატარებულია");
            }
            

            if (string.IsNullOrEmpty(transferObjectDto.Dagbknr))
            {
                return new Result(false, 0, "Journal აუცილებელია");
            }

            if (string.IsNullOrEmpty(transferObjectDto.Reknr))
            {
                return new Result(false, 0, "GL Account აუცილებელია");
            }

            Amutak amu= _repoWrapper.Amutak.FindByCondition(r => r.Dagbknr == transferObjectDto.Dagbknr)
                                 .OrderByDescending(r => r.Faktuurnr).FirstOrDefault();
            
            string computedFaktuurnr = transferObjectDto.Dagbknr + "00001";
            if (amu != null)
            {
                computedFaktuurnr = amu.Faktuurnr;
            }
            Int32 newBFaktuurnr = Int32.Parse(computedFaktuurnr);
            newBFaktuurnr++;

            Amutak amu1 = _repoWrapper.Amutak.FindByCondition(r => r.Dagbknr == transferObjectDto.Dagbknr)
                                    .OrderByDescending(r => r.Bkstnr).FirstOrDefault();
            string computeBkstnr = transferObjectDto.Dagbknr + "00001";
            if (amu1 != null)
            {
                computeBkstnr = amu.Bkstnr;
            }
            //.OrderByDescending().Bkstnr;
            Int32 newBkstnr = Int32.Parse(computeBkstnr);
            newBkstnr++;

            //string computeCrdnr = "";

            var crdnrFromSeller = _repoWrapper.CicmpyRepository.
                                FindByCondition(r => r.VatNumber == transferObjectDto.Seller)
                                .FirstOrDefault();

            if(crdnrFromSeller == null)
            {
                return new Result(false, 0, "Crdnr ვერ მოიძებნა");
            }

            string computeCrdnr = crdnrFromSeller?.Crdnr;

            //try
            //{
            //    computeCrdnr  = _repoWrapper.CicmpyRepository.
            //                    FindByCondition(r => r.VatNumber == transferObjectDto.Seller)
            //                    .FirstOrDefault().Crdnr;
            //}
            //catch (Exception)
            //{

            //    return new Result(false, 0, "Crdnr ვერ მოიძებნა");
            //}
            



            DateTime currentTime = new DateTime();

            var regel = 1;
            //regel unda daiwyos 1-დან ყოველ გატარებაში
            //Amutas am1 = _repoWrapper.Amutas.FindByCondition(r => r.Dagbknr == transferObjectDto.Dagbknr)
            //                     .OrderByDescending(r => r.Regel).FirstOrDefault();

            //string computedRegel = "0";
            //if(am1 != null)
            //{
            //    computedRegel = am1.Regel;
            //}
            //Int32 regel = Int32.Parse(computedRegel);
            //regel++;

            Guid guid = Guid.NewGuid();
            //var volgnr5 = 1;
            Amutas am2 = _repoWrapper.Amutas.FindByCondition(r => r.Dagbknr == transferObjectDto.Dagbknr)
                                 .OrderByDescending(r => r.Volgnr5).FirstOrDefault();
            string computedVolgnr5 = "0";
            if(am2 != null)
            {
                computedVolgnr5 = am2.Volgnr5;
            }
            Int32 volgnr5 = Int32.Parse(computedVolgnr5);
            volgnr5++;





            guid = Guid.NewGuid();


            var dagbknrForReknr = _repoWrapper.Dagbk.FindByCondition(r => r.TypeDgbk == "I"
                && r.Dagbknr == transferObjectDto.Dagbknr).FirstOrDefault();
            if(dagbknrForReknr == null)
            {
                return new Result(false, 0, "Journal ვერ მოიძებნა");
            }

            var reknrForAmutak = dagbknrForReknr.Reknr;

            Amutak amutak1 = _repoWrapper.Amutak.FindByCondition(r => r.Dagbknr == transferObjectDto.Dagbknr)
                                    .OrderByDescending(r => r.Volgnr5).FirstOrDefault();

            var volgnr5ForAmuta = "0";
            if (amutak1 != null)
            {
                volgnr5ForAmuta = amutak1.Volgnr5;
            }
            Int32 volgnr5ForAmutakToInt = Int32.Parse(volgnr5ForAmuta);
            volgnr5ForAmutakToInt++;

            Amutak amutak = new Amutak
            {
                Bkjrcode = (Int16)transferObjectDto.Date.Year,
                Periode = transferObjectDto.Date.Month.ToString().PadLeft(3,' '),
                Dagbknr = transferObjectDto.Dagbknr,
                Volgnr5 = volgnr5.ToString().PadLeft(5,' '),
                Beginsaldo = 0,
                Eindsaldo = 0,
                Bkstnr = (newBkstnr).ToString(),
                Oms25 = transferObjectDto.Comment,
                Datum = transferObjectDto.Date.Date,
                Debnr = null,
                Crdnr = computeCrdnr,
                Bedrag = transferObjectDto.Amount,
                Valcode = "GEL",
                Koers = 1,
                ValBdr = transferObjectDto.Amount,
                Weeknummer = null,
                Transreknr = null,
                Transper = null,
                Betaalref = transferObjectDto.InvoiceNumber,
                Betwijze = "B",
                Betcond = "00",
                Kredbep = "B",
                Bdrkredbep = 0,
                Bdrkredbp2 = 0,
                Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                Vervdatkrd = transferObjectDto.Date.Date,
                Vervdtkrd2 = transferObjectDto.Date.Date,
                Percentag = 0,
                Percentag2 = 0,
                GrekBdr = 0,
                Storno = 0,
                MatchFakt = null,
                Reknr = reknrForAmutak,
                Oorsprong = "A",
                Banksubtyp = null,
                StructM = 0,
                BtwNummer = null,
                AdresCd = null,
                AdresNr = null,
                Afldat = transferObjectDto.Date.Date,
                Guids = null,
                Status = "E",
                Docnumber = transferObjectDto.InvoiceNumber,
                Docdate = transferObjectDto.Date.Date,
                Entryorigin = "I",
                DelResIdentry = 1,
                Crdnote = 0,
                Syscreated = currentTime,
                MatchNr = null,
                Syscreator = 1,
                Amktext = null,
                Sysmodified = currentTime,
                BedrVvaf1 = 0,
                BedrVvaf2 = 0,
                Sysmodifier = 1,
                Sysguid = guid,
                BedrVvaf3 = 0,
                //Timestamp = ?,
                BedrVvaf4 = 0,
                BedrVvaf5 = 0,
                Wisselkrs = 0,
                Kstplcode = transferObjectDto.KstrlCode,
                Kstdrcode = null,
                Faktuurnr = (newBFaktuurnr).ToString(),
                DocumentId = null,
                DocAttachmentId = null,
                CmpWwn = null,
                Project = transferObjectDto.Project,
                BlockOutstandingItem = 0,
                Orderdebtor = null,
                Bankacc = null,
                Entrytype = "N",
                Freefield1 = null,
                Freefield2 = null,
                Freefield3 = null,
                Freefield4 = 0,
                Freefield5 = 0,
                CashRegisterAccount = null,
                Selcode = null,
                Division = 150

            };


            Amutas amutas1 = new Amutas
            {
                Discount = 0,
                ResId = 1,
                Transsubtype = "T",
                Verschil = "0",
                Bkjrcode = (Int16)transferObjectDto.Date.Year,
                Periode = "  " + transferObjectDto.Date.Month.ToString(),
                Dagbknr = transferObjectDto.Dagbknr,
                Volgnr5 =  volgnr5.ToString().PadLeft(5, ' '),
                Regel = regel.ToString().PadLeft(4, ' '),
                //Beginsaldo = 0,
                //Eindsaldo = 0,
                Bkstnr = (newBkstnr).ToString(),
                Oms25 = transferObjectDto.Comment,
                Datum = transferObjectDto.Date.Date,
                Debnr = null,
                Crdnr = null,//computeCrdnr,
                Bedrag = transferObjectDto.Amount - transferObjectDto.Vat,
                BtwBdr = transferObjectDto.Vat,
                BtwGrond = transferObjectDto.Amount - transferObjectDto.Vat,
                Valcode = "GEL",
                Koers = 1,
                ValBdr = transferObjectDto.Amount - transferObjectDto.Vat,
                ValbtwBdr = transferObjectDto.Vat,
                BedrVvaf5 = transferObjectDto.Amount - transferObjectDto.Vat,
                Weeknummer = null,
                //Transreknr = null,
                //Transper = null,
                Betaalref = transferObjectDto.InvoiceNumber,
                Betwijze = "B",
                Betcond = "00",
                Kredbep = "B",
                Bdrkredbep = 0,
                Bdrkredbp2 = 0,
                Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                Vervdatkrd = transferObjectDto.Date.Date,
                Vervdtkrd2 = transferObjectDto.Date.Date,
                //Percentag = 0,
                //Percentag2 = 0,
                //GrekBdr = 0,
                Storno = 0,
                //MatchFakt = null,
                Reknr = transferObjectDto.Reknr,
                //Oorsprong = "A",
                //Banksubtyp = null,
                //StructM = 0,
                BtwNummer = null,
                AdresCd = null,
                AdresNr = null,
                Afldat = transferObjectDto.Date.Date,
                Guids = null,
                //Status = "E",
                Docnumber = transferObjectDto.InvoiceNumber,
                Docdate = transferObjectDto.Date.Date,
                Entryorigin = "N",
                //DelResIdentry = 1,
                Crdnote = 0,
                Syscreated = currentTime,
                MatchNr = null,
                Syscreator = 1,
                //Amktext = null,
                Sysmodified = currentTime,
                BedrVvaf1 = 0,
                BedrVvaf2 = 0,
                Sysmodifier = 1,
                Sysguid = guid,
                BedrVvaf3 = 0,
                //Timestamp = ?,
                BedrVvaf4 = 0,
                Wisselkrs = 0,
                Kstplcode = transferObjectDto.KstrlCode,
                Kstdrcode = null,
                Faktuurnr = (newBFaktuurnr).ToString(),
                DocumentId = null,
                DocAttachmentId = null,
                CmpWwn = null,
                Project = transferObjectDto.Project,
                BlockOutstandingItem = 0,
                Orderdebtor = null,
                Bankacc = null,
                //Entrytype = "N",
                Freefield1 = null,
                Freefield2 = null,
                Freefield3 = null,
                Freefield4 = 0,
                Freefield5 = 0,
                CashRegisterAccount = null,
                //Selcode = null,


                BtwCode = "P01",


                Division = 150

            };

            var reknrForSecondAmutas = _repoWrapper.ReferencesRepository.GetBtwtrs()
                                    .Where(r => r.Btwtrans == "P01").FirstOrDefault().VattoBeClaimed;
            regel++;
            guid = Guid.NewGuid();
            Amutas amutas2 = new Amutas
            {
                Discount = 0,
                ResId = 1,
                Transsubtype = "T",
                Verschil = "0",
                Bkjrcode = (Int16)transferObjectDto.Date.Year,
                Periode = transferObjectDto.Date.Month.ToString().PadLeft(3, ' '),
                Dagbknr = transferObjectDto.Dagbknr,
                Volgnr5 = volgnr5.ToString().PadLeft(5, ' '),
                Regel = regel.ToString().PadLeft(4, ' '),
                //Beginsaldo = 0,
                //Eindsaldo = 0,
                Bkstnr = (newBkstnr).ToString(),
                Oms25 = transferObjectDto.Comment,
                Datum = transferObjectDto.Date.Date,
                Debnr = null,
                Crdnr = null,//computeCrdnr,
                Bedrag = transferObjectDto.Vat,
                BtwBdr = transferObjectDto.Vat,
                BtwGrond = transferObjectDto.Amount - transferObjectDto.Vat,
                ValbtwBdr = transferObjectDto.Vat,
                BedrVvaf5 = transferObjectDto.Amount - transferObjectDto.Vat,
                Valcode = "GEL",
                Koers = 1,
                ValBdr = transferObjectDto.Vat,
                Weeknummer = null,
                //Transreknr = null,
                //Transper = null,
                Betaalref = transferObjectDto.InvoiceNumber,
                Betwijze = "B",
                Betcond = "00",
                Kredbep = "B",
                Bdrkredbep = 0,
                Bdrkredbp2 = 0,
                Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                Vervdatkrd = transferObjectDto.Date.Date,
                Vervdtkrd2 = transferObjectDto.Date.Date,
                //Percentag = 0,
                //Percentag2 = 0,
                //GrekBdr = 0,
                Storno = 0,
                //MatchFakt = null,
                Reknr = reknrForSecondAmutas,
                //Oorsprong = "A",
                //Banksubtyp = null,
                //StructM = 0,
                
                BtwNummer = null,
                AdresCd = null,
                AdresNr = null,
                Afldat = transferObjectDto.Date.Date,
                Guids = null,
                //Status = "E",
                Docnumber = transferObjectDto.InvoiceNumber,
                Docdate = transferObjectDto.Date.Date,
                Entryorigin = "N",
                //DelResIdentry = 1,
                Crdnote = 0,
                Syscreated = currentTime,
                MatchNr = null,
                Syscreator = 1,
                //Amktext = null,
                Sysmodified = currentTime,
                BedrVvaf1 = 0,
                BedrVvaf2 = 0,
                Sysmodifier = 1,
                Sysguid = guid,
                BedrVvaf3 = 0,
                //Timestamp = ?,
                BedrVvaf4 = 0,
                Wisselkrs = 0,
                Kstplcode = transferObjectDto.KstrlCode,
                Kstdrcode = null,
                Faktuurnr = (newBFaktuurnr).ToString(),
                DocumentId = null,
                DocAttachmentId = null,
                CmpWwn = null,
                Project = transferObjectDto.Project,
                BlockOutstandingItem = 0,
                Orderdebtor = null,
                Bankacc = null,
                //Entrytype = "N",
                Freefield1 = null,
                Freefield2 = null,
                Freefield3 = null,
                Freefield4 = 0,
                Freefield5 = 0,
                CashRegisterAccount = null,
                //Selcode = null,

                BtwCode = transferObjectDto.Vat == 0? "P00" : "P01" ,


                Division = 150

            };




            //var result = _repoWrapper.BankTransactions.c




            Gbkmut gbkmut1 = new Gbkmut
            {
                
                 Regelcode = "B",
                 Bkjrcode = (Int16)transferObjectDto.Date.Year,
                 Reknr = amutas1.Reknr,
                 Datum = transferObjectDto.Date.Date,
                 Periode = transferObjectDto.Date.Month.ToString().PadLeft(3, ' '),
                 Bkstnr = (newBkstnr).ToString(),
                 Dagbknr = transferObjectDto.Dagbknr,
                 Oms25 = transferObjectDto.Comment,
                 BdrHfl = amutas1.Bedrag,
                BtwCode = transferObjectDto.Vat == 0 ? "P00" : "P01",
                BtwBdr3 = transferObjectDto.Vat,
                 BtwGrond = transferObjectDto.Amount - transferObjectDto.Vat,
                 Tegreknr = amutak.Reknr,
                 Debnr = null,
                 Crdnr = amutak.Crdnr,
                 Kstplcode = transferObjectDto.KstrlCode,
                 Kstdrcode = null,
                 Aantal = 0,
                 Valcode = "GEL",
                 Exvalcode = null,
                 Koers = 1,
                 Wisselkrs = 1,
                 Koers3 = 1,
                 BdrVal = transferObjectDto.Amount - transferObjectDto.Vat,
                 DbkVerwnr = 0,
                 Verwerknrl = 0,
                 Volgnr5 = amutak.Volgnr5,
                 Regel = amutas1.Regel,
                 Storno = 0,
                 BkstnrSub = null,
                 Betcond = null,
                 Btwper = 18,
                 Oorsprong = "A",
                 VlgnGbk2 = null,
                 BtwGrval = transferObjectDto.Amount - transferObjectDto.Vat,
                 Afldat = transferObjectDto.Date.Date,
                 Docnumber = transferObjectDto.InvoiceNumber,
                 Docdate = transferObjectDto.Date.Date,
                 Exvalbdr = 0,
                 Entryorigin = "N",
                 Vervdatkrd = null,
                 Vervdtkrd2 = null,
                 Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                 Kredbep = "K",
                 Bdrkredbep = 0,
                 Bdrkredbp2 = 0,
                 Betaalref = transferObjectDto.InvoiceNumber,
                 StatNr = 0,
                 BtwNummer = null,
                 Rapnr = null,
                 Raplist = null,
                 Artcode = null,
                 Faktuurnr = (newBFaktuurnr).ToString(),
                 BudVers = null,
                 Syscreated = currentTime,
                 Syscreator = 1,
                 ReminderCount = 0,
                 Sysmodified = currentTime,
                 ReminderLayout = 0,
                 LastReminderDate = null,
                 Sysmodifier = 1,
                 Sysguid = Guid.NewGuid(),
                 BlockItem = 0,
                 CompanyCode = "150",
                 ResId = 1,
                 TransactionType = 100,
                 CurrencyCode = "GEL",
                 Rate  = 1,
                 Bankacc = null,
                 AmountCentral = transferObjectDto.Amount - transferObjectDto.Vat,
                 VatBaseAmountCentral = transferObjectDto.Amount - transferObjectDto.Vat,
                 PaymentMethod = "B",
                 VatAmountCentral = transferObjectDto.Vat,
                 CurrencyAliasAc = "GEL",
                 DocumentId = null,
                 Facode = null,
                 Transtype = "N",
                 Transsubtype = "T",
                 //Freefield1 = null,
                 //Freefield2 = null,
                 //Freefield3 = null,
                 Freefield4 = 0,
                 Freefield5 = 0,
                 Project = transferObjectDto.Project,
                 //DocAttachmentId = null,
                 //CmpWwn = null,
                 //Warehouse = null,
                 //Orderdebtor = null,
                 //PayrollSubtype = null,
                 //ReconcileNumber = null,
                 //WarehouseLocation = null,
                 EntryGuid = amutak.Sysguid,
                 TransactionGuid = amutas1.Sysguid,
                 TransactionGuid2 = null,
                 Checked = 0,
                 Reviewed = 0,
                 //BankTransactionGuid = null,
                 //StockTrackingNumber = null,
                 //StartTime = null,
                 //EndTime = null,
                 //ReportingDate = null,
                 //CashRegisterAccount = null,
                 //OriginalQuantity = null,
                 //CompCode = null,
                 //Selcode = null,
                 //Unitcode = null,
                 //Pricelist = null,
                 Discount = 0,
                 //Shipment = null,
                 //IntTransportMethod = null,
                 //IntPort = null,
                 //IntSystem = null,
                 //IntTransA = null,
                 //IntStatNr = null,
                 //IntStandardCode = null,
                 //IntTransShipment = null,
                 //IntTransB = null,
                 //IntArea = null,
                 //IntLandIso = null,
                 //IntLandDestOrig = null,
                 //IntDeliveryMethod = null,
                 //IntStatUnit = null,
                 //IntWeight = null,
                 IntComplete = 0,
                 TaxBasis2 = 0,
                 TaxBasis3 = 0,
                 TaxBasis4 = 0,
                 TaxBasis5 = 0,
                 TaxAmount2 = 0,
                 TaxAmount3 = 0,
                 TaxAmount4 = 0,
                 TaxAmount5 = 0,
                 Division = 150,
                 Type = 0,
                 StatementNumber = "0".PadRight(10, ' '),
                 OfficialExchangeRate = 0,
                 OfficialAmountDc = 0,
                 OfficialBasisDc = 0,
                 CspickItcworsrgIdcwdb = 0,
                 CspickItmodifyQuantity = 0,
            };


            Gbkmut gbkmut2 = new Gbkmut
            {
                Regelcode = "K",
                Bkjrcode = (Int16)transferObjectDto.Date.Year,
                Reknr = amutas2.Reknr,
                Datum = transferObjectDto.Date.Date,
                Periode = transferObjectDto.Date.Month.ToString().PadLeft(3, ' '),
                Bkstnr = (newBkstnr).ToString(),
                Dagbknr = transferObjectDto.Dagbknr,
                Oms25 = transferObjectDto.Comment,
                BdrHfl = transferObjectDto.Vat,
                BtwCode = transferObjectDto.Vat == 0 ? "P00" : "P01",
                BtwBdr3 = transferObjectDto.Vat,
                BtwGrond = transferObjectDto.Amount - transferObjectDto.Vat,
                Tegreknr = amutak.Reknr,
                Debnr = null,
                Crdnr = "     1      ",
                Kstplcode = transferObjectDto.KstrlCode,
                Kstdrcode = null,
                Aantal = 0,
                Valcode = "GEL",
                Exvalcode = null,
                Koers = 1,
                Wisselkrs = 1,
                Koers3 = 1,
                BdrVal = transferObjectDto.Vat,
                DbkVerwnr = 0,
                Verwerknrl = 0,
                Volgnr5 = amutak.Volgnr5,
                Regel = amutas2.Regel,
                Storno = 0,
                BkstnrSub = null,
                Betcond = null,
                Btwper = 18,
                Oorsprong = "A",
                VlgnGbk2 = null,
                BtwGrval = transferObjectDto.Amount - transferObjectDto.Vat,
                Afldat = transferObjectDto.Date.Date,
                Docnumber = transferObjectDto.InvoiceNumber,
                Docdate = transferObjectDto.Date.Date,
                Exvalbdr = 0,
                Entryorigin = "N",
                Vervdatkrd = null,
                Vervdtkrd2 = null,
                Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                Kredbep = "K",
                Bdrkredbep = 0,
                Bdrkredbp2 = 0,
                Betaalref = transferObjectDto.InvoiceNumber,
                StatNr = 0,
                BtwNummer = null,
                Rapnr = null,
                Raplist = null,
                Artcode = null,
                Faktuurnr = (newBFaktuurnr).ToString(),
                BudVers = null,
                Syscreated = currentTime,
                Syscreator = 1,
                ReminderCount = 0,
                Sysmodified = currentTime,
                ReminderLayout = 0,
                LastReminderDate = null,
                Sysmodifier = 1,
                Sysguid = Guid.NewGuid(),
                BlockItem = 0,
                CompanyCode = "150",
                ResId = 1,
                TransactionType = 100,
                CurrencyCode = "GEL",
                Rate = 1,
                Bankacc = null,
                AmountCentral =  transferObjectDto.Vat,
                VatBaseAmountCentral = transferObjectDto.Amount - transferObjectDto.Vat,
                PaymentMethod = "B",
                VatAmountCentral = transferObjectDto.Vat,
                CurrencyAliasAc = "GEL",
                DocumentId = null,
                Facode = null,
                Transtype = "N",
                Transsubtype = "T",
                //Freefield1 = null,
                //Freefield2 = null,
                //Freefield3 = null,
                Freefield4 = 0,
                Freefield5 = 0,
                Project = transferObjectDto.Project,
                //DocAttachmentId = null,
                //CmpWwn = null,
                //Warehouse = null,
                //Orderdebtor = null,
                //PayrollSubtype = null,
                //ReconcileNumber = null,
                //WarehouseLocation = null,
                EntryGuid = amutak.Sysguid,
                TransactionGuid = amutas2.Sysguid,
                TransactionGuid2 = null,
                Checked = 0,
                Reviewed = 0,
                //BankTransactionGuid = null,
                //StockTrackingNumber = null,
                //StartTime = null,
                //EndTime = null,
                //ReportingDate = null,
                //CashRegisterAccount = null,
                //OriginalQuantity = null,
                //CompCode = null,
                //Selcode = null,
                //Unitcode = null,
                //Pricelist = null,
                Discount = 0,
                //Shipment = null,
                //IntTransportMethod = null,
                //IntPort = null,
                //IntSystem = null,
                //IntTransA = null,
                //IntStatNr = null,
                //IntStandardCode = null,
                //IntTransShipment = null,
                //IntTransB = null,
                //IntArea = null,
                //IntLandIso = null,
                //IntLandDestOrig = null,
                //IntDeliveryMethod = null,
                //IntStatUnit = null,
                //IntWeight = null,
                IntComplete = 0,
                TaxBasis2 = 0,
                TaxBasis3 = 0,
                TaxBasis4 = 0,
                TaxBasis5 = 0,
                TaxAmount2 = 0,
                TaxAmount3 = 0,
                TaxAmount4 = 0,
                TaxAmount5 = 0,
                Division = 150,
                Type = 0,
                StatementNumber = "0         ",
                OfficialExchangeRate = 0,
                OfficialAmountDc = 0,
                OfficialBasisDc = 0,
                CspickItcworsrgIdcwdb = 0,
                CspickItmodifyQuantity = 0,
            };


            Gbkmut gbkmut3 = new Gbkmut
            {
                Regelcode = "A",
                Bkjrcode = (Int16)transferObjectDto.Date.Year,
                Reknr = amutak.Reknr,
                Datum = transferObjectDto.Date.Date,
                Periode = transferObjectDto.Date.Month.ToString().PadLeft(3, ' '),
                Bkstnr = (newBkstnr).ToString(),
                Dagbknr = transferObjectDto.Dagbknr,
                Oms25 = transferObjectDto.Comment,
                BdrHfl = -transferObjectDto.Amount,
                BtwCode = "0".PadRight(6, ' '),
                BtwBdr3 = 0,
                BtwGrond = 0,
                Tegreknr = null,
                Debnr = null,
                Crdnr = amutak.Crdnr,
                Kstplcode = transferObjectDto.KstrlCode,
                Kstdrcode = null,
                Aantal = 0,
                Valcode = "GEL",
                Exvalcode = "GEL",
                Koers = 1,
                Wisselkrs = 1,
                Koers3 = 1,
                BdrVal = -transferObjectDto.Amount,
                DbkVerwnr = 0,
                Verwerknrl = 0,
                Volgnr5 = amutak.Volgnr5,
                Regel = "0".PadLeft(4, ' '),
                Storno = 0,
                BkstnrSub = null,
                Betcond = "00",
                Btwper = 0,
                Oorsprong = "A",
                VlgnGbk2 = null,
                BtwGrval = 0,
                Afldat = transferObjectDto.Date.Date,
                Docnumber = transferObjectDto.InvoiceNumber,
                Docdate = transferObjectDto.Date.Date,
                Exvalbdr = -transferObjectDto.Amount,
                Entryorigin = "I",
                Vervdatkrd = transferObjectDto.Date.Date,
                Vervdtkrd2 = transferObjectDto.Date.Date,
                Vervdatfak = transferObjectDto.Date.Date.AddDays(1),
                Kredbep = "B",
                Bdrkredbep = 0,
                Bdrkredbp2 = 0,
                Betaalref = transferObjectDto.InvoiceNumber,
                StatNr = 0,
                BtwNummer = null,
                Rapnr = null,
                Raplist = null,
                Artcode = null,
                Faktuurnr = (newBFaktuurnr).ToString(),
                BudVers = null,
                Syscreated = currentTime,
                Syscreator = 1,
                ReminderCount = 0,
                Sysmodified = currentTime,
                ReminderLayout = 0,
                LastReminderDate = null,
                Sysmodifier = 1,
                Sysguid = Guid.NewGuid(),
                BlockItem = 0,
                CompanyCode = "150",
                ResId = 1,
                TransactionType = 100,
                CurrencyCode = "GEL",
                Rate = 1,
                Bankacc = null,
                AmountCentral = -transferObjectDto.Amount,
                VatBaseAmountCentral = 0,
                PaymentMethod = "B",
                VatAmountCentral = 0,
                CurrencyAliasAc = "GEL",
                DocumentId = null,
                Facode = null,
                Transtype = "N",
                Transsubtype = "T",
                //Freefield1 = null,
                //Freefield2 = null,
                //Freefield3 = null,
                Freefield4 = 0,
                Freefield5 = 0,
                Project = transferObjectDto.Project,
                //DocAttachmentId = null,
                //CmpWwn = null,
                //Warehouse = null,
                //Orderdebtor = null,
                //PayrollSubtype = null,
                //ReconcileNumber = null,
                //WarehouseLocation = null,
                EntryGuid = amutak.Sysguid,
                TransactionGuid = Guid.NewGuid(),
                TransactionGuid2 = null,
                Checked = 0,
                Reviewed = 0,
                //BankTransactionGuid = null,
                //StockTrackingNumber = null,
                //StartTime = null,
                //EndTime = null,
                //ReportingDate = null,
                //CashRegisterAccount = null,
                //OriginalQuantity = null,
                //CompCode = null,
                //Selcode = null,
                //Unitcode = null,
                //Pricelist = null,
                Discount = 0,
                //Shipment = null,
                //IntTransportMethod = null,
                //IntPort = null,
                //IntSystem = null,
                //IntTransA = null,
                //IntStatNr = null,
                //IntStandardCode = null,
                //IntTransShipment = null,
                //IntTransB = null,
                //IntArea = null,
                //IntLandIso = null,
                //IntLandDestOrig = null,
                //IntDeliveryMethod = null,
                IntStatUnit = 0,
                IntWeight = 0,
                PayrollCosts = 0,
                IntComplete = 0,
                TaxBasis2 = 0,
                TaxBasis3 = 0,
                TaxBasis4 = 0,
                TaxBasis5 = 0,
                TaxAmount2 = 0,
                TaxAmount3 = 0,
                TaxAmount4 = 0,
                TaxAmount5 = 0,
                StatisticalFactor = 0,  
                Division = 150,
                Type = 0,
                StatementNumber = "0         ",
                OfficialExchangeRate = 0,
                OfficialAmountDc = 0,
                OfficialBasisDc = 0,
                CspickItcworsrgIdcwdb = 0,
                CspickItmodifyQuantity = 0,
            };

            BankTransactions bankTransactions1 = new BankTransactions
            {
                EntryNumber = gbkmut3.Bkstnr,
                Type = "W",
                BatchNumber = 0,
                TransactionType = "T",
                Status = "C",
                PaymentMethod = "T",
                CreditorNumber = gbkmut3.Crdnr,
                ExchangeRate = 1,
                Tccode = "GEL",
                AmountDc = gbkmut3.BdrHfl,
                AmountTc = gbkmut3.BdrHfl,
                OffsetReference = gbkmut3.Docnumber,
                OffsetCountryCode = "GE ",
                Description = gbkmut3.Oms25,
                Blocked = 0,
                ProcessingDate = gbkmut3.Datum,
                InvoiceNumber = gbkmut3.Faktuurnr,
                StatementNumber = "0         ",
                StatementLineNumber = "0     ",
                OffsetLedgerAccountNumber = gbkmut3.Reknr,
                SupplierInvoiceNumber = gbkmut3.Docnumber,
                DueDate = gbkmut3.Datum.Value.AddDays(1),
                HumanResourceId = 0,
                PaymentType = "B",
                Bedrnr = "150",
                InvoiceDate = gbkmut3.Datum,
                Prepayment = 0,
                PaymentCondition = "00",
                Approver = 0,
                Vatcode = "0  ",
                Processor = 0,
                Approver2 = 0,
                Journalizer = 0,
                TermPercentage = 1,
                DepositNumber = 0,
                PaymentDays = 1,
                ExtraCurrencyAmount = 0,
                MaturityDays = 0,
                Syscreated = currentTime,
                Syscreator = 1,
                Sysmodified = currentTime,
                Sysmodifier = 1,
                Sysguid = Guid.NewGuid(),
                Division = 150,
                ImportAutoMatch = false,
                ReportingDate = gbkmut3.Datum,
                EntryGuid = gbkmut3.EntryGuid,
                OfficialExchangeRate = 0,
                OfficialAmountDc = 0,
                OfficialBasisDc = 0,
                IsUrgent = false,
                Verified = 0
            };

            BankTransactions bankTransactions2 = new BankTransactions
            {
                EntryNumber = gbkmut3.Bkstnr,
                Type = "W",
                BatchNumber = 0,
                TransactionType = "T",
                Status = "C",
                PaymentMethod = "T",
                CreditorNumber = "1",
                ExchangeRate = 1,
                Tccode = "GEL",
                AmountDc = gbkmut2.BdrHfl,
                AmountTc = gbkmut2.BdrHfl,
                OffsetReference = gbkmut3.Docnumber,
                OffsetCountryCode = "GE ",
                Description = gbkmut3.Oms25,
                Blocked = 0,
                ProcessingDate = gbkmut3.Datum,
                InvoiceNumber = gbkmut3.Faktuurnr,
                StatementNumber = "0         ",
                StatementLineNumber = "0     ",
                OffsetLedgerAccountNumber = gbkmut2.Reknr,
                SupplierInvoiceNumber = gbkmut3.Docnumber,
                DueDate = gbkmut3.Datum.Value.AddMonths(2),
                HumanResourceId = 0,
                PaymentType = "B",
                Bedrnr = "150",
                InvoiceDate = gbkmut3.Datum,
                Prepayment = 0,
                //PaymentCondition = "00",
                Approver = 0,
                Vatcode = "P01",
                Processor = 0,
                Approver2 = 0,
                Journalizer = 0,
                TermPercentage = 1,
                DepositNumber = 0,
                PaymentDays = 0,
                ExtraCurrencyAmount = 0,
                MaturityDays = 0,
                Syscreated = currentTime,
                Syscreator = 1,
                Sysmodified = currentTime,
                Sysmodifier = 1,
                Sysguid = Guid.NewGuid(),
                Division = 150,
                ImportAutoMatch = false,
                ReportingDate = gbkmut3.Datum,
                EntryGuid = gbkmut3.EntryGuid,
                OfficialExchangeRate = 0,
                OfficialAmountDc = 0,
                OfficialBasisDc = 0,
                IsUrgent = false,
                Verified = 0
            };

            var currentDate = DateTime.Now;
            RsgeinvoiceLog rsgeInvoicesLog1 = new RsgeinvoiceLog
            {
                RsgeinvoiceId = transferObjectDto.Id,
                DateCreated = currentDate
            };
            RsgeinvoiceLog rsgeInvoicesLog2 = new RsgeinvoiceLog
            {
                RsgeinvoiceId = transferObjectDto.Id,
                DateCreated = currentDate
            };
            RsgeinvoiceLog rsgeInvoicesLog3 = new RsgeinvoiceLog
            {
                RsgeinvoiceId = transferObjectDto.Id,
                DateCreated = currentDate
            };

            _repoWrapper.Amutas.Create(amutas1);
            _repoWrapper.Amutas.Create(amutas2);
            _repoWrapper.Amutak.Create(amutak);

            _repoWrapper.GbkmutRepository.Create(gbkmut1);
            _repoWrapper.GbkmutRepository.Create(gbkmut2);
            _repoWrapper.GbkmutRepository.Create(gbkmut3);

            _repoWrapper.RsgeInvoiceLogRepository.Create(rsgeInvoicesLog1);
            _repoWrapper.RsgeInvoiceLogRepository.Create(rsgeInvoicesLog2);
            _repoWrapper.RsgeInvoiceLogRepository.Create(rsgeInvoicesLog3);

            _repoWrapper.BankTransactions.Create(bankTransactions1);
            _repoWrapper.BankTransactions.Create(bankTransactions2);



            try
            {
                _repoWrapper.Save();
                return new Result(true, 1, "წარმატებით დასრულდა");
            }
            catch (Exception e)
            {
                return new Result(false, 0, "დაფიქსირდა შეცდომა" + e.Message);
            }
           
            
        }


    }
}