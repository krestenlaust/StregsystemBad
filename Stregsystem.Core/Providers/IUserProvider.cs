using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.Providers;

/// <summary>
/// The reason there is both providers and data providers is because according to the assignment, the data has to be funnelled through <c>Stregsystem</c>.
/// </summary>
public interface IUserProvider
{
    IEnumerable<User> GetUsers(Func<User, bool> predicate);
    User GetUserByUsername(string username);
}
