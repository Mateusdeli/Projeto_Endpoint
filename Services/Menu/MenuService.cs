using System;
using App.Entities;
using App.Services.Contracts;
using App.Validations;

namespace App.Services.Menu
{
    public class MenuService : IMenuService
    {
        private IOptionService _menuOptionsService;

        public MenuService(
            IOptionService menuOptionsService
        ) {
            _menuOptionsService = menuOptionsService;
            SetOptions();
        }
        
        private void SetOptions()
        {
            _menuOptionsService.AddOption("1) Insert a new endpoint", 1, () => {});
            _menuOptionsService.AddOption("2) Edit an existing endpoint", 2, () => {});
            _menuOptionsService.AddOption("3) Delete an existing endpoint", 3, () => {});
            _menuOptionsService.AddOption("4) List all endpoints", 4, () => {});
            _menuOptionsService.AddOption("5) Find a endpoint by 'Endpoint Serial Number'", 5, () => {});
            _menuOptionsService.AddOption("6) Exit", 6, () => {});
        }
    }
}