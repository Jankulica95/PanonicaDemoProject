using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime ContractDate { get; set; }
        public List<Product> ProductsOrdered { get; set; }

        public int ClientCompId { get; set; }
        public ClientCompany ClientComp { get; set; }
       
       
    }
}