using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controllers;

[Route("api/result")]
[ApiController]
public class ResultController : ControllerBase
{
    private readonly IResultRepository _repository;

    public ResultController(IResultRepository repository)
    {
        _repository = repository;
    }

    // Получить список результатов
    // GET: api/result
    [HttpGet]
    public IActionResult GetListResults()
    {
        return Ok(_repository.GetList());
    }

    // Получить результат
    // GET api/result/{id}
    [HttpGet("{id}")]
    public IActionResult GetResult(int id)
    {
        ResultDTO item;
        try
        {
            item = _repository.Get(id);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        return Ok(item);
    }

    // Создать результат
    // POST api/result
    [HttpPost]
    public IActionResult CreateResult([FromBody] CreateResultDTO param)
    {
        try
        {
            _repository.Create(param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Редактировать результат
    // PUT api/result/{id}
    [HttpPut("{id}")]
    public IActionResult EditResult(int id, [FromBody] CreateResultDTO param)
    {
        try
        {
            _repository.Update(id, param);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Удалить результат
    // DELETE api/result/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        try
        {
            _repository.Delete(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Статистика
    // GET api/result/statistics
    [HttpGet("statistics")]
    public IActionResult Statistics()
    {
        try
        {
            return Ok(_repository.Statistics());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
