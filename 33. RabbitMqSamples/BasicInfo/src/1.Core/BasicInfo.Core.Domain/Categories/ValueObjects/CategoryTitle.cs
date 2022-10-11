using BasicInfo.Core.Domain.Common.ValueObjects;

namespace BasicInfo.Core.Domain.Categories.ValueObjects;

public class CategoryTitle : TinyString
{
    public CategoryTitle(string value):base(value)
    {

    }
    //#region Properties
    //public string Value { get; private set; }
    //#endregion


    //#region Equality Check
    //protected override IEnumerable<object> GetEqualityComponents()
    //{
    //    yield return Value;
    //}
    //#endregion
    //#region Constructors and Factories
    //public static CategoryTitle FromString(string value) => new CategoryTitle(value);
    //public CategoryTitle(string value)
    //{
    //    if (string.IsNullOrWhiteSpace(value))
    //    {
    //        throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(CategoryTitle));
    //    }
    //    if (value.Length < 2 || value.Length > 50)
    //    {
    //        throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(CategoryTitle), "2", "50");
    //    }
    //    Value = value;
    //}
    //private CategoryTitle()
    //{

    //}
    //#endregion

    //#region Operator Overloading
    //public static explicit operator string(CategoryTitle title) => title.Value;
    //public static implicit operator CategoryTitle(string value) => new(value);
    //#endregion

    //#region Methods
    //public override string ToString() => Value;

    //#endregion
}