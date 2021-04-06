using RSGEServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository.Interfaces
{
    public interface IReferencesRepository
    {
        IEnumerable<Kstdr> GetKstdr();
        IEnumerable<Kstpl> GetKstpl();
        IEnumerable<Prproject> GetPrproject();
        IEnumerable<Btwtrs> GetBtwtrs();
        IEnumerable<Amutak> GetAmutak();
    }
}
