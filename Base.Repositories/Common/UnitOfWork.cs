using Base.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories.Common
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        Task<bool> SaveChangesAsync();

    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IProductRepository Product { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, IProductRepository product, IUserRepository user)
        {
            _applicationDbContext = applicationDbContext;
            Product = product;
            User = user;

        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _applicationDbContext.SaveChangesAsync() > 0);
        }
    }
}
