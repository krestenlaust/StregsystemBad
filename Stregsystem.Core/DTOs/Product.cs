namespace Stregsystem.Core.DTOs;

public record Product(int ID, string Name, int PriceInOere, bool Active, bool CanBuyOnCredit);
