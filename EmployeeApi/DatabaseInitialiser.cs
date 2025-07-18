using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Database
{
    /// <summary>
    /// Initializes the SQLite database and creates the Employees table if it does not exist.
    /// </summary>
    public static class DatabaseInitialiser
    {
        /// <summary>
        /// Initializes the database at the specified path.
        /// </summary>
        /// <param name="dbPath">The file path for the SQLite database.</param>
        public static void InitializeDatabase(string dbPath)
        {

            using var connection = new SqliteConnection($"Data Source={dbPath}");
            connection.Open();
                        
            string tableCommand = @"
                CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    BirthDate TEXT NOT NULL,
                    JobTitle TEXT NOT NULL,
                    Salary REAL NOT NULL,
                    Email TEXT NOT NULL UNIQUE
                );";

            using var createTable = new SqliteCommand(tableCommand, connection);
            createTable.ExecuteNonQuery();
        }
    }
}
