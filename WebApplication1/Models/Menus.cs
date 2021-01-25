using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Menus
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        [Required]
        public string Naam { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Prijs { get; set; }

        public virtual ICollection<MenuGerecht> MenuGerechten { get; set; }
        public virtual ICollection<ReserveringMenu> ReserveringMenus { get; set; }
    }
}
