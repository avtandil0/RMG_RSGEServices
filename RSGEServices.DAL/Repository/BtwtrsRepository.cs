using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class BtwtrsRepository : RepositoryBase<BtwtrsRepository>, IBtwtrsRepository
    {
        public BtwtrsRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }

    }
}
