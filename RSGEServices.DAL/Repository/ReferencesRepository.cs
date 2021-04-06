using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class ReferencesRepository : IReferencesRepository
    {
        private readonly _150Context db;
        public ReferencesRepository(_150Context db)
        {
            this.db = db;
        }

        public IEnumerable<Amutak> GetAmutak()
        {
            return db.Amutak.ToList();
        }

        public IEnumerable<Btwtrs> GetBtwtrs()
        {
            return db.Btwtrs.ToList();
        }

        public IEnumerable<Kstdr> GetKstdr()
        {
            return db.Kstdr.ToList();
        }

        public IEnumerable<Kstpl> GetKstpl()
        {
            return db.Kstpl.ToList();
        }

        public IEnumerable<Prproject> GetPrproject()
        {
            return db.Prproject.ToList();
        }
    }
}
