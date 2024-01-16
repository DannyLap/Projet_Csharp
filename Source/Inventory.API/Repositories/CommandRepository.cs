// CommandRepository.cs
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class CommandRepository
    {
        private readonly string _connectionString;

        public CommandRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Command> GetAllCommands()
        {
            List<Command> commands = new List<Command>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Commands", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            commands.Add(new Command
                            {
                                CommandId = Convert.ToInt32(reader["CommandId"]),
                            });
                        }
                    }
                }
            }
            return commands;
        }

        public Command GetCommandById(int id)
        {
            Command command1 = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Commands WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            command = new Command
                            {
                                CommandId = Convert.ToInt32(reader["CommandId"]),
                                // Populate other properties
                            };
                        }
                    }
                }
            }
            return command1;
        }

        public void CreateCommand(Command command1)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command1 = new MySqlCommand("INSERT INTO Commands (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command1.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCommand(Command command1)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE Commands SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", command1.CommandId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCommand(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM Commands WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}