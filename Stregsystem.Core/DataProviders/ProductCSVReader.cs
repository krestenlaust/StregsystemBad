using System.Text.RegularExpressions;
using Stregsystem.Core.DTOs;
using Stregsystem.Core.Exceptions;

namespace Stregsystem.Core.DataProviders
{
    internal partial class ProductCSVReader : IProductDataProvider
    {
        readonly string csvPath;

        public ProductCSVReader(string csvPath)
        {
            this.csvPath = csvPath;
        }

        /// <summary>
        /// Opens the specified CSV file and parses the data, then returns it row by row.
        /// Note: Files are opened here as opposed to the constructor,
        /// otherwise it wouldn't be possible to call this method multiple times, in this instance's lifetime.
        /// Furthermore, to avoid IO in constructor.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Product> GetProducts()
        {
            using var fs = File.OpenRead(csvPath);
            // Note: Streamreader as opposed to the easier File.ReadAllLines, to be able to handle larger files.
            var sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                // Can't be null when sr.EndofStream isn't null.
                string line = sr.ReadLine()!;

                // id (int); name (string); price (decimal); active (bool); deactivate_date (datetime)
                // example:
                // 10; "½L Kærnemælk (2x¼)"; 525; 0;
                string[] columns = line.Split(';');

                // Parse product ID
                if (!int.TryParse(columns[0], out int productID))
                {
                    throw new InvalidIntegralValueDataProviderException($"Invalid {nameof(productID)} '{columns[0]}' in CSV-{csvPath}");
                }

                // Parse and sanitize product name
                string productName = columns[1].Trim('"');
                productName = XmlTagSanitizer().Replace(productName, "");

                // Parse product price
                if (!decimal.TryParse(columns[2], out decimal productPrice))
                {
                    throw new InvalidIntegralValueDataProviderException($"Invalid {nameof(productPrice)} '{columns[2]}' in CSV-{csvPath}");
                }

                // Parse product active-state
                bool productActive = columns[3] == "1";

                // Parse product deactivate date
                DateTime? productDeactivateDate = null;

                // Note: column only exists on seasonal products
                if (columns.Length > 4)
                {
                    if (!DateTime.TryParse(columns[4].Trim('"'), out DateTime deactivateDate))
                    {
                        throw new InvalidTimestampValueDataProviderException($"Invalid {nameof(productDeactivateDate)} '{columns[4]}' in CSV-{csvPath}");
                    }

                    productDeactivateDate = deactivateDate;
                }

                // Construct DTO
                if (productDeactivateDate is null)
                {
                    // ??? Where did 'canBuyOnCredit' go?
                    yield return new Product(productID, productName, productPrice, productActive, false);
                }
                else
                {
                    // ??? Where did season start timestamp go?
                    yield return new SeasonalProduct(productID, productName, productPrice, productActive, false, DateTime.MinValue, productDeactivateDate.Value);
                }
            }
        }

        /// <summary>
        /// Matches any xml-tag both opening and closing.
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("<[\\/a-zA-Z0-9]*?>")]
        private static partial Regex XmlTagSanitizer();
    }
}
