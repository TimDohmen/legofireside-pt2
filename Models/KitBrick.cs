namespace legodemo.Models
{
  public class KitBrick
  {
    public int Id { get; set; }
    public int KitId { get; set; }
    public int BrickId { get; set; }
    public int Quantity { get; set; }


  }


  public class KitPart : KitBrick
  {
    public string KitName { get; set; }
    public string BrickName { get; set; }

  }

}