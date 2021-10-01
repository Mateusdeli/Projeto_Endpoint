using System;
using System.Text;
using App.Repositories;
using App.Services;
using App.Services.Contracts;
using App.Services.Menu;

namespace EndPointProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            IOptionService menuOptionsService = new OptionService();
            IMenuService menuService = 
                new MenuService(menuOptionsService, 
                new CompanyService(
                    new CompanyRepository()));

            while(true)
            {
                try 
                {
                    menuOptionsService.ShowOptions();
                }
                catch(Exception e)
                {
                    StringBuilder builder = new StringBuilder();
                    
                    builder.AppendLine("---- ** Error ** ----");
                    builder.AppendLine(e.Message);
                    builder.AppendLine("---------------------");

                    Console.WriteLine(builder);
                    Console.ReadKey();
                }
            }
        }
    }
}
