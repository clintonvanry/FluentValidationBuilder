using System.Collections.Generic;

namespace FluentValidationBuilderData
{
    public interface IDataQuery
    {
        IDictionary<string, object> Parameters { get; }

        string CmdText { get; set; }
    }
}