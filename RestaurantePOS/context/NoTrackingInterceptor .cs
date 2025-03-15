using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace RestaurantePOS.context
{
    public class NoTrackingInterceptor : IDbCommandInterceptor
    {
        // Este método intercepta la ejecución de los comandos SQL de lectura (SELECT)
        public InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            // Aquí puedes modificar el texto SQL para asegurarte de que sea No-Tracking
            // Aunque EF Core no tiene un "NOLOCK" como en SQL Server, si necesitas que se aplique sin seguimiento,
            // puedes asegurarte de usar AsNoTracking en las consultas a nivel de código.
            command.CommandText = command.CommandText;  // En este ejemplo no hacemos ningún cambio explícito
            return result;
        }

        public Task<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, CancellationToken cancellationToken, InterceptionResult<DbDataReader> result)
        {
            return Task.FromResult(ReaderExecuting(command, eventData, result));
        }

        // Otros métodos también se pueden interceptar, pero no son necesarios para este caso
        public int ScalarExecuting(DbCommand command, CommandEventData eventData, int result) => result;
        public Task<int> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, CancellationToken cancellationToken, int result) => Task.FromResult(result);

        public void CommandFailed(DbCommand command, CommandErrorEventData eventData) { }
        public Task CommandFailedAsync(DbCommand command, CommandErrorEventData eventData, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
