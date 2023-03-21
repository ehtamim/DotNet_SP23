using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class AcceptedRequest
    {
        public int Id { get; set; }
        [ForeignKey("FoodRequest")]
        public int FoodRequestId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        //public DateTime DeliveryDate { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FoodRequest FoodRequest { get; set; }
    }
}