using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeLib.Queries
{
    public record ProcessRegExQuery(string RegEx, string Input): IRequest<string>();
}
