using BasicInfo.Core.Domain.Categories.Entities;
using BasicInfo.Core.Domain.Categories.Events;
using Zamin.Core.Domain.Exceptions;

namespace BasicInfo.Core.Domain.Test;

public class CategoryTest
{
    [Fact]
    public void create_category_whene_all_data_is_Valid()
    {
        //Arrange
        string name = "Sport";
        string title = "ورزش";

        //Act
        Category category = new(name,title);
        var CategorycreatedEvent = category.GetEvents().Where(c => c.GetType() == typeof(CategoryCreated)).FirstOrDefault() as CategoryCreated;

        //Assert
        Assert.NotNull(category);
        Assert.NotNull(CategorycreatedEvent);
        Assert.Equal(title,category.Title);
        Assert.Equal(name,category.Name);
        Assert.Equal(title, CategorycreatedEvent.Title);
        Assert.Equal(name, CategorycreatedEvent.Name);
    }
    //[Fact]
    //public void prevent_create_category_whene_title_is_null()
    //{
    //    //Arrange
    //    string name = "Sport";
    //    string title = "";


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}

    //[Fact]
    //public void prevent_create_category_whene_name_is_null()
    //{
    //    //Arrange
    //    string name = "";
    //    string title = "ورزش";


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}

    //[Fact]
    //public void prevent_create_category_whene_title_is_less_than_tow()
    //{
    //    //Arrange
    //    string name = "Sport";
    //    string title = "و";


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}

    //[Fact]
    //public void prevent_create_category_whene_name_is_less_than_tow()
    //{
    //    //Arrange
    //    string name = "s";
    //    string title = "ورزش";


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}

    //[Fact]
    //public void prevent_create_category_whene_title_is_more_than_50()
    //{
    //    //Arrange
    //    string name = "Sport";
    //    string title = "ورزش".PadLeft(51,'_');


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}

    //[Fact]
    //public void prevent_create_category_whene_name_is_more_than_50()
    //{
    //    //Arrange
    //    string name = "Sport".PadLeft(51, '_');
    //    string title = "ورزش";


    //    //Act
    //    //Category category = new Category(name, title);
    //    Category category;
    //    //Assert
    //    Assert.Throws<InvalidValueObjectStateException>(() => category = new Category(name, title));
    //}
}