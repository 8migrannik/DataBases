using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface IStudentRepository
{
    public IEnumerable<Student> GetList();
    public Student Get(int id);
    public void Create(Student student);
    public void Update(int id, Student student);
    public void Delete(int id);
    public IEnumerable<Student> Search(string request);
}
