using BasicInfo.Core.Domain.Categories.Entities;
using BasicInfo.Core.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Exceptions;

namespace BasicInfo.Core.Domain.Test.Common.ValueObjects;
public class TinyStringTest
{
    [Fact]
    public void create_tiny_string_whene_all_data_is_Valid()
    {
        //Arrange
        string value = "ورزش";

        //Act
        TinyString tinyString = new TinyString(value);

        //Assert
        Assert.NotNull(tinyString);
        Assert.Equal(value, tinyString.Value);
    }
    [Theory]
    [InlineData("")]
    [InlineData("و")]
    [InlineData("123456789012345678901234567890123456789012345678901")]
    public void prevent_create_tiny_string_whene_value_is_invalid(string inputValue)
    {
        //Arrange
        string value = inputValue;

        //Act
        TinyString tinyString;
        //Assert
        Assert.Throws<InvalidValueObjectStateException>(() => tinyString = new TinyString(value));
    }

    //[Fact]
    //public void prevent_create_category_whene_title_is_less_than_tow()
    //{
    //    //Arrange
    //    string value = "و";


    //    //Act
    //    TinyString tinyString;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => tinyString = new TinyString(value));
    //}
    //[Fact]
    //public void prevent_create_category_whene_title_is_more_than_50()
    //{
    //    //Arrange
    //    string value = "ورزش".PadLeft(51, '_');
    //    //Act
    //    TinyString tinyString;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => tinyString = new TinyString(value));
    //}
}
