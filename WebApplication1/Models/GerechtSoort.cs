using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class GerechtSoort
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Soort { get; set; }

        public virtual ICollection<Gerecht> Gerechten { get; set; }
    }
}