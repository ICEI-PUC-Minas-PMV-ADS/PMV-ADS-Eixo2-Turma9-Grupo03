using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Conquistas")]
    public class Conquista
    {
        [Key]
        public int IdConquista { get; set; }

        [Required]
        [ForeignKey(nameof(Habito))]
        public int IdHabito { get; set; }
        public Habito Habito { get; set; }

        /// <summary>
        /// Meta em dias de consistência (ex.: 7, 30, 100)
        /// </summary>
        [Required]
        public int MetaDias { get; set; }

        /// <summary>
        /// Quando essa conquista foi alcançada
        /// </summary>
        public DateTime DataConquista { get; set; } = DateTime.Now;
    }
}


