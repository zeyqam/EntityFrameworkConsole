using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Controllers
{
    internal class CountryController
    {
        private readonly ICountryService _countryService;
        public CountryController()
        {
            _countryService=new CountryService();
        }
        public async Task CreateCountryAsync()
        {
            try
            {
                Console.WriteLine("Enter the name of the country:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the population of the country:");
                int population = Convert.ToInt32(Console.ReadLine());

                Country country = new Country { Name = name, Population = population };

                await _countryService.CreateAsync(country);
                Console.WriteLine("Country created successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: Country object is null");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the country");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteCountryAsync()
        {
            try
            {
                Console.WriteLine("Enter the id of the country to delete:");
                int id = Convert.ToInt32(Console.ReadLine());

                await _countryService.DeleteAsync(id);
                Console.WriteLine("Country deleted successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: Country id is null");
                Console.WriteLine(ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the country");
                Console.WriteLine(ex.Message);
            }
        }
        public async Task GetCountryByIdAsync()
        {
            try
            {
                Console.WriteLine("Enter the id of the country:");
                int id = Convert.ToInt32(Console.ReadLine());

                var country = await _countryService.GetByIdAsync(id);

                Console.WriteLine($"Country Name: {country.Name}, Population: {country.Population}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching the country");
                Console.WriteLine(ex.Message);
            }
        }
        public async Task UpdateCountryAsync()
        {
            try
            {
                Console.WriteLine("Enter the id of the country to update:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();

                Console.WriteLine("Enter the new population:");
                int newPopulation = Convert.ToInt32(Console.ReadLine());

                Country updatedCountry = new Country { Name = newName, Population = newPopulation };

                await _countryService.UpdateAsync(updatedCountry);
                Console.WriteLine("Country updated successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: Country object is null");
                Console.WriteLine(ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the country");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
