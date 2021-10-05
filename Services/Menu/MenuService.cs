using System;
using App.Entities;
using App.Services.Contracts;
using App.Validations;

namespace App.Services.Menu
{
    public class MenuService : IMenuService
    {
        private ICompanyService _companyService;
        private IOptionService _menuOptionsService;

        public MenuService(
            IOptionService menuOptionsService,
            ICompanyService companyService
        ) {
            _menuOptionsService = menuOptionsService;
            _companyService = companyService;
            SetOptions();
        }

        private void SetOptions()
        {
            _menuOptionsService.AddOption("1) Insert a new endpoint", 1, Insert);
            _menuOptionsService.AddOption("2) Edit an existing endpoint", 2, () => {});
            _menuOptionsService.AddOption("3) Delete an existing endpoint", 3, () => {});
            _menuOptionsService.AddOption("4) List all endpoints", 4, () => {});
            _menuOptionsService.AddOption("5) Find a endpoint by 'Endpoint Serial Number'", 5, () => {});
            _menuOptionsService.AddOption("6) Exit", 6, Exit);
        }

        public void Insert()
        {
            try {
                Console.WriteLine("Digite o ID:");
                int id = Input.ToInt();

                Console.WriteLine("Digite o Serial Number:");
                string serialNumber = Console.ReadLine();

                Console.WriteLine("Digite o Number:");
                int number = Input.ToInt();

                Console.WriteLine("Digite o Firmware Verison:");
                string firmwareVersion = Console.ReadLine();

                Console.WriteLine("Digite o State:");
                int state = Input.ToInt();

                _companyService.Insert(
                    new EndPoint(id, serialNumber, number, firmwareVersion, state)
                );

                Console.WriteLine("Endpoint successfully added");
            }
            catch
            {
                throw;
            }
        }

        public void Exit()
        {
            Console.WriteLine("Do you really want to exit the application? (yes/no)");
            string answer = Console.ReadLine();
            
            if (answer.ToLower() == "yes")
                Environment.Exit(0);

            _menuOptionsService.ShowOptions();
        }
    }
}