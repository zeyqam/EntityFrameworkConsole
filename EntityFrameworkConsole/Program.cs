﻿

//using EntityFrameworkConsole.Data;

//AppDbContext context = new AppDbContext();

//void GetAllSettings()
//{
//    var datas=context.Settings.ToList();

//    foreach(var item in datas)
//    {
//        Console.WriteLine(item.Address + " " +item.Phone + " " + item.Email);
//    }
//}
////GetAllSettings();

//void GetById(int id)
//{
//    var data=context.Settings.FirstOrDefault(m=>m.Id==id);
//    Console.WriteLine(data.Address + " " + data.Phone + " " + data.Email);
//}

//GetAllSettings();

//Console.WriteLine("----------");
//GetById(2);

using EntityFrameworkConsole.Controllers;

//SettingController settingController = new SettingController();
//await settingController.GetAllAsync();
////await settingController.GetByIdAsync();
////await settingController.CreateAsync();
////await settingController.DeleteAsync();
//await settingController.UpdateAsync();

//await settingController.GetAllAsync();
 CityController cityController = new CityController();
 //await cityController.GetallByCountryId();
await cityController.GetByIdAsync();
//await cityController.UpdateCityAsync();
//cityController.GetAllByCountryId();
