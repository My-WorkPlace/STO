using System.Collections.Generic;
using System.Linq;
using WebApp_JWT.Entities;
using WebApp_JWT.Helpers;

namespace WebApp_JWT.Services
{
  public interface ITaskService
  {
    ScheduleTask GetById(int id);
    IEnumerable<ScheduleTask> GetAll();
    ScheduleTask Create(ScheduleTask task);
    void Update(ScheduleTask user);
    void Delete(int id);
    IEnumerable<ScheduleTask> GetByDate(string date);
    void DeleteObj(ScheduleTask model);
  }

  public class TaskService : ITaskService
  {
    private readonly DataContext _context;
    private readonly IUserService _userService;

    public TaskService(DataContext context,IUserService userService)
    {
      _context = context;
      _userService = userService;
    }

    public IEnumerable<ScheduleTask> GetAll()
    {
      return _context.Tasks.ToList();
    }

    public ScheduleTask GetById(int id) => _context.Tasks.Find(id);

    public IEnumerable<ScheduleTask> GetByDate(string date) => _context.Tasks.Where(task => task.DateTime == date);

    public ScheduleTask Create(ScheduleTask task)
    {
      task.ScheduleOwner = _userService.GetById(task.ScheduleOwner.Id);
      _context.Tasks.Add(task);
      _context.SaveChanges();
      return task;
    }

    public void Update(ScheduleTask task)
    {
      _context.Tasks.Update(task);
      _context.SaveChanges();
    }

    public void Delete(int id)
    {
      var task = _context.Tasks.Find(id);
      if (task != null)
      {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
      }
    }

    public void DeleteObj(ScheduleTask model)
    {
      var res = _context.Tasks.FirstOrDefault(a => a.Title == model.Title);
      if (res != null)
      {
        _context.Tasks.Remove(res);
        _context.SaveChanges();
      }
    }
  }
}