using System.ComponentModel.DataAnnotations;

namespace Habitly.Models
{
    public class Habit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do hábito é obrigatório.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [Display(Name = "Criado em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Frequência")]
        public string Frequency { get; set; } = "Diário"; // Diário, Semanal, Mensal

        [Range(0, 100)]
        [Display(Name = "Progresso (%)")]
        public int Progress { get; set; } = 0;

        [Display(Name = "Concluído?")]
        public bool IsCompleted { get; set; } = false;
    }
}
