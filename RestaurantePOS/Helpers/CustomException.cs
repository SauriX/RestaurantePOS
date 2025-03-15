using System.Net;

namespace RestaurantePOS.Helpers
{
    public class CustomException : Exception
    {
        public HttpStatusCode Code { get; }
        public string Errors { get; }

        // Constructor con HttpStatusCode y mensaje
        public CustomException(HttpStatusCode code, string message = null)
            : base(message)  // Llama al constructor base para almacenar el mensaje
        {
            Code = code;
            Errors = message;
        }

        // Constructor solo con mensaje, predeterminando el código HTTP (por ejemplo, BadRequest)
        public CustomException(string message)
            : this(HttpStatusCode.BadRequest, message) // Puedes definir un código predeterminado como BadRequest
        {
        }
    }
}
