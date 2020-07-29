using System;
using Microsoft.AspNetCore.Mvc;
using WebApp_JWT.Entities;
using WebApp_JWT.Services;

namespace WebApp_JWT.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TaskController : ControllerBase
  {
    private ITaskService _taskService;

    public TaskController(
      ITaskService taskService)
    {
      _taskService = taskService;
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] SheduleTask model)
    {

      try
      {
        // create user
        _taskService.Create(model);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    public IActionResult Get()
    {
      var users = _taskService.GetAll();
      return Ok(users);
    }

    [HttpPost("GetByDate")]
    public IActionResult GetByDate([FromBody]SheduleTask model)
    {
      var tasks = _taskService.GetByDate(model.DateTime);
      return Ok(tasks);
    }

    [HttpPut]
    public IActionResult Update([FromBody]SheduleTask model)
    {
      try
      {
        // update user 
        _taskService.Update(model);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _taskService.Delete(id);
      return Ok();
    }

    [HttpPost("{DeleteObj}")]
    public IActionResult DeleteObj([FromBody]SheduleTask model)
    {
      _taskService.DeleteObj(model);
      return Ok();
    }
  }
}