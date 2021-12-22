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
    public class SeasonRepository : ISeasonRepository, IDisposable
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public void Add(Season season)
        {
            db.Seasons.Add(season);
            db.SaveChanges();
        }

        public void Delete(Season season)
        {
            db.Seasons.Remove(season);
            db.SaveChanges();
        }

        public IQueryable<Season> GetAll()
        {
            return db.Seasons;
        }

        public Season GetById(int id)
        {
            return db.Seasons.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Season season)
        {
            db.Entry(season).State = EntityState.Modified;

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
                    db= null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}