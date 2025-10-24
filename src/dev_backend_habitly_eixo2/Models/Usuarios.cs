using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar nome.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar e-mail.")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]      
        public Perfil Perfil { get; set; }   // 0 = User, 1 = Admin
    }
    public enum Perfil: byte
    {
        Admin =1,
        User = 0
    }
}
