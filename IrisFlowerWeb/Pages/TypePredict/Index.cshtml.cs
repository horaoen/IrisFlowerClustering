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

    [BindProperty(SupportsGet = true)] public IrisFlowerData IrisFlowerData { get; set; } = default!;
    public IrisFlowerPrediction IrisFlowerPrediction { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        IrisFlowerPrediction =
            _predictionEnginePool.Predict(modelName: "IrisClusteringModel", example: IrisFlowerData);
        return Page();
    }

    public IrisType GetFlowerType(IrisFlowerPrediction irisFlowerPrediction)
        => irisFlowerPrediction.PredictedClusterId switch
        {
            1 => IrisType.Setosa,
            2 => IrisType.Versicolor,
            3 => IrisType.Virginnica
        };
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || _context.IrisFlower == null || IrisFlowerData == null || IrisFlowerPrediction == null)
        {
            return Page();
        }

        IrisFlower irisFlower = new IrisFlower
        {
            SepalLength = IrisFlowerData.SepalLength,
            SepalWidth = IrisFlowerData.SepalWidth,
            PetalLength = IrisFlowerData.PetalLength,
            PetalWidth = IrisFlowerData.PetalWidth,
            FlowerType = GetFlowerType(IrisFlowerPrediction)
        };
        
        _context.IrisFlower.AddAsync(irisFlower);
        _context.SaveChangesAsync();
        return Page();
    }
}