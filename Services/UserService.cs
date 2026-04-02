using JobHandlerAPI.Data;
using JobHandlerAPI.Dtos;
using JobHandlerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JobHandlerAPI.Helpers;

namespace JobHandlerAPI.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Result<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            var users = _userManager.Users.ToList();

            var result = users.Select(user => new UserResponseDTO
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                EmploymentStatus = user.EmploymentStatus
            }).ToList();

            return Result<List<UserResponseDTO>>.Success(result);
        }
        public async Task<Result<bool>> UpdateUserAsync(string userId, UserUpdateDTO dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Result<bool>.Failure("User not found");

            user.Name = dto.Name;
            user.Email = dto.Email;
            
            user.UserName = dto.UserName; // add uniqe check for userName and Email
            user.PhoneNumber = dto.PhoneNumber;
            user.EmploymentStatus = dto.EmploymentStatus;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.Select(e => e.Description));

            return Result<bool>.Success(true); 
        }
        public async Task<Result<bool>> ChangePasswordAsync(string userId, ChangePasswordDTO dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Result<bool>.Failure("User not found");

            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword
            );

            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.Select(e => e.Description));

            return Result<bool>.Success(true);
        }
        public async Task<Result<bool>> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return Result<bool>.Failure("User not found");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return Result<bool>.Failure(result.Errors.Select(e => e.Description));

            return Result<bool>.Success(true);
        }
    }
}


