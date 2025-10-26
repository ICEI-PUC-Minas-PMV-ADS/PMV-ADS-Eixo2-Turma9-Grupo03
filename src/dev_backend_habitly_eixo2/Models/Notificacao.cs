using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        [Key]
        public string IdNotificacao { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [StringLength(100)]
        public string Mensagem { get; set; }

        public DateTime DataHora { get; set; }
    }
}
