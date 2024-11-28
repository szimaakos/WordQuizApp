using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordQuizApp.Data
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = "Server=localhost;Database=wordquiz;Uid=root;Pwd=yourpassword;";

        public static void InitializeDatabase()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Ellenőrizd, hogy a tábla létezik-e
                var createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS words (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        foreign_word VARCHAR(255) NOT NULL,
                        translation VARCHAR(255) NOT NULL,
                        times_correct INT DEFAULT 0
                    );";

                using (var command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Ellenőrizd, hogy van-e adat, és töltsd fel, ha nincs
                var checkDataQuery = "SELECT COUNT(*) FROM words;";
                using (var command = new MySqlCommand(checkDataQuery, connection))
                {
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        var insertDataQuery = @"
                            INSERT INTO words (foreign_word, translation) VALUES
                            ('hello', 'szia'),
                            ('apple', 'alma'),
                            ('table', 'asztal'),
                            ('house', 'ház'),
                            ('dog', 'kutya'),
                            ('cat', 'macska'),
                            ('car', 'autó'),
                            ('book', 'könyv'),
                            ('pen', 'toll'),
                            ('computer', 'számítógép');";
                        using (var insertCommand = new MySqlCommand(insertDataQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static List<(string ForeignWord, string Translation)> GetWords()
        {
            var words = new List<(string ForeignWord, string Translation)>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                var query = "SELECT foreign_word, translation FROM words;";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            words.Add((reader.GetString("foreign_word"), reader.GetString("translation")));
                        }
                    }
                }
            }

            return words;
        }
    }
}
