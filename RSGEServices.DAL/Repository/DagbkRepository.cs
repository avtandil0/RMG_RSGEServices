using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class DagbkRepository : RepositoryBase<Dagbk>, IDagbk
    {
        public DagbkRepository(_150Context repositoryContext)
           : base(repositoryContext)
        {
        }
       
    }
}
