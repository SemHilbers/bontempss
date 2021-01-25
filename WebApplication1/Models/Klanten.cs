using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Klanten
    {
        [Key]
        [Display(Name = "Klantnummer")]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Naam { get; set; }
        [StringLength(40)]
        public string Adres { get; set; }
        [StringLength(6)]
        [RegularExpression(@"^[1-9]{1}[0-9]{3}[A-Z]{2}$", ErrorMessage = "Postcode invullen als 1234AB")]
        public string Postcode { get; set; }
        [StringLength(25)]
        public string Woonplaats { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Reservering> Reserveringen { get; set; }

    }
}
