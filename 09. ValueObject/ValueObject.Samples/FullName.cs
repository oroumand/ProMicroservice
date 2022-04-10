using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObject.Samples;

public class FullName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Teacher
{
    public FullName FullName { get; set; }
}
public class TeacherRepo
{
    public void Insert(Teacher teacher)
    {
        string insertCommand = $"Insert into Teacher(FirstName,LastName) values ({teacher.FullName.FirstName},{teacher.FullName.LastName})";
    }
}