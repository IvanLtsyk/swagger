using Microsoft.EntityFrameworkCore;
using System;
using WebApiCore.Data.Models;
using WebApiCore.Data.Repositories.Abstract;

namespace WebApiCore.Data.Repositories.impl
{
    public class EfCurrentWeatherRepository : EfRepositoryBase<CurrentWeather, int>, ICurrentWeatherRepository
    {
        public EfCurrentWeatherRepository(WebApiCoreContext context) : base(context)
        {
        }
    }
}
