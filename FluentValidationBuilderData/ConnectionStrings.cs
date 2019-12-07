using System.Diagnostics.CodeAnalysis;

namespace FluentValidationBuilderData
{
    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ConnectionStrings
    {
        public string PostgreSQLMediaServer { get; set; }

        public int CommandTimeout { get; set; }
    }
}