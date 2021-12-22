using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models.DTOs
{
    public class PackagingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }        
        public decimal Volume { get; set; }


        public int TimesUsed { get; set; }
        public decimal AllUsedValue { get; set; }
    }
}