using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Providers;

/// <summary>
/// The reason there is both providers and data providers is because according to the assignment, the data has to be funnelled through <c>Stregsystem</c>.
/// </summary>
public interface IProductProvider
{
    IEnumerable<Product> ActiveProducts { get; }

    Product GetProductByID(int id);
}
