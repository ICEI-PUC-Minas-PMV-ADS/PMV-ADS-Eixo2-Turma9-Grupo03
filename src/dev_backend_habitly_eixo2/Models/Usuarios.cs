using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Usuarios")]
    public class Usuarios
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
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar senha.")]
        public Perfil Perfil { get; set; }
    }
    public enum Perfil
    {
        Admin,
        User
    }
}
