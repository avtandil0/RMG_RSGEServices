using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class AmutasRepository : RepositoryBase<Amutas>, IAmutas
    {
        public AmutasRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }

    }
}
