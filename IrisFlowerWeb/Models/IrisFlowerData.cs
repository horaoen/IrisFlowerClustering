using System.ComponentModel.DataAnnotations;
using Microsoft.ML.Data;

namespace IrisFlowerWeb.Models;

public class IrisFlowerData
{
    [LoadColumn(0)]
    [Display(Name = "花萼长度")]
    public float SepalLength { get; set; }

    [LoadColumn(1)]
    [Display(Name = "花萼宽度")]
    public float SepalWidth { get; set; }

    [LoadColumn(2)]
    [Display(Name = "花瓣长度")]
    public float PetalLength { get; set; }

    [LoadColumn(3)]
    [Display(Name = "花瓣宽度")]
    public float PetalWidth { get; set; }
}