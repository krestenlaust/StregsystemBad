using Stregsystem.Core.DTO;

namespace Stregsystem.Core.DataProviders
{
    public interface IUserProvider
    {
        User GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
    }
}
