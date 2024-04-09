using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services
{
    internal class CityService : ICityService
    {
        private readonly AppDbContext _appDbContext;
        public CityService()
        {
            _appDbContext = new AppDbContext();
        }

        public async Task CreateAsync(City city)
        {
            _appDbContext.Cities.Add(city);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {

            if (id is null) throw new ArgumentNullException(nameof(id));
            var data = _appDbContext.Cities.FirstOrDefault(m => m.Id == id);
            if (data is null)
            {
                throw new NotFoundException("data not found");
            }
            _appDbContext.Cities.Remove(data);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllByCountryIdAsync(int id)
        {
            return await _appDbContext.Cities.Include(m=>m.Country).Where(m=>m.CountryId==id).ToListAsync();

        }

        public async Task<City> GetByIdAsync(int id)
        {
            var data = _appDbContext.Cities.FirstOrDefault(m => m.Id == id);
            if (data is null)
            {
                throw new NotFoundException("data not found");
            }
            return data;
        }

        public async Task UpdateAsync(City city)
        {
            if (city== null)
            {
                throw new ArgumentNullException(nameof(City));
            }

            var existingcity = await _appDbContext.Cities.FirstOrDefaultAsync(s => s.Id == city.Id);

            if (existingcity == null)
            {
                throw new NotFoundException("city not found");
            }

            existingcity.Name=city.Name;
            existingcity.CountryId=city.CountryId;
            

            await _appDbContext.SaveChangesAsync();

        }
    }
}
