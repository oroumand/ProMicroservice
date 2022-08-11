﻿namespace PersonProvider.Models;

public class PersonByIdRequest
{
    public int Id { get; set; }
}

public class PersonResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
