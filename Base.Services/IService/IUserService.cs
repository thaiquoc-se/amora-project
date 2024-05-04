using Base.Repositories.Models;
using Base.Services.ViewModel.ResponseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.IService
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);
    }
}
