using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanonicaV1.Models;
using PanonicaV1.Models.DTOs;


namespace PanonicaV1.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
        void Add(Product product);
        void Delete(Product product);

        IEnumerable<ProductDTO> GetAllInSeason(int seasonId); //Svi proizvodi u jednoj odredjenoj sezoni

        ///IQueryable<Product> GetMostSold(); // 3 najprodavanija
        IEnumerable<Product> GetAllByPriceDesc(); //Prikazati sve pocevsi od najskupljeg
        IEnumerable<ProductDTO> GetAllLessThen(int min); //Proizvodi kojih na stanju ima manje od zadate vrednosti


    }
}
