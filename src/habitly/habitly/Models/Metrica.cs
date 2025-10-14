using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace habitly.Models
{
    public class Metrica
    {
        [Key]
        public string IdMetrica { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        public int StreakAtual { get; set; } = 0;

        public int StreakMaximo { get; set; } = 0;
    }
}

