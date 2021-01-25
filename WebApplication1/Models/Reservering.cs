using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Reserveringen")]
    public class Reservering
    {
        [Key]
        [Display(Name = "Reserveringsnummer")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Datum { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Tijd { get; set; }

        [Required]
        [ForeignKey("Klant")]
        public int KlantId { get; set; }

        public Klanten Klanten { get; set; }
        public virtual ICollection<ReserveringMenu> ReserveringMenus { get; set; }
    }
}
