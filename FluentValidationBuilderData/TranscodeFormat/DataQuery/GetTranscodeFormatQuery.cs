using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidationBuilderData.TranscodeFormat.DataQuery
{
    public class GetTranscodeFormatQuery : DataQueryBase
    {
        public GetTranscodeFormatQuery(IEnumerable<string> presets)
        {
            Parameters.Add("@presets", presets);
            CmdText = @"
select
from
where name in ( @presets);
            ";

        }
    }
}

/*
 * arameters.Add("nodeId", nodeId);
            CmdText = @"
Select 
BillableAccountAppId as Id
from Node 
where Id=@nodeId 
";
*/