using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeleperformanceApi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string NIT { get; set; }
        public bool Status { get; set; }
    }
}
