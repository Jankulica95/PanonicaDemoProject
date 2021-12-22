using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv proizvoda je obavezan")]
        [StringLength(30, ErrorMessage = "Maksimalno 30 karaktera")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM,dd,yyyy}")  ]
        public DateTime? ProductionDate { get; set; }

        [Required(ErrorMessage = "Cena proizvoda je obavezna")]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }


        public int PackagingId { get; set; }
        public Packaging Packaging { get; set; }

        public int SeasonId { get; set; }
        public Season Season { get; set; }
        

        public Product()
        {

        }
    }
}