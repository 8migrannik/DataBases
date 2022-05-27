using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controllers;

[Route("api/standart")]
[ApiController]
public class StandartController : ControllerBase
{
    private readonly IStandartRepository _repository;

    public StandartController(IStandartRepository repository)
    {
        _repository = repository;
    }

    // Получить список нормативов
    // GET: api/standart
    [HttpGet]
    public IActionResult GetListStandarts()
    {
        return Ok(_repository.GetList());
    }

    // Получить норматив
    // GET api/standart/{id}
    [HttpGet("{id}")]
    public IActionResult GetStandart(int id)
    {
        Standart item;
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

    // Создать норматив
    // POST api/standart
    [HttpPost]
    public IActionResult CreateStandart([FromBody] Standart param)
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

    // Редактировать норматив
    // PUT api/standart/{id}
    [HttpPut("{id}")]
    public IActionResult EditStandart(int id, [FromBody] Standart param)
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

    // Удалить норматив
    // DELETE api/standart/{id}
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
}
