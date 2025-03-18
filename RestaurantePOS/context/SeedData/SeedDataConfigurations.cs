using RestaurantePOS.Domain.Configuracion;
using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.context.SeedData
{
    public class SeedDataConfigurations
    {
        public static Configurations GetConfigurations()
        {
            
      

            return new Configurations()
            {
                
                EstablecimientoNombre = "test",
                Representante = "test",
                RFC = "test",
                Telefono = "test",
                Celular = "test",
                EnviarSMS = true,
                Direccion = "test",
                BkpAlias = "test",
                AutoBackup = true,
                CobroDirecto = false,
                ImpresoraUnica = false,
                ImpresoraDomicilio = "test",
                ImpresoraCuentas = "test",
                ImpresoraCobros = "test",
                ImpresoraCortes = "test",
                AlertaCorte = "test",
                EmailNotificacion = "test",
            };
        }
    }
}
