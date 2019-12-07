using System;
using System.Collections.Generic;
using Dapper;

namespace FluentValidationBuilderData
{
    public abstract class DataQueryBase : IDataQuery
    {
        private const string conditionOperatorIn = "in";
        private readonly Dictionary<string, object> parameters = new Dictionary<string, object>();

        private readonly SqlBuilder builder = new SqlBuilder();

        public IDictionary<string, object> Parameters => parameters;

        public string CmdText { get; set; }

    }
}
