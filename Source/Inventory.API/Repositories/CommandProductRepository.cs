// CommandProductRepository.cs
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class CommandProductRepository
    {
        private readonly string _connectionString;

        public CommandProductRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<CommandProduct> GetAllCommandProducts()
        {
            List<CommandProduct> commandProducts = new List<CommandProduct>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM CommandProducts", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            commandProducts.Add(new CommandProduct
                            {
                                CommandId = Convert.ToInt32(reader["CommandId"]),
                                // Populate other properties
                            });
                        }
                    }
                }
            }
            return commandProducts;
        }

        public CommandProduct GetCommandProductById(int id)
        {
            CommandProduct commandProduct = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM CommandProducts WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            commandProduct = new CommandProduct
                            {
                                CommandId = Convert.ToInt32(reader["CommandId"]),
                            };
                        }
                    }
                }
            }
            return commandProduct;
        }

        public void CreateCommandProduct(CommandProduct commandProduct)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO CommandProducts (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCommandProduct(CommandProduct commandProduct)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE CommandProducts SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", commandProduct.CommandId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCommandProduct(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM CommandProducts WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}