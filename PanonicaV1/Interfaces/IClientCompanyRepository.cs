using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanonicaV1.Models;

namespace PanonicaV1.Interfaces
{
    public interface IClientCompanyRepository
    {
        IQueryable<ClientCompany> GetAll();
        ClientCompany GetById(int id);
        void Delete(ClientCompany company);
        void Add(ClientCompany company);
        void Update(ClientCompany company);
        


    }
}
