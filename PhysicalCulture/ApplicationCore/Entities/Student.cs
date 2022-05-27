namespace ApplicationCore.Entities;

public class Student
{
    public Student(string name, int age, bool gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public int StudentId { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public bool Gender { get; set; }
}
