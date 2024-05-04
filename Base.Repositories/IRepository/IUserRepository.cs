
using Base.Repositories.Common;
using Base.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories.IRepository;

public interface IUserRepository : IBaseRepository<User, int>
{

}
