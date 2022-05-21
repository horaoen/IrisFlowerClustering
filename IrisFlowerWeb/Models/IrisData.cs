using System.ComponentModel.DataAnnotations;

namespace IrisFlowerWeb.Models;

public class IrisData
{
    [Key]
    public Guid Id { get; set; }
    
    public float SepalLength { get; set; }
    
    public float SepalWidth { get; set; }
    
    public float PetalLength { get; set; }
    
    public float PetalWidth { get; set; }
    
    public IrisType? FlowerType { get; set; }
}
