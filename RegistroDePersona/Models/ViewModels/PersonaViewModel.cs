using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroDePersona.Models.ViewModels
{

    public class PersonaViewModel
    {
        //Anotaciones de la Data para validaciones

        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha De Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeNacimiento { get; set; }

    }
}