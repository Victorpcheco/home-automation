namespace HomeAutomation.Application.DTOs
{
    public class DispositivoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Localizacao { get; set; } = null!;
    }
}
