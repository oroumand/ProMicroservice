using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth.Samples.Core.Domain;

public class Messages
{
    public static string InvalidNullValue = "The value of {0} should not be null";
    public static string InvalidNumberValueRange = "The value of {0} should not be less than {1}";
    public static string InvalidStringLenght = "The Lenght of {0} should be {1} - {2}";
    public static string FirstName = nameof(FirstName);
}