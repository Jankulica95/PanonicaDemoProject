using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanonicaV1.Models;

namespace PanonicaV1.Interfaces
{
    public interface IContractRepository
    {
        IQueryable<Contract> GetAll();
        Contract GetById(int id);
        void Add(Contract contract);
        void Update(Contract contract);
        void Delete(Contract contract);

        
        IQueryable<Contract> GetMost(); //Ugovor sa najvise porucenih proizvoda
        IQueryable<Contract> GetMostRecent(); //Poslednja 3 ugovorena
    }
}
