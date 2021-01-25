using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class MenuGerecht
    {
        [ForeignKey("Menus")]
        public int MenuId { get; set; }
        public Menus Menus { get; set; }

        [ForeignKey("Gerecht")]
        public int GerechtId { get; set; }
        public Gerecht Gerecht { get; set; }
    }
}