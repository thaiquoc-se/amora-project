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
        public async Task<ServiceResponseVM<Product>> Create(Product product)
        {
            try
            {
                await _unitOfWork.Product.AddAsync(product);
                var isAdd = await _unitOfWork.SaveChangesAsync();
                if (isAdd)
                {
                    return new ServiceResponseVM<Product>
                    {
                        IsSuccess = true,
                        Title = "Product Create Successfully",
                        Result = product
                    };
                }
                return new ServiceResponseVM<Product>
                {
                    IsSuccess = false,
                    Title = "Product Create Failed",
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponseVM<Product>
                {
                    IsSuccess = false,
                    Title = "Product Create Failed",
                    Errors = new string[2] { "Product Create Failed", ex.Message }
                };
            }
        }

        public async Task<IEnumerable<Product>> Get(int pageSize, int pageIndex)
        {
            try
            {
                return await _unitOfWork.Product.FindAll().Include(p => p.Category).Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
