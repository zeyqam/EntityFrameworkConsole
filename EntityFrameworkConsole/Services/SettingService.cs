using EntityFrameworkConsole.Data;
using EntityFrameworkConsole.Helpers.Exceptions;
using EntityFrameworkConsole.Models;
using EntityFrameworkConsole.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConsole.Services
{
    
    
    internal class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        public SettingService()
        {
            _context = new AppDbContext();
        }
        public async Task CreateAsync(Setting setting)
        {
            await _context.Settings.AddAsync(setting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            var data = _context.Settings.FirstOrDefault(m => m.Id == id);
            if (data is null)
            {
                throw new NotFoundException("data not found");
            }
             _context.Settings.Remove(data);
            await _context.SaveChangesAsync();
        }

        public  async Task<List<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }

        public  async Task<Setting> GetByIdAsync(int id)
        {
            var data= _context.Settings.FirstOrDefault(m=>m.Id==id);
            if (data is null)
            {
                throw new NotFoundException("data not found");
            }
            return data;
        }

        public  async Task UpdateAsync(Setting setting)
        {
            if (setting == null)
            {
                throw new ArgumentNullException(nameof(setting));
            }

            var existingSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == setting.Id);

            if (existingSetting == null)
            {
                throw new NotFoundException("Setting not found");
            }

            existingSetting.Name = setting.Name;
            existingSetting.Address = setting.Address;
            existingSetting.Email= setting.Email;
            existingSetting.Phone = setting.Phone;

            
            await _context.SaveChangesAsync();
            
        }
        
    }
}
