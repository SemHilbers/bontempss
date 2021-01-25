using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table( "Ingredienten")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Naam { get; set; }

        [Required]
        [StringLength(20)]
        public string Eenheid { get; set; }

        public virtual ICollection<GerechtIngredient> GerechtIngredienten { get; set; }

        //later toe te voegen
        [NotMapped]
        public string DataTextField => $"{Naam} ({Eenheid})";

    }
}
