using ApplicationCore.Entities;

namespace ApplicationCore.DTO;

public class StatisticsDTO
{
    public StatisticsDTO(Student student, int count)
    {
        Student = student;
        Count = count;
    }

    public Student Student { get; set; }

    public int Count { get; set; }
}
