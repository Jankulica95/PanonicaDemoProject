using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PanonicaV1.Models
{
    public class ClientCompany
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obavezno je unetinaziv")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti PIB")]
        public int PIB { get; set; }
        
    }
}