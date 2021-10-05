using System;
using System.Text;
using App.Services.Contracts;
using App.Services.Menu;

namespace EndPointProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            IOptionService menuOptionsService = new OptionService();
            IMenuService menuService = new MenuService(menuOptionsService);
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
