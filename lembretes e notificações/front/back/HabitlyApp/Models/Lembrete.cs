namespace HabitlyApp.Models
{
    public class Lembrete
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Dias { get; set; } = string.Empty;
        public int IntervaloHoras { get; set; }
    }
}