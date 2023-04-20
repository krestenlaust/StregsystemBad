using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.DataProviders;

/// <summary>
/// Responsible for reading and parsing user data from a data-source.
/// </summary>
internal interface IUserDataProvider
{
    IEnumerable<User> GetUsers();
}
