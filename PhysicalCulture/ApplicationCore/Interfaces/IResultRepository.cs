using ApplicationCore.DTO;

namespace ApplicationCore.Interfaces;

public interface IResultRepository
{
    public IEnumerable<ResultDTO> GetList();
    public ResultDTO Get(int id);
    public void Create(CreateResultDTO result);
    public void Update(int id, CreateResultDTO result);
    public void Delete(int id);
    public List<StatisticsDTO> Statistics();
}