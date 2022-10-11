using BasicInfo.Core.Domain.Common.ValueObjects;

namespace BasicInfo.Core.Domain.Categories.ValueObjects;
public class CategoryName : TinyString
{
    public CategoryName(string value):base(value)
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
    //public static CategoryName FromString(string value) => new CategoryName(value);
    //public CategoryName(string value)
    //{
    //    if (string.IsNullOrWhiteSpace(value))
    //    {
    //        throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(CategoryName));
    //    }
    //    if (value.Length < 2 || value.Length > 50)
    //    {
    //        throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(CategoryName), "2", "50");
    //    }
    //    Value = value;
    //}
    //private CategoryName()
    //{

    //}
    //#endregion

    //#region Operator Overloading
    //public static explicit operator string(CategoryName title) => title.Value;
    //public static implicit operator CategoryName(string value) => new(value);
    //#endregion

    //#region Methods
    //public override string ToString() => Value;

    //#endregion
}
