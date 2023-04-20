using Stregsystem.Core.DTOs;

namespace Stregsystem.Core.DataProviders
{
    internal class UserCSVReader : IUserDataProvider
    {
        readonly string csvPath;

        public UserCSVReader(string csvPath)
        {
            this.csvPath = csvPath;
        }

        public IEnumerable<User> GetUsers()
        {
            using var fs = File.OpenRead(csvPath);
            // Note: Streamreader as opposed to the easier File.ReadAllLines, to be able to handle larger files.
            var sr = new StreamReader(fs);
            bool columnHeaderLineSkipped = false;

            while (!sr.EndOfStream)
            {
                // Can't be null when sr.EndofStream isn't null.
                string line = sr.ReadLine()!;

                if (!columnHeaderLineSkipped)
                {
                    columnHeaderLineSkipped = true;
                    continue;
                }

                // firstname;lastname;username;email
                // example:
                // "Kresten Laust";Sckerl;krestenlaust;kresten@kresten.xyz
                string[] columns = line.Split(';');

                string userFirstname = columns[0].Trim('"');
                string userSurname = columns[1].Trim('"');
                string userScreenname = columns[2].Trim('"');
                string userEmail = columns[3].Trim('"');

                // ??? Apparantly user balances aren't stored anywhere, I can't see any problems with ephemeral bank accounts.
                yield return new User(userFirstname, userSurname, userScreenname, userEmail, 0);
            }
        }
    }
}
