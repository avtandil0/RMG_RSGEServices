using RSGEServices.DAL.Models;
using RSGEServices.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.DAL.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private _150Context _repoContext;
        private IDagbk _dagbk;
        private IGrtbk _grtbk;
        private IAmutak _amutak;
        private IAmutas _amutas;
        private IBankTransactions _bankTransactions;
        private IReferencesRepository _referencesRepository;
        private ICicmpyRepository _cicmpyRepository;
        private IGbkmutRepository _gbkmutRepository;
        private IRsgeInvoiceLog _rsgeInvoiceLog;

        public IRsgeInvoiceLog RsgeInvoiceLogRepository
        {
            get
            {
                if (_rsgeInvoiceLog == null)
                {
                    _rsgeInvoiceLog = new RSGEInvoiceLogRepository(_repoContext);
                }

                return _rsgeInvoiceLog;
            }
        }

        public ICicmpyRepository CicmpyRepository
        {
            get
            {
                if (_cicmpyRepository == null)
                {
                    _cicmpyRepository = new CicmpyRepository(_repoContext);
                }

                return _cicmpyRepository;
            }
        }

        public IReferencesRepository ReferencesRepository
        {
            get
            {
                if (_referencesRepository == null)
                {
                    _referencesRepository = new ReferencesRepository(_repoContext);
                }

                return _referencesRepository;
            }
        }

        public IBankTransactions BankTransactions
        {
            get
            {
                if (_bankTransactions == null)
                {
                    _bankTransactions = new BankTransactionsRepository(_repoContext);
                }

                return _bankTransactions;
            }
        }
        public IAmutas Amutas
        {
            get
            {
                if (_amutas == null)
                {
                    _amutas = new AmutasRepository(_repoContext);
                }

                return _amutas;
            }
        }
        public IAmutak Amutak
        {
            get
            {
                if (_amutak == null)
                {
                    _amutak = new AmutakRepository(_repoContext);
                }

                return _amutak;
            }
        }

        public IGrtbk Grtbk
        {
            get
            {
                if (_grtbk == null)
                {
                    _grtbk = new GrtbkRepository(_repoContext);
                }

                return _grtbk;
            }
        }
        public IDagbk Dagbk
        {
            get
            {
                if (_dagbk == null)
                {
                    _dagbk = new DagbkRepository(_repoContext);
                }

                return _dagbk;
            }
        }

        public IGbkmutRepository GbkmutRepository
        {
            get
            {
                if (_gbkmutRepository == null)
                {
                    _gbkmutRepository = new GbkmutRepository(_repoContext);
                }

                return _gbkmutRepository;
            }
        }

        public RepositoryWrapper(_150Context repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
       
    }
}
