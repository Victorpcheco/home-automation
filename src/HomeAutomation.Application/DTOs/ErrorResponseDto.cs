namespace HomeAutomation.Application.DTOs
{
    public class ErrorResponseDto
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string? Detalhes { get; set; } = null;
    }
}
