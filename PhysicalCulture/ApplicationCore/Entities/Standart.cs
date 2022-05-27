namespace ApplicationCore.Entities;

public class Standart
{
    public Standart(string name)
    {
        Name = name;
    }

    public int StandartId { get; set; }

    public string Name { get; set; }
}
