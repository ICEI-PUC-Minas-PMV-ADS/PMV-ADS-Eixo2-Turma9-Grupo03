using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Habitos")]
    public class Habito
    {
        [Key]
        public string IdHabito { get; set; }

        [Required]
        public string IdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string TituloHabito { get; set; }

        [StringLength(300)]
        public string DescricaoHabito { get; set; }

        [Required]
        public int PeriodicidadeHabito { get; set; }

        [Required]
        public string StatusHabito { get; set; }
        
        // Indica se o hábito está arquivado. Quando arquivado, os check-ins devem ser preservados.
        public bool IsArquivado { get; set; }

        // Etiquetas associadas (many-to-many)
        public virtual ICollection<Etiqueta> Etiquetas { get; set; }
    }
}
