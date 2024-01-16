// PhotoService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class PhotoService
    {
        private readonly PhotoRepository _photoRepository;

        public PhotoService(PhotoRepository photoRepository)
        {
            _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            return _photoRepository.GetAllPhotos();
        }

        public Photo GetPhotoById(int id)
        {
            return _photoRepository.GetPhotoById(id);
        }

        public void CreatePhoto(Photo photo)
        {
            _photoRepository.CreatePhoto(photo);
        }

        public void UpdatePhoto(Photo photo)
        {
            _photoRepository.UpdatePhoto(photo);
        }

        public void DeletePhoto(int id)
        {
            _photoRepository.DeletePhoto(id);
        }
    }
}