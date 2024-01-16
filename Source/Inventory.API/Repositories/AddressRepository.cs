// AddressRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class AddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Addresses", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            addresses.Add(new Address
                            {
                                AddressId = Convert.ToInt32(reader["AddressId"]),
                            });
                        }
                    }
                }
            }
            return addresses;
        }

        public Address GetAddressById(int id)
        {
            Address address = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Addresses WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            address = new Address
                            {
                                AddressId = Convert.ToInt32(reader["AddressId"]),
                            };
                        }
                    }
                }
            }
            return address;
        }

        public void CreateAddress(Address address)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO Addresses (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAddress(Address address)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE Addresses SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", address.AddressId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAddress(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM Addresses WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
