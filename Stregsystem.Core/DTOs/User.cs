namespace Stregsystem.Core.DTOs;

public class User
{
    public User(string firstname, string surname, string username, string emailaddress, int balanceInOere)
    {
        Firstname = firstname;
        Surname = surname;
        Username = username;
        Emailaddress = emailaddress;
        BalanceInOere = balanceInOere;
    }

    public string Firstname { get; init; }
    public string Surname { get; init; }
    public string Username { get; init; }
    public string Emailaddress { get; init; }
    public int BalanceInOere { get; set; }

    public override string ToString() => $"{Firstname} {Surname} ({Emailaddress})";
}
