using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Domain.Users;

namespace RestaurantePOS.context.SeedData
{
    public class SeedDataConfigurations
    {
        public static Configurations GetConfigurations()
        {
            
      

            return new Configurations()
            {
                
                EstablecimientoNombre = "",
                Representante = "",
                RFC = "",
                Telefono = "",
                Celular = "",
                EnviarSMS = false,
                Direccion = "",
                BkpAlias = "",
                AutoBackup = false,
                CobroDirecto = false,
                ImpresoraUnica = false,
                ImpresoraDomicilio = "",
                ImpresoraCuentas = "",
                ImpresoraCobros = "",
                ImpresoraCortes = "",
                AlertaCorte = "",
                EmailNotificacion = "",
            };
        }
    }
}
