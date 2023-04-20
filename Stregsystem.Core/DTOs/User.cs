namespace Stregsystem.Core.DTOs;

public class User
{
    public User(string firstname, string surname, string username, string emailaddress, decimal balance)
    {
        Firstname = firstname;
        Surname = surname;
        Username = username;
        Emailaddress = emailaddress;
        Balance = balance;
    }

    public string Firstname { get; init; }
    public string Surname { get; init; }
    public string Username { get; init; }
    public string Emailaddress { get; init; }
    public decimal Balance { get; set; }
}
