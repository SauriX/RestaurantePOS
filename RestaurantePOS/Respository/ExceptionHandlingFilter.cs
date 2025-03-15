using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RestaurantePOS.Helpers;

namespace RestaurantePOS.Respository
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomException customEx)
            {
                context.Result = new ObjectResult(customEx.Errors)
                {
                    StatusCode = (int)customEx.Code
                };
                context.ExceptionHandled = true;
            }
            else
            {
                 var errorMessage = "Error interno del servidor";

                // Si la excepción tiene un mensaje interno, lo añadimos al mensaje de error
                if (context.Exception.InnerException != null)
                {
                    errorMessage += $" - Detalle: {context.Exception.InnerException.Message}";
                }

                context.Result = new ObjectResult(errorMessage)
                {
                    StatusCode = 500  // 500 Internal Server Error
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
