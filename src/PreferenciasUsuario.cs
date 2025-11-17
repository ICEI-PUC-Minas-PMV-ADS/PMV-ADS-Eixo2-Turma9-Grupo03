csharp dev_backend_habitly_eixo2\Models\PreferenciasUsuario.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("PreferenciasUsuario")]
    public class PreferenciasUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPreferencia { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Tema { get; set; }

        [Required]
        public bool NotificacoesAtivas { get; set; }

        public string? Idioma { get; set; }

        public Usuarios? Usuario { get; set; }
    }
}