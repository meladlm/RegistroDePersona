using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroDePersona.Models.ViewModels
{
    // Mostrar elementos en un listado 

    public class ListPersonaViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
    }
}