using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dev_backend_habitly_eixo2.Models
{
    [Table("Etiquetas")]
    public class Etiqueta
    {
        [Key]
        public string IdEtiqueta { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        // Relação many-to-many com Habito
        public virtual ICollection<Habito> Habitos { get; set; }
    }
}
