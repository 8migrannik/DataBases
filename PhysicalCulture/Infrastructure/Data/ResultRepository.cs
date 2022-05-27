using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.DTO;

namespace Infrastructure.Data;

public class ResultRepository : IResultRepository
{
    private readonly DBContext _db;

    public ResultRepository(DBContext context)
    {
        _db = context;
    }

    public IEnumerable<ResultDTO> GetList()
    {
        return _db.Results
            .Include(s => s.Standart)
            .Include(s => s.Student)
            .Select(r => new ResultDTO(r.ResultId, r.Student, r.Standart, r.Mark));
    }

    public ResultDTO Get(int id)
    {
        Result? item = _db.Results
            .Include(s => s.Standart)
            .Include(s => s.Student)
            .Where(r => r.ResultId == id)
            .FirstOrDefault();

        if (item == null)
        {
            throw new Exception("Результат не найден");
        }

        return new ResultDTO(item.ResultId, item.Student, item.Standart, item.Mark);
    }

    public void Create(CreateResultDTO result)
    {
        Result item = new(result.StudentId, result.StandartId, result.Mark);

        _db.Results.Add(item);
        _db.SaveChanges();
    }

    public void Update(int id, CreateResultDTO result)
    {
        Result? item = _db.Results.Find(id);
        if (item == null)
        {
            throw new Exception("Результат не найден");
        }
        else
        {
            item.StudentId = result.StudentId;
            item.StandartId = result.StandartId;
            item.Mark = result.Mark;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        Result? item = _db.Results.Find(id);
        if (item == null)
        {
            throw new Exception("Результат не найден");
        }
        else
        {
            _db.Results.Remove(item);
            _db.SaveChanges();
        }
    }

    public List<StatisticsDTO> Statistics()
    {
        List<StatisticsDTO>? item = _db.Results
            .Include(s => s.Student)
            .GroupBy(r => new { r.StudentId, r.Student.Name, r.Student.Age, r.Student.Gender })
            .Select(r => new StatisticsDTO(new Student(r.Key.Name, r.Key.Age, r.Key.Gender), r.Count()))
            .ToList();

        if (item == null)
        {
            throw new Exception("Результат не найден");
        }
        return item;
    }
}
