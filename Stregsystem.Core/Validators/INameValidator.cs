namespace Stregsystem.Core.Validator
{
    public interface INameValidator
    {
        public bool IsFirstnameValid(string firstname);
        public bool IsSurnameValid(string surname);
    }
}
