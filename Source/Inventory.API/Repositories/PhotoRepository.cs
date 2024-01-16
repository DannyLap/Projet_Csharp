// PhotoRepository.cs
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using projetApi.Models;

namespace projetApi.Repositories
{
    public class PhotoRepository
    {
        private readonly string _connectionString;

        public PhotoRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            List<Photo> photos = new List<Photo>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Photos", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            photos.Add(new Photo
                            {
                                PhotoId = Convert.ToInt32(reader["PhotoId"]),
                            });
                        }
                    }
                }
            }
            return photos;
        }

        public Photo GetPhotoById(int id)
        {
            Photo photo = null;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM Photos WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            photo = new Photo
                            {
                                PhotoId = Convert.ToInt32(reader["PhotoId"]),
                                // Populate other properties
                            };
                        }
                    }
                }
            }
            return photo;
        }

        public void CreatePhoto(Photo photo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("INSERT INTO Photos (/* List of columns */) VALUES (/* List of values */)", connection))
                {
                    // Set parameters for each column
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePhoto(Photo photo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("UPDATE Photos SET /* Update columns */ WHERE Id = @Id", connection))
                {
                    // Set parameters for each column to update
                    command.Parameters.AddWithValue("@Id", photo.PhotoId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePhoto(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE FROM Photos WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}