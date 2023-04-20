namespace Stregsystem.Core.DTOs
{
    /// <summary>
    /// Note: It had to be done this way according to assignment.
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="Name"></param>
    /// <param name="Price"></param>
    /// <param name="Active"></param>
    /// <param name="CanBuyOnCredit"></param>
    /// <param name="SeasonStartDate"></param>
    /// <param name="SeasonEndDate"></param>
    public record SeasonalProduct(int ID, string Name, decimal Price, bool Active, bool CanBuyOnCredit, DateTime SeasonStartDate, DateTime SeasonEndDate) : Product(ID, Name, Price, Active, CanBuyOnCredit);
}
