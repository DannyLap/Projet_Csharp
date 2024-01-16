using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class PhotoController
{
    private readonly PhotoService _photoService;

    public PhotoController(PhotoService photoService)
    {
        _photoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
    }

    // Endpoint pour obtenir toutes les photos
    public IEnumerable<Photo> GetPhotos()
    {
        return _photoService.GetAllPhotos();
    }

    // Endpoint pour obtenir une photo par ID
    public Photo GetPhotoById(int id)
    {
        return _photoService.GetPhotoById(id);
    }

    // Endpoint pour créer une nouvelle photo
    public Photo CreatePhoto(Photo photo)
    {
        _photoService.CreatePhoto(photo);
        return photo;
    }

    // Endpoint pour mettre à jour une photo par ID
    public bool UpdatePhoto(int id, Photo photo)
    {
        if (id != photo.PhotoId)
        {
            return false;
        }

        _photoService.UpdatePhoto(photo);
        return true;
    }

    // Endpoint pour supprimer une photo par ID
    public bool DeletePhoto(int id)
    {
        var existingPhoto = _photoService.GetPhotoById(id);

        if (existingPhoto == null)
        {
            return false;
        }

        _photoService.DeletePhoto(id);
        return true;
    }
}
