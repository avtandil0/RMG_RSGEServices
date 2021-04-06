using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class GrtbkRepository : RepositoryBase<Grtbk>, IGrtbk
    {
        public GrtbkRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }

    }
}
