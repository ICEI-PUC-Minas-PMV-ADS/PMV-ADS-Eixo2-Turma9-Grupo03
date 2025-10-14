using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace habitly.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar nome.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar e-mail.")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar senha.")]
        public string Senha { get; set; }
    }
}
