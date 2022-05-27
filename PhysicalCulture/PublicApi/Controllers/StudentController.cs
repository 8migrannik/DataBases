using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublicApi.Controllers;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }

    // Получить список нормативов
    // GET: api/student
    [HttpGet]
    public IActionResult GetListStudents()
    {
        return Ok(_repository.GetList());
    }

    // Получить норматив
    // GET api/student/{id}
    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        Student item;
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
    // POST api/student
    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student param)
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
    // PUT api/student/{id}
    [HttpPut("{id}")]
    public IActionResult EditStudent(int id, [FromBody] Student param)
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
    // DELETE api/student/{id}
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

    // Поиск по имени
    // GET api/student/{request}
    [HttpGet("search/{request}")]
    public IActionResult Search(string request)
    {
        return Ok(_repository.Search(request));
    }
}
