using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Gerecht
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("GerechtSoort")]
        public int GerechtSoortId { get; set; }

        public GerechtSoort Soort { get; set; }

        [Required]
        [StringLength(80)]
        public string Naam { get; set; }
        
        public virtual ICollection<MenuGerecht> GerechtMenus { get; set; }
        public virtual ICollection<GerechtIngredient> GerechtIngredienten { get; set; }


    }
}