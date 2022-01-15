using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PanonicaV1.Models;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoMapper;

namespace PanonicaV1.Repository
{
    public class ProductsRepository : IProductRepository, IDisposable
    {
        private ApplicationDbContext db =new ApplicationDbContext();

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
        public void Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
        public IQueryable<Product> GetAll() 
        {
            return db.Products;
        }
        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        public Product GetById(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }


        public IEnumerable<Product> GetAllByPriceDesc()
        {
            return db.Products.OrderByDescending(x => x.Price);
        }
     
      public IEnumerable<Product> GetAllInSeason(int seasonId) 
        {

            var products = GetAll().ToList();
            List<Product> lista = new List<Product>();
            foreach (Product p in products)
            {
                if (p.SeasonId == seasonId)
                {
                    lista.Add(p);
                }
            }

            return lista.AsEnumerable();
     
        public IEnumerable<ProductDTO> GetAllLessThen(int min)
        {
            var list = db.Products
                .Where(x => x.Quantity < min);
            return (IQueryable<ProductDTO>)list;
        } //Ne radi

         //public IQueryable<Product> GetMostSold() //Zavrsiti
        //{
        //    throw new NotImplementedException();
        //}

       
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
