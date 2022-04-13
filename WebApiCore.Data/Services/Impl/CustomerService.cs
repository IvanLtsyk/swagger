using System;
using WebApiCore.Data.Models;
using WebApiCore.Data.Repositories;
using WebApiCore.Data.Services.Abstract;

namespace WebApiCore.Data.Services.impl
{
    public class CustomerService : CrudServiceBase<Customer, int>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
