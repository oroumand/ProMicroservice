using Earth.Core.Contracts.ApplicationServices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Samples.Core.Contracts.People.Commands;

public class CreatePerson:ICommand<long>
{
    public string FirstName { get; set; }=string.Empty;
    public string LastName { get; set; } = string.Empty;
}