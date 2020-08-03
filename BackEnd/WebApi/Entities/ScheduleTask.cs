namespace WebApp_JWT.Entities
{
  public class ScheduleTask
  {
    public int Id { get; set; }
    public string DateTime { get; set; }
    public string Title { get; set; }
    public User ScheduleOwner { get; set; }
    
  }
}
