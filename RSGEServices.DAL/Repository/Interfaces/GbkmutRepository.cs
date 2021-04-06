using RSGEServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository.Interfaces
{
    public class GbkmutRepository : RepositoryBase<Gbkmut>, IGbkmutRepository
    {
        public GbkmutRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }

    }
}
