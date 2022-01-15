using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PanonicaV1.Models;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PanonicaV1.Repository
{
    public class PackageRepository : IPackageRepository, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Packaging packaging)
        {
            db.Packages.Add(packaging);
            db.SaveChanges();
        }

        public void Delete(Packaging packaging)
        {
            db.Packages.Remove(packaging);
            db.SaveChanges();
        }

        public IQueryable<Packaging> GetAll()
        {
            return db.Packages;
        }

        public Packaging GetById(int id)
        {
            return db.Packages.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Packaging packaging)
        {
            db.Entry(packaging).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }



        public IQueryable<PackagingDTO> GetTimesUsed()
        {
            throw new NotImplementedException();
        } //Dovrsiti

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
