// PaymentRepository.cs
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class PaymentRepository
    {
        private readonly string _connectionString;

        public PaymentRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Payments", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentId = Convert.ToInt32(reader["PaymentId"]),
                            });
                        }
                    }
                }
            }
            return payments;
        }

        public Payment GetPaymentById(int id)
        {
            Payment payment = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Payments WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            payment = new Payment
                            {
                                PaymentId = Convert.ToInt32(reader["PaymentId"]),
                                // Populate other properties
                            };
                        }
                    }
                }
            }
            return payment;
        }

        public void CreatePayment(Payment payment)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO Payments (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE Payments SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", payment.PaymentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePayment(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM Payments WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}