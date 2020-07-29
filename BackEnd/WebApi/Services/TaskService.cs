using System.Collections.Generic;
using System.Linq;
using WebApp_JWT.Entities;
using WebApp_JWT.Helpers;

namespace WebApp_JWT.Services
{
  public interface ITaskService
  {
    SheduleTask GetById(int id);
    IEnumerable<SheduleTask> GetAll();
    SheduleTask Create(SheduleTask task);
    void Update(SheduleTask user);
    void Delete(int id);
    IEnumerable<SheduleTask> GetByDate(string date);
    void DeleteObj(SheduleTask model);
  }

  public class TaskService : ITaskService
  {
    private readonly DataContext _context;

    public TaskService(DataContext context)
    {
      _context = context;
    }

    public IEnumerable<SheduleTask> GetAll()
    {
      return _context.Tasks.ToList();
    }

    public SheduleTask GetById(int id) => _context.Tasks.Find(id);

    public IEnumerable<SheduleTask> GetByDate(string date) => _context.Tasks.Where(task => task.DateTime == date);

    public SheduleTask Create(SheduleTask task)
    {
      _context.Tasks.Add(task);
      _context.SaveChanges();
      return task;
    }

    public void Update(SheduleTask task)
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

    public void DeleteObj(SheduleTask model)
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