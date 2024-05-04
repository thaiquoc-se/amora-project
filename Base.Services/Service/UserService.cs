using Base.Repositories.Common;
using Base.Repositories.Models;
using Base.Services.IService;
using Base.Services.ViewModel.ResponseVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.User.Get(u => u.Email == email && u.Password == password).Include(u => u.Role).SingleOrDefaultAsync();
                if (user != null)
                {
                    return user;
                }
                throw new Exception("Login failed");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
