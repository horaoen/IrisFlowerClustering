using Microsoft.ML.Data;

namespace IrisFlowerWeb.Models;

public class IrisFlowerPrediction : IrisFlowerData
{
    [ColumnName("PredictedLabel")]
    public uint PredictedClusterId;

    [ColumnName("Score")]
    public float[] Distances;
}
