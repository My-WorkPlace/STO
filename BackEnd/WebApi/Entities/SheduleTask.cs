using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_JWT.Entities
{
  public class SheduleTask
  {
    public int Id { get; set; }
    public string DateTime { get; set; }
    public string Title { get; set; }
    public User SheduleOwner { get; set; }
  }
}
