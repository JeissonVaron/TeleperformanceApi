using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeleperformanceApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public int IdentificationType { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastname { get; set; }
        public string SecondLastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool AuthorizationToSendMobileMessages { get; set; }
        public bool AuthorizationToSendEmailMessages { get; set; }
    }
}
