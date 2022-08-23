using BasicInfo.Core.Domain.Keywords.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace BasicInfo.Core.Domain.Common.ValueObjects;
public class TinyString : BaseValueObject<TinyString>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static TinyString FromString(string value) => new TinyString(value);
    public TinyString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(TinyString));
        }
        if (value.Length < 2 || value.Length > 50)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(TinyString), "2", "50");
        }
        Value = value;
    }
    private TinyString()
    {

    }
    #endregion


    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(TinyString title) => title.Value;
    public static implicit operator TinyString(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
