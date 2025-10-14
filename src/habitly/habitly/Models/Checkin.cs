using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace habitly.Models
{
    [Table("Checkin")]
    public class Checkin
    {
        [Key]
        public string IdCheckin { get; set; }

        [Required]
        [ForeignKey("Habito")]
        public string IdHabito { get; set; }

        public virtual Habito Habito { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCheckin { get; set; } = DateTime.Today;
    }
}

