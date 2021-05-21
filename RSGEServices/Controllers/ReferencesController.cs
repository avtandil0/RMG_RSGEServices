using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSGEServices.BLL.Models.DTO;
using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;

namespace RSGEServices.Controllers
{
    [Route("api/references")]
    [ApiController]
    public class ReferencesController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;


        public ReferencesController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        [HttpGet]
        [Route("getKstdr")]
        public IEnumerable<KstdrDto> GetKstdr()
        {
            var result = _repoWrapper.ReferencesRepository.GetKstdr().Select(r => new KstdrDto
            {
                Kstdrcode = r.Kstdrcode,
                Id = r.Id,
                Oms250 = r.Oms250
            });
            return result;
        }

        [HttpGet]
        [Route("getKstpl")]
        public IEnumerable<KstplDto> GetKstpl()
        {
            var result = _repoWrapper.ReferencesRepository.GetKstpl().Select(r => new KstplDto
            {
                Kstplcode = r.Kstplcode,
                Oms250 = r.Oms250
            });
            return result;
        }

        [HttpGet]
        [Route("getPrproject")]
        public IEnumerable<PrprojectDto> GetPrproject()
        {
            var result = _repoWrapper.ReferencesRepository.GetPrproject().Select(r => new PrprojectDto
            {
                ProjectNr = r.ProjectNr,
                Description = r.Description
            }).ToList();
            return result;
        }

        [HttpGet]
        [Route("getRsgeinvoiceLog")]
        public IEnumerable<string> GetRsgeinvoiceLog()
        {
            var result = _repoWrapper.RsgeInvoiceLogRepository.FindAll().Select(r => r.RsgeinvoiceId).Distinct();
            return result;
        }

        //[HttpGet]
        //[Route("getGbkmut")]
        //public IEnumerable<GbkmutDto> GetGbkmut()
        //{
        //    var result = _repoWrapper.ReferencesRepository.GetGbkmut()
        //            .Where(r => r.RsgeinvoiceId == null).Select(r => new GbkmutDto
        //    {
        //        ID = r.Id,
        //        RSGEStatementId = r.RsgeinvoiceId
        //            });
        //    return result;
        //}
    }
}