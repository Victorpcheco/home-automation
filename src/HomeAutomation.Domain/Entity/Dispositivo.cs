namespace HomeAutomation.Domain.Entidades
{
    public class Dispositivo
    {

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Localizacao { get; set; } = null!;
    }
}
