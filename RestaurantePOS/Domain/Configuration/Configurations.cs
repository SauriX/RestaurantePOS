using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantePOS.Domain.Configuracion
{
    public class Configurations
    {
        public int Id { get; set; }
        public string? EstablecimientoNombre { get; set; }
        public string? Representante { get; set; }
        public string? RFC { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public bool EnviarSMS { get; set; }
        public string? Direccion { get; set; }
        public string? BkpAlias { get; set; }
        public bool AutoBackup { get; set; }
        public bool CobroDirecto { get; set; } = true;
        public bool ImpresoraUnica { get; set; } = true;
        public string? ImpresoraDomicilio { get; set; }
        public string? ImpresoraCuentas { get; set; } 
        public string? ImpresoraCobros { get; set; }
        public string? ImpresoraCortes { get; set; }
        public string? AlertaCorte { get; set; }
        public string? EmailNotificacion { get; set; }
    }
}
