using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System. ComponentModel. DataAnnotations;

namespace ASPNETMVCCRUD.Models
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        [Required]
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}