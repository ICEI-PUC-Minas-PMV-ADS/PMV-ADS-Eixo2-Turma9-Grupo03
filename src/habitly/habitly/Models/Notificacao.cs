using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace habitly.Models
{
    [Table("Notificacao")]
    public class Notificacao
    {
        [Key]
        public string IdNotificacao { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }

        [StringLength(100)]
        public string Mensagem { get; set; }

        public DateTime DataHora { get; set; }
    }
}

