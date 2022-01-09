using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SuperCarsApp.Shared
{
    public class Employee
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El Email es requerido")]

        public string Email { get; set; }
        [Required(ErrorMessage = "El Rol es requerido")]
        public string Rol { get; set; }
       

        public int Sales { get; set; }

    }
}