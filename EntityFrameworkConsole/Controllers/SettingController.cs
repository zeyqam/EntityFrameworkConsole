using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Controllers
{
    internal class SettingController
    {
        private readonly ISettingService _settingService;

        public SettingController()
        {
            _settingService = new SettingService();
        }

        public async Task GetAllAsync()
        {
            var datas=await _settingService.GetAllAsync();
            foreach (var item in datas)
            {
                string data = $"Name: {item.Name}, Email: {item.Email}, Phone:{item.Phone}, Address: {item.Address}";
                Console.WriteLine(data);
            }
        }
        public async Task GetByIdAsync()
        {
             Console.WriteLine("Add setting id:");
            int id=Convert.ToInt32(Console.ReadLine());


            try
            {
                var data = await _settingService.GetByIdAsync(id);
                
                
                string result = $"Name: {data.Name}, Email: {data.Email}, Phone:{data.Phone}, Address: {data.Address}";
                Console.WriteLine(result);

            }
            catch (Exception ex)
            {

                 Console.WriteLine(ex.Message);
            }
        }



    }
}
