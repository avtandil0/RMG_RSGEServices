using RSGEServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSGEServices.DAL.Repository.Interfaces
{
    public interface IAmutak : IRepositoryBase<Amutak>
    {
        Amutak OrderByDescending();
    }
}
