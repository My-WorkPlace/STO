namespace WebApp_JWT.Entities
{
  public class Car
  {
    public int Id { get; set; }
    public string Model { get; set; }
    public BrandCar Brand { get; set; }
    public string VinCode { get; set; }
    public string Number { get; set; }
    public int CarMileage { get; set; }
  }
}
