using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StudentRepository : IStudentRepository
{
    private readonly DBContext _db;

    public StudentRepository(DBContext context)
    {
        _db = context;
    }

    public IEnumerable<Student> GetList()
    {
        return _db.Students;
    }

    public Student Get(int id)
    {
        Student? item = _db.Students.Find(id);
        if (item == null)
        {
            throw new Exception("Студент не найден");
        }
        return item;
    }

    public void Create(Student Student)
    {
        _db.Students.Add(Student);
        _db.SaveChanges();
    }

    public void Update(int id, Student Student)
    {
        Student? item = _db.Students.Find(id);
        if (item == null)
        {
            throw new Exception("Студент не найден");
        }
        else
        {
            item.Name = Student.Name;
            item.Age = Student.Age;
            item.Gender = Student.Gender;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        Student? item = _db.Students.Find(id);
        if (item == null)
        {
            throw new Exception("Студент не найден");
        }
        else
        {
            _db.Students.Remove(item);
            _db.SaveChanges();
        }
    }

    public IEnumerable<Student> Search(string request)
    {
        return _db.Students.Where(s => EF.Functions.Like(s.Name, "%" + request + "%"));
    }
}
