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
    internal class CountryService : ICountryService
    {
        private readonly AppDbContext _appDbContext;
        public CountryService()
        {
            _appDbContext = new AppDbContext();
        }
        public async Task CreateAsync(Country country)
        {
            _appDbContext.Countries.Add(country);
            await _appDbContext.SaveChangesAsync();
        }

        public  async Task DeleteAsync(int? id)
        {
            
            

                if (id is null) throw new ArgumentNullException(nameof(id));
                var data = _appDbContext.Countries.FirstOrDefault(m => m.Id == id);
                if (data is null)
                {
                    throw new NotFoundException("data not found");
                }
                _appDbContext.Countries.Remove(data);
                await _appDbContext.SaveChangesAsync();
            
        }
        public async Task<Country> GetByIdAsync(int id)
        {
            var data = _appDbContext.Countries.FirstOrDefault(m => m.Id == id);
            if (data is null)
            {
                throw new NotFoundException("data not found");
            }
            return data;
        }

        public async Task UpdateAsync(Country country)
        {

            if (country == null)
            {
                throw new ArgumentNullException(nameof(Country));
            }

            var existingcountry = await _appDbContext.Countries.FirstOrDefaultAsync(s => s.Id == country.Id);

            if (existingcountry== null)
            {
                throw new NotFoundException("city not found");
            }

            existingcountry.Name = country.Name;
            existingcountry.Population = country.Population;


            await _appDbContext.SaveChangesAsync();

        }
    }
}
