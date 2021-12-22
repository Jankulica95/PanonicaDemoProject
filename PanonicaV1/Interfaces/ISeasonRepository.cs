using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanonicaV1.Models;

namespace PanonicaV1.Interfaces
{
    public interface ISeasonRepository
    {
        IQueryable<Season> GetAll();
        Season GetById(int id);
        void Add(Season season);
        void Update(Season season);
        void Delete(Season season);

    }
}
