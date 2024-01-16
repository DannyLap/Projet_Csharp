// InvoicesRepository.cs
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class InvoicesRepository
    {
        private readonly string _connectionString;

        public InvoicesRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Invoices> GetAllInvoices()
        {
            List<Invoices> invoices = new List<Invoices>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Invoices", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            invoices.Add(new Invoices
                            {
                                InvoiceId = Convert.ToInt32(reader["InvoiceId"]),
                            });
                        }
                    }
                }
            }
            return invoices;
        }

        public Invoices GetInvoicesById(int id)
        {
            Invoices invoices = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Invoices WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            invoices = new Invoices
                            {
                                InvoiceId = Convert.ToInt32(reader["InvoiceId"]),
                                // Populate other properties
                            };
                        }
                    }
                }
            }
            return invoices;
        }

        public void CreateInvoices(Invoices invoices)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO Invoices (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateInvoices(Invoices invoices)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE Invoices SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", invoices.InvoiceId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteInvoices(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM Invoices WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}