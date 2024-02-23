namespace SistemaFinch.Commons
{
    public class Resultado(bool success, string? messageDb)
    {
        public bool Success { get; set; } = success;
        public string? Message { get; set; } = messageDb;

    }
}
