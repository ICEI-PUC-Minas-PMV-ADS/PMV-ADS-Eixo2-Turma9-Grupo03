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

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Tema { get; set; } = "Claro"; // Exemplo: Claro / Escuro

        [Required]
        public bool NotificacoesAtivas { get; set; } = true; // Exemplo: recebe notificações?

        public string Idioma { get; set; } = "pt-BR"; // Exemplo: idioma preferido

        public Usuarios? Usuario { get; set; } // Relacionamento
    }
}

