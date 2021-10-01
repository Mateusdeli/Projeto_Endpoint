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
            _menuOptionsService.AddOption("2) Edit an existing endpoint", 2, Edit);
            _menuOptionsService.AddOption("3) Delete an existing endpoint", 3, Delete);
            _menuOptionsService.AddOption("4) List all endpoints", 4, () => {});
            _menuOptionsService.AddOption("5) Find a endpoint by 'Endpoint Serial Number'", 5, FindBySerialNumber);
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

        public void Edit()
        {
            Console.WriteLine("Enter the serial number: ");
            string serialNumber = Console.ReadLine(); 

            var (endpoint, hasExists) = _companyService.FindBySerialNumber(serialNumber);
            if (hasExists)
            {
                Console.WriteLine("Enter the new state: ");
                int state = Input.ToInt();
                _companyService.Edit(endpoint, (States)state);

                Console.WriteLine("Endpoint successfully edited");

                Console.ReadKey();
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

        public void Delete()
        {
            Console.WriteLine("Enter the serial number:");
            string serialNumber = Console.ReadLine();

            Console.WriteLine("Do you really want to delete this EndPoint? (yes/no)");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "yes")
            {
                _companyService.Remove(serialNumber);
                Console.WriteLine("EndPoint successfully removed");
            }
        }

        public void FindBySerialNumber()
        {
            Console.WriteLine("Enter the serial number: ");
            string serialNumber = Console.ReadLine();

            var (endpoint, hasExists) = _companyService.FindBySerialNumber(serialNumber);
            if (hasExists)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("-----------** RESULTADO **------------------");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Id: " + endpoint.ModelId.ToString());
                Console.WriteLine("Serial Number: " + endpoint.SerialNumber.ToString());
                Console.WriteLine("Number: " + endpoint.Number.ToString());
                Console.WriteLine("Firmware Version: " + endpoint.FirmwareVersion.ToString());
                Console.WriteLine("State: " + endpoint.State.ToString());
                Console.WriteLine("--------------------------------------------");

                Console.ReadKey();
            }
        }
    }
}