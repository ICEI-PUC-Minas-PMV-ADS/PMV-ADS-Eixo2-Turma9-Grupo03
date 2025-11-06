using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Habitos")]
    public class Habito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 🔹 ID gerado pelo banco
        public int IdHabito { get; set; }

        [ForeignKey(nameof(Habito))]
        public int IdUsuario { get; set; } // 🔹 ID do usuário logado

        [Required]
        [StringLength(100)]
        public string TituloHabito { get; set; } = string.Empty;

        [StringLength(300)]
        public string? DescricaoHabito { get; set; }

        [StringLength(20)]
        public string DiasDaSemana { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)] // Mapeia para DATE no SQL Server
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)] // Mapeia para DATE no SQL Server
        public DateTime DataFim { get; set; }

        [Required]
        [StringLength(20)]
        public string StatusHabito { get; set; } = "Ativo";

        public virtual ICollection<Checkin> Checkins { get; set; } = new List<Checkin>();

    }
}
