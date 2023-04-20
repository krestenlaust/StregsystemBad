using Stregsystem.Core.DTO;

namespace Stregsystem.Core.DataProviders
{
    public interface IProductProvider
    {
        IEnumerable<Product> ActiveProducts { get; }

        Product GetProductByID(int id);
    }
}
