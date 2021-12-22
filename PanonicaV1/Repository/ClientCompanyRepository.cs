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
    public class ClientCompanyRepository : IClientCompanyRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(ClientCompany company)
        {
            db.ClientCompanies.Add(company);
            db.SaveChanges();
        }

        public void Delete(ClientCompany company)
        {
            db.ClientCompanies.Remove(company);
            db.SaveChanges();
        }

        public IQueryable<ClientCompany> GetAll()
        {
            return db.ClientCompanies.AsQueryable();
        }

        public ClientCompany GetById(int id)
        {
            return db.ClientCompanies.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ClientCompany company)
        {
            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }



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