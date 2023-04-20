namespace Stregsystem.Core.DTOs;

public record Product(int ID, string Name, decimal Price, bool Active, bool CanBuyOnCredit);
