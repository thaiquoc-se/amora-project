using Base.Repositories.Models;
using Base.Services.ViewModel.ResponseVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get(int pageSize, int pageIndex);
        Task<ServiceResponseVM<Product>> Create(Product product);
    }
}
