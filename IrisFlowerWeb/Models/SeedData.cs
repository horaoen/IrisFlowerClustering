using Microsoft.EntityFrameworkCore;

namespace IrisFlowerWeb.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new IrisFlowerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<IrisFlowerContext>>());
        
        if (context == null || context.IrisFlower == null)
        {
            throw new ArgumentNullException("Null IrisFlowerContext");
        }

        if (context.IrisFlower.Any()) return;
        
        context.IrisFlower.AddRange(
            new IrisFlower
            {
                SepalLength = 5.1f,
                SepalWidth = 3.5f,
                PetalLength = 1.4f,
                PetalWidth = 1.0f,
                FlowerType = IrisType.Setosa
            },
            new IrisFlower
            {
                SepalLength = 4.9f,
                SepalWidth = 3.0f,
                PetalLength = 1.4f,
                PetalWidth = 0.2f,
                FlowerType = IrisType.Setosa
            },
            new IrisFlower
            {
                SepalLength = 4.7f,
                SepalWidth = 3.2f,
                PetalLength = 1.3f,
                PetalWidth = 0.2f,
                FlowerType = IrisType.Setosa
            },
            new IrisFlower
            {
                SepalLength = 7.0f,
                SepalWidth = 3.2f,
                PetalLength = 4.7f,
                PetalWidth = 1.4f,
                FlowerType = IrisType.Versicolor
            },
            new IrisFlower
            {
                SepalLength = 6.4f,
                SepalWidth = 3.2f,
                PetalLength = 4.5f,
                PetalWidth = 1.5f,
                FlowerType = IrisType.Versicolor
            },
            new IrisFlower
            {
                SepalLength = 5.5f,
                SepalWidth = 2.3f,
                PetalLength = 4.0f,
                PetalWidth = 1.3f,
                FlowerType = IrisType.Versicolor
            },
            new IrisFlower
            {
                SepalLength = 7.2f,
                SepalWidth = 3.2f,
                PetalLength = 6.0f,
                PetalWidth = 1.8f,
                FlowerType = IrisType.Virginnica
            },
            new IrisFlower
            {
                SepalLength = 6.4f,
                SepalWidth = 2.8f,
                PetalLength = 5.6f,
                PetalWidth = 2.2f,
                FlowerType = IrisType.Virginnica
            }
        );
        context.SaveChanges();
    }
}