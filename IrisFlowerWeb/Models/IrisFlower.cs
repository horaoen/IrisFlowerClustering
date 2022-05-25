using System.ComponentModel.DataAnnotations;

namespace IrisFlowerWeb.Models;

public class IrisFlower
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "花萼长度")]
    public float SepalLength { get; set; }
    [Display(Name = "花萼宽度")]
    public float SepalWidth { get; set; }
    [Display(Name = "花瓣长度")]
    public float PetalLength { get; set; }
    [Display(Name = "花瓣宽度")]
    public float PetalWidth { get; set; }

    [Display(Name = "种类")]
    public IrisType? FlowerType { get; set; }
}
