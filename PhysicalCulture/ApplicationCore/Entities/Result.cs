namespace ApplicationCore.Entities;

public class Result
{
    public Result(int studentId, int standartId, bool mark)
    {
        StudentId = studentId;
        StandartId = standartId;
        Mark = mark;
    }

    public int ResultId { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int StandartId { get; set; }
    public Standart Standart { get; set; }

    public bool Mark { get; set; }
}
