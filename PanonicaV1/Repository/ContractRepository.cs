using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PanonicaV1.Models;
using PanonicaV1.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PanonicaV1.Repository
{
    public class ContractRepository : IContractRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Contract contract)
        {
            db.Contracts.Add(contract);
            db.SaveChanges();
        }

        public void Delete(Contract contract)
        {
            db.Contracts.Remove(contract);
            db.SaveChanges();
        }

        public IQueryable<Contract> GetAll()
        {
            return db.Contracts;
        }

        public Contract GetById(int id)
        {
            return db.Contracts.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Contract contract)
        {
            db.Entry(contract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public IQueryable<Contract> GetMost()
        {
            var contracts = GetAll();

            return contracts.OrderByDescending(x => x.ProductsOrdered);

        } ///Proveriti

        public IQueryable<Contract> GetMostRecent() 
        {
            return GetAll().OrderByDescending(x => x.ContractDate);
        } ///Proveriti

       



        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}