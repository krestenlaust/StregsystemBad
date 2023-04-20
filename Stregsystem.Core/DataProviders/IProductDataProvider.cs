using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.DataProviders;

/// <summary>
/// Responsible for reading and parsing product data from a data-source.
/// </summary>
internal interface IProductDataProvider
{
    public IEnumerable<Product> GetProducts();
}
