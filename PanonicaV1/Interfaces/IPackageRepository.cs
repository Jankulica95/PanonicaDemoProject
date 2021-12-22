using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Models;


namespace PanonicaV1.Interfaces
{
    public interface IPackageRepository
    {
        IQueryable<Packaging> GetAll();
        Packaging GetById(int id);
        void Add(Packaging packaging);
        void Update(Packaging packaging);
        void Delete(Packaging packaging);

       // IQueryable<PackagingDTO> GetTimesUsed();


    }
}
