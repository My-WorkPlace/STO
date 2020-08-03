using System.Collections.Generic;

namespace WebApp_JWT.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public IEnumerable<Car> Cars { get; set; }
    public string Phone { get; set; } 
  }
}
