using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class FoodRequest
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public string PreserveDate { get; set; }
        [ForeignKey("Resturant")]
        public int ResturantId { get; set; }
        public int Status { get; set;}
        public string Request_Date { get; set; }
        public string Action_Date { get; set; }
        public string Delivery_Date { get; set; }
        public virtual Resturant Resturant { get; set; }
        //public virtual ICollection<Food> food { get; set; }
        public virtual ICollection<AcceptedRequest> AccReq { get; set; }
        public FoodRequest() 
        {
            //food = new List<Food>();
            AccReq = new List<AcceptedRequest>();
        }
    }
}