using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeleperformanceApi.DTOs
{
    public class CompanyDTO
    {
        [Required]
        public string NIT { get; set; }
        public bool Status { get; set; }
    }
}
