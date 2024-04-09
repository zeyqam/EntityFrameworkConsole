using EntityFrameworkConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services.Interfaces
{
    internal interface ICityService
    {
        Task<List<City>> GetAllByCountryIdAsync(int id);
        Task<City> GetByIdAsync(int id);
        Task CreateAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(int? id);


    }
}
