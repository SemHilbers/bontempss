using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("GerechtIngredienten")]
    public class GerechtIngredient
    {
        [ForeignKey("Gerecht")]
        public int GerechtId { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        [Required]
        public short Aantal { get; set; }

        public Ingredient Ingredient { get; set; }
        public Gerecht Gerecht { get; set; }

    }
}