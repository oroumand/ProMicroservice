using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Core.Contracts.ApplicationServices.Common;
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}
