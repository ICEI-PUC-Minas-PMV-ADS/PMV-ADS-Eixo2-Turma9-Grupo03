using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{

    [Table("Checkins")]
    public class Checkin
    {
        [Key]
        public int IdCheckin { get; set; }

        [Required]
        [ForeignKey(nameof(Habito))]
        public int IdHabito { get; set; }

        public virtual Habito Habito { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCheckin { get; set; }


    }
}
