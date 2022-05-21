using IrisFlowerWeb.Models;

namespace IrisFlowerWeb.Services;

public interface IIrisDataRepository
{
    IEnumerable<IrisData> GetAllIris();
}