using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM,dd,yyyy}")]
        public DateTime? ProductionDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public string PackagingName { get; set; }
        public string SeasonName { get; set; }
    }
}