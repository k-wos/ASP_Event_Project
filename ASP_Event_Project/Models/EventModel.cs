using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Models
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Nazwa wydarzenia musi zostać podana")]
        [StringLength(50)]
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Przedział wiekowy musi zostać podany")]
        [DisplayName("Przedział wiekowy")]
        public string AgeRange { get; set; }
        [Required(ErrorMessage = "Miejsce wydarzenia musi zostać podane")]
        [StringLength(100)]
        [DisplayName("Miejsce")]
        public string Place { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Cena")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data")]
        public DateTime EventDate { get; set; }
        public bool Expired { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
