using System.Threading.Tasks;
using Weatherex.Application.Dto;

namespace Weatherex.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<LocationDto> GetWeatherInLocationAsync(string city);
    }
}
