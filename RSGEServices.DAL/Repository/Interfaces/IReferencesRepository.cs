using RSGEServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGEServices.DAL.Repository.Interfaces
{
    public interface IReferencesRepository
    {
        IQueryable<Kstdr> GetKstdr();
        IQueryable<Kstpl> GetKstpl();
        IQueryable<Prproject> GetPrproject();
        IQueryable<Btwtrs> GetBtwtrs();
        IQueryable<Amutak> GetAmutak();
        IQueryable<Gbkmut> GetGbkmut();
        IQueryable<RsgeinvoiceLog> GetRsgeinvoiceLog();
    }
}
