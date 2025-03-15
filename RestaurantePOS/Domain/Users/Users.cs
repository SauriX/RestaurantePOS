using System.Text.Json.Serialization;

namespace RestaurantePOS.Domain.Users
{
    public class Users
    {
        [JsonPropertyName("id")]
        public int IdUsuario { get; set; }
        [JsonPropertyName("name")]
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }


    }
}
