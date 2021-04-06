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
    [Route("api/dagbk")]
    [ApiController]
    public class DagbkController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;


        public DagbkController(IRepositoryWrapper repoWrapper)
        {
            this._repoWrapper = repoWrapper;
        }


        [HttpGet]
        [Route("getDagbk")]
        public  List<DagbkDto> GetDagbk()
        {
            var result = _repoWrapper.Dagbk.FindByCondition(x => x.TypeDgbk == "I").Select(
                r => new DagbkDto
                {
                    Dagbknr = r.Dagbknr,
                    Oms250 = r.Oms250
                }).ToList();

            return result;
        }


    }
}
