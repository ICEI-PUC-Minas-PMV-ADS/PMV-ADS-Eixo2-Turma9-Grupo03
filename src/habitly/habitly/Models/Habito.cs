using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace habitly.Models
{
    [Table("Habito")]
    public class Habito
    {
        [Key]
        public string IdHabito { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeHabito { get; set; }

        [StringLength(300)]
        public string DescricaoHabito { get; set; }

        [Required]
        public string StatusHabito { get; set; }
    }
}


