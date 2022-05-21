using System.ComponentModel.DataAnnotations;

namespace IrisFlowerWeb.Models;

public enum IrisType
{
    [Display(Name = "狗尾草鸢尾")]
    Setosa,
    [Display(Name = "杂色鸢尾")]
    Versicolor,
    [Display(Name = "弗吉尼亚鸢尾")]
    Virginnica,
}