using CSharpVerbalExpressions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeLib.Queries
{
    public record ProcessRegExQuery(VerbalExpressions VerbExpr, string Input): IRequest<string>();
}
