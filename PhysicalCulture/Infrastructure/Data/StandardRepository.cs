using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

namespace Infrastructure.Data;

public class StandardRepository : IStandartRepository
{
    private readonly DBContext _db;

    public StandardRepository(DBContext context)
    {
        _db = context;
    }

    public IEnumerable<Standart> GetList()
    {
        return _db.Standarts;
    }

    public Standart Get(int id)
    {
        Standart? item = _db.Standarts.Find(id);
        if (item == null)
        {
            throw new Exception("Норматив не найден");
        }
        return item;
    }

    public void Create(Standart standart)
    {
        _db.Standarts.Add(standart);
        _db.SaveChanges();
    }

    public void Update(int id, Standart standart)
    {
        Standart? item = _db.Standarts.Find(id);
        if (item == null)
        {
            throw new Exception("Норматив не найден");
        }
        else
        {
            item.Name = standart.Name;
            _db.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        Standart? item = _db.Standarts.Find(id);
        if (item == null)
        {
            throw new Exception("Норматив не найден");
        }
        else
        {
            _db.Standarts.Remove(item);
            _db.SaveChanges();
        }
    }
}
