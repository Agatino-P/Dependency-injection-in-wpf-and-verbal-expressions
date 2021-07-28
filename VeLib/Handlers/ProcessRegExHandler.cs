using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VeLib.Queries;

namespace VeLib.Handlers
{
    public class ProcessRegExHandler : IRequestHandler<ProcessRegExQuery, string>
    {
        public Task<string> Handle(ProcessRegExQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"TBD - {request.RegEx} {request.Input}");
        }
    }
}
