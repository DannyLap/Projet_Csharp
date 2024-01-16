using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class UserService
{
    private List<User> _users = new List<User>();

    public IEnumerable<User> GetUsers()
    {
        return _users;
    }

    public User GetUserById(int id)
    {
        return _users.Find(user => user.UserId == id);
    }

    public void CreateUser(User user)
    {
        user.UserId = _users.Count + 1;
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = _users.Find(u => u.UserId == user.UserId);

        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.UserEmail = user.UserEmail;
        }
    }

    public void DeleteUser(int id)
    {
        _users.RemoveAll(user => user.UserId == id);
    }
}
