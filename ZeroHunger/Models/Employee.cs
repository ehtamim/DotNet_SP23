using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [ForeignKey("NGO")]
        public int NgoId { get; set; }
        public virtual NGO NGO { get; set; }
        public virtual ICollection<AcceptedRequest> AccReq { get; set; }
        public Employee() 
        {
            AccReq = new List<AcceptedRequest>();
        }
    }
}