using System;
using System.Collections.Generic;
using App.Validations;
using App.Services.Contracts;

namespace App.Services.Menu
{
    public class OptionService : IOptionService
    {
        private Dictionary<string, Dictionary<int, Action>> _options;

        public OptionService()
        {
            _options = new Dictionary<string, Dictionary<int, Action>>();
        }

        public void AddOption(string message, int option, Action action)
            => _options.Add(message, new() { { option, action } });

        public void ShowOptions()
        {
            foreach (var option in _options)
                Console.WriteLine(option.Key);
            
            SelectMenuOption();
        }

        private void SelectMenuOption()
        {
            var option = Input.ToInt();
            ExecuteOption(option);
        }

        private void ExecuteOption(int optionSelected)
        {
            foreach (var option in _options.Values)
            {
                if (option.ContainsKey(optionSelected))
                {
                    option[optionSelected].Invoke();
                }
            }
        }

    }
}