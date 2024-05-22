namespace MoreMobile.Application.Services
{
    public class EmailSettings
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
    }
}
