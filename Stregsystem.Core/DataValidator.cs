using Stregsystem.Core.Validator;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Stregsystem.Core;

public class DataValidator : IUsernameValidator, INameValidator, IEmailValidator
{
    readonly string UsernameRegex = ".*";
    readonly string FirstnameRegex = ".*";
    readonly string SurnameRegex = ".*";

    public bool IsEmailValid(string address)
    {
        try
        {
            address = new MailAddress(address).Address;
        }
        catch (FormatException)
        {
            // address is invalid
            return false;
        }

        return true;
    }

    public bool IsFirstnameValid(string firstname)
    {
        return Regex.IsMatch(firstname, FirstnameRegex);
    }

    public bool IsSurnameValid(string surname)
    {
        return Regex.IsMatch(surname, SurnameRegex);
    }

    public bool IsUsernameValid(string username)
    {
        return Regex.IsMatch(username, UsernameRegex);
    }
}