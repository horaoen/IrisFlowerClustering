using IrisFlowerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.ML;

namespace IrisFlowerWeb.Pages.TypePredict;

public class IndexModel : PageModel
{
    private readonly IrisFlowerContext _context;
    private readonly PredictionEnginePool<IrisFlowerData, IrisFlowerPrediction> _predictionEnginePool;

    public IndexModel(
        IrisFlowerContext context,
        PredictionEnginePool<IrisFlowerData, IrisFlowerPrediction> predictionEnginePool)
    {
        _context = context;
        _predictionEnginePool = predictionEnginePool;
    }

    [BindProperty] 
    public IrisFlowerData IrisFlowerData { get; set; }
    public IrisFlowerPrediction IrisFlowerPrediction { get; set; }
    public IrisFlower IrisFlower { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (IrisFlowerData == null)
        {
            return Page();
        }

        if (!ModelState.IsValid) return Page();

        IrisFlowerPrediction =
            _predictionEnginePool.Predict(modelName: "IrisClusteringModel", example: IrisFlowerData);
        
        IrisFlower = new IrisFlower
        {
            SepalLength = IrisFlowerData.SepalLength,
            SepalWidth = IrisFlowerData.SepalWidth,
            PetalLength = IrisFlowerData.PetalLength,
            PetalWidth = IrisFlowerData.PetalWidth,
            FlowerType = GetFlowerType(IrisFlowerPrediction)
        };
        _context.IrisFlower.AddAsync(IrisFlower);
        _context.SaveChangesAsync();
        return Page();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        return Page();
    }

    public IrisType GetFlowerType(IrisFlowerPrediction irisFlowerPrediction)
        => irisFlowerPrediction.PredictedClusterId switch
        {
            1 => IrisType.Setosa,
            3 => IrisType.Versicolor,
            2 => IrisType.Virginnica
        };
    
}