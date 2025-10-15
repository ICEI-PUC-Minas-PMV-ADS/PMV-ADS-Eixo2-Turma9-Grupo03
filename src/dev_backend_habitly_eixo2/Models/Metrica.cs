using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Metricas")]
    public class Metrica
    {
        [Key]
        public string IdMetrica { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        public int StreakAtual { get; set; }
        public int StreakMaximo { get; set; }
    }
}
