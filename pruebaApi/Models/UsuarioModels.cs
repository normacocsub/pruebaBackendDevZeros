namespace PruebaApi.Models
{
    public class UsuarioInputModels
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }

    public class UsuarioViewModels : UsuarioInputModels
    {
        public string Token { get; set; }
    }
}
