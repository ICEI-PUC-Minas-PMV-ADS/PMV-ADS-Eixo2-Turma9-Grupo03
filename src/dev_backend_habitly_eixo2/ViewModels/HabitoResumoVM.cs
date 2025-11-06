namespace dev_backend_habitly_eixo2.ViewModels
{
    public class HabitoResumoVM
    {
        public int IdHabito { get; set; }
        public string Titulo { get; set; } = ""; // nome do hábito
        public int Total { get; set; }           // dias com check-in no mês
        public double? Percentual { get; set; }  // opcional, se quiser usar depois
    }
}
