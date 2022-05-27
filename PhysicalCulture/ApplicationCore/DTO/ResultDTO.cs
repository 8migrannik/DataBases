using ApplicationCore.Entities;

public class ResultDTO
{
    public ResultDTO(int resultId, Student student, Standart standart, bool mark)
    {
        ResultId = resultId;
        Student = student;
        Standart = standart;
        Mark = mark;
    }

    public int ResultId { get; set; }

    public Student Student { get; set; }

    public Standart Standart { get; set; }

    public bool Mark { get; set; }
}
