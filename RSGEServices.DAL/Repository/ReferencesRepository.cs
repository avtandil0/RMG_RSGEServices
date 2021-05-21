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

        public IQueryable<Amutak> GetAmutak()
        {
            return db.Amutak;
        }

        public IQueryable<Btwtrs> GetBtwtrs()
        {
            return db.Btwtrs;
        }

        public IQueryable<Kstdr> GetKstdr()
        {
            return db.Kstdr;
        }

        public IQueryable<Kstpl> GetKstpl()
        {
            return db.Kstpl;
        }

        public IQueryable<Prproject> GetPrproject()
        {
            return db.Prproject;
        }

        public IQueryable<Gbkmut> GetGbkmut()
        {
            return db.Gbkmut;
        }

        public IQueryable<RsgeinvoiceLog> GetRsgeinvoiceLog()
        {
            return db.RsgeinvoiceLog;
        }
    }
}
