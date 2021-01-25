using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReserveringMenu
    {
        [Required]
        [ForeignKey("Reservering")]
        public int ReserveringId { get; set; }

        public Reservering Reservering { get; set; }

        [Required]
        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public Menus Menus { get; set; }
        [Required]
        public int Aantal { get; set; }
    }
}
