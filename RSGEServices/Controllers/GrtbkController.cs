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
    [Route("api/grtbk")]
    [ApiController]
    public class GrtbkController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;


        public GrtbkController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }

        [HttpGet]
        [Route("getGrtbk")]
        public List<GrtbkDto> GetGrtbk()
        {
            var result = _repoWrapper.Grtbk.FindByCondition(x => x.BalVw == "W" && x.Omzrek == "K").Select(
                r => new GrtbkDto
                {
                    Reknr = r.Reknr,
                    Oms250= r.Oms250
                }).ToList();
            return result;
        }
    }
}