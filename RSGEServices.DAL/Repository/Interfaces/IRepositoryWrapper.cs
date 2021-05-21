using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        IDagbk Dagbk { get; }
        IGrtbk Grtbk { get; }
        IAmutak Amutak { get; }
        IAmutas Amutas { get; }
        ICicmpyRepository CicmpyRepository { get; }
        IBankTransactions BankTransactions { get; }
        IGbkmutRepository GbkmutRepository { get; }
        IReferencesRepository ReferencesRepository { get; }
        IRsgeInvoiceLog RsgeInvoiceLogRepository{ get; }
        void Save();
    }
}
