using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models
{
    public class Season
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv")]
        [StringLength(20, ErrorMessage = "Maksimalno 20 karaktera")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezno uneti trajanje")]
        [Range(1,13)]
        public int Duration { get; set; }

    }
}