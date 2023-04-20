using Stregsystem.Core.Validator;

namespace Stregsystem.Core;

public class DataValidator : IUsernameValidator, INameValidator, IEmailValidator
{
    readonly string UsernameRegex = "";
    readonly string FirstnameRegex = "";
    readonly string SurnameRegex = "";
    readonly string EmailRegex = "";

    public bool IsEmailValid(string address)
    {
        throw new NotImplementedException();
    }

    public bool IsFirstnameValid(string firstname)
    {
        throw new NotImplementedException();
    }

    public bool IsSurnameValid(string surname)
    {
        throw new NotImplementedException();
    }

    public bool IsUsernameValid(string username)
    {
        throw new NotImplementedException();
    }
}
