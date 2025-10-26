namespace dev_backend_habitly_eixo2.Models.DTOs
{
    // Modelo para exibir um único dia no calendário
    public class CalendarioEventoDTO
    {
        public int IdHabito { get; set; }
        public string TituloHabito { get; set; } = string.Empty;

        // 🎯 ESTAS PROPRIEDADES DEVEM EXISTIR EXATAMENTE ASSIM:
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public string Cor { get; set; } = "#1e90ff";

        // Propriedade AllDay (opcional, se você a incluiu)
        public bool AllDay => DataHoraFim.Subtract(DataHoraInicio).TotalHours >= 24;
    }
}