using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Models
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string AgeRange { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime EventDate { get; set; }
        public bool Expired { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
