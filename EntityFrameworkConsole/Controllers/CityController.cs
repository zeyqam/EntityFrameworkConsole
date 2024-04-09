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
    internal class CityController
    {
        private readonly ICityService _cityService;
        public CityController()
        {
            _cityService = new CityService();
        }

        public async Task GetAllByCountryId()
        {
             Console.WriteLine("Add  country id: ");
            int countryId=int.Parse(Console.ReadLine());
            var cities=await _cityService.GetAllByCountryIdAsync(countryId);
              foreach (var item in cities)
            {
                string data=$"Name: {item.Name}, Country: {item.Country.Name}";

                Console.WriteLine(data);
            }
        }
        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add city id:");
            int id = Convert.ToInt32(Console.ReadLine());


            try
            {
                var data = await _cityService.GetByIdAsync(id);


                string result = $"Name: {data.Name}, CountryId: {data.CountryId}";
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public async Task UpdateCityAsync()
        {
            try
            {
                Console.WriteLine("Enter the id of the city to update:");
                int id = Convert.ToInt32(Console.ReadLine());

                var city = await _cityService.GetByIdAsync(id);

                if (city == null)
                {
                    Console.WriteLine("City not found");
                    return;
                }

                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();
                city.Name = newName;

                Console.WriteLine("Enter the new country id:");
                int newCountryId = Convert.ToInt32(Console.ReadLine());
                city.CountryId = newCountryId;

                await _cityService.UpdateAsync(city);
                Console.WriteLine("City updated successfully");
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
                Console.WriteLine("An error occurred while updating the city");
                Console.WriteLine(ex.Message);
            }
        }
        public async Task DeleteCityAsync()
        {
            try
            {
                Console.WriteLine("Enter the id of the city to delete:");
                int id = Convert.ToInt32(Console.ReadLine());

                await _cityService.DeleteAsync(id);
                Console.WriteLine("City deleted successfully");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid number.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Error: City id is null");
                Console.WriteLine(ex.Message);
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the city");
                Console.WriteLine(ex.Message);
            }
        }
        public async Task CreateCityAsync()
        {
            
            
                Console.WriteLine("Enter the name of the city:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the country id:");
                int countryId = Convert.ToInt32(Console.ReadLine());

                City city = new City { Name = name, CountryId = countryId };

                await _cityService.CreateAsync(city);
                Console.WriteLine("City created successfully");
            
        }
    }
}
