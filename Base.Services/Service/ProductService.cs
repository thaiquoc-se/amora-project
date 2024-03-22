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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<ServiceResponseVM<Product>> Create(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Get(int pageSize, int pageIndex)
        {
            try
            {
                return await _unitOfWork.Product.FindAll().Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
