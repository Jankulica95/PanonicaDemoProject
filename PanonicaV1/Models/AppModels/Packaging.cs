using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models
{
    public class Packaging
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv")]
        [StringLength(20, ErrorMessage = "Maksimalno 20 karaktera")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti materijal")]
        [StringLength(20, ErrorMessage = "Maksimalno 20 karaktera")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti cenu")]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti zapreminu")]
        [Range(1, 1000)]
        public decimal Volume { get; set; }


        

    }
}