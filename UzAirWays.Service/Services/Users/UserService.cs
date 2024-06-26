﻿using UzAirWays.DataAccess.Repositories.Users;
using UzAirWays.Service.DTOs.Users;
using UzAirWays.Service.Mappers;

namespace UzAirWays.Service.Services.Users;
public class UserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<UserViewModel> CreateAsync(UserCreateModel model)
    {
        var existUser = (await userRepository.SelectAllAsQuerableAsync()).FirstOrDefault(user => user.Email == model.Email && !user.IsDeleted);
        if (existUser is not null)
            throw new Exception($"User is already exist with this email {model.Email}");

        var user = Mapper.Map(model);
        var createdUser = await userRepository.InsertAsync(user);
        await userRepository.SaveAsync();

        return Mapper.Map(createdUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel model)
    {
        var existUser = await userRepository.SelectAsync(id)
            ?? throw new Exception($"User is not found with this id: {id}");

        existUser.Email = model.Email;
        existUser.LastName = model.LastName;
        existUser.FirstName = model.FirstName;
        existUser.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await userRepository.UpdateAsync(existUser);
        await userRepository.SaveAsync();

        return Mapper.Map(updatedUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id)
           ?? throw new Exception($"User is not found with this Id {id}");

        existUser.DeletedAt = DateTime.UtcNow;
        await userRepository.DeleteAsync(existUser);
        await userRepository.SaveAsync();

        return true;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id)
           ?? throw new Exception($"User is not found with this Id {id}");

        return Mapper.Map(existUser);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await userRepository.SelectAllAsEnumerableAsync();
        return Mapper.Map(users);
    }
}
