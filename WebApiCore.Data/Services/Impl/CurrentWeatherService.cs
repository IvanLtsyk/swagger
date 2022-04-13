using System;
using WebApiCore.Data.Models;
using WebApiCore.Data.Repositories;
using WebApiCore.Data.Services.Abstract;

namespace WebApiCore.Data.Services.Impl
{
    public class CurrentWeatherService : CrudServiceBase<CurrentWeather, int>, ICurrentWeatherService
    {
        public CurrentWeatherService(ICurrentWeatherRepository repository) : base(repository)
        {

        }
    }
}
