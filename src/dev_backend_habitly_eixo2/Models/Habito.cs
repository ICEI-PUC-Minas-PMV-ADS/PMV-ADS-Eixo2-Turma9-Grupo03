using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
<<<<<<< HEAD
        public string StatusHabito { get; set; }
        
        // Indica se o hábito está arquivado. Quando arquivado, os check-ins devem ser preservados.
        public bool IsArquivado { get; set; }

        // Etiquetas associadas (many-to-many)
        public virtual ICollection<Etiqueta> Etiquetas { get; set; }
=======
        [DataType(DataType.DateTime)] // Mapeia para DATE no SQL Server
        public DateTime DataFim { get; set; }

        [Required]
        [StringLength(20)]
        public string StatusHabito { get; set; } = "Ativo";
>>>>>>> 759c425905ab04eff3bfd9ca1c2cc625b768de84
    }
}
