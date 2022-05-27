using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces;

public interface IStandartRepository
{
    public IEnumerable<Standart> GetList();
    public Standart Get(int id);
    public void Create(Standart standart);
    public void Update(int id, Standart standart);
    public void Delete(int id);
}