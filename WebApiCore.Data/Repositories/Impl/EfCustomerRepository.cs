using System;
using WebApiCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Data.Repositories.Abstract;

namespace WebApiCore.Data.Repositories.impl
{
    public class EfCustomerRepository : EfRepositoryBase<Customer, int>, ICustomerRepository
    {
        public EfCustomerRepository(WebApiCoreContext context) : base(context)
        {
        }
    }
}
