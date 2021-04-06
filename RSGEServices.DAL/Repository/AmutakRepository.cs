using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class AmutakRepository : RepositoryBase<Amutak>, IAmutak
    {
        public AmutakRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }

        public Amutak OrderByDescending()
        {
            return RepositoryContext.Amutak.OrderByDescending(r => r.Bkstnr).FirstOrDefault();
        }

        //public System.Linq.IQueryable<string> Max()
        //{
        //    return RepositoryContext.Amutak
        //                    .Max(r => r.Bkstnr)
        //                    .Select(c => c);

        //}
    }
}
