using System;

namespace App.Services.Contracts
{
    public interface IOptionService
    {
        void AddOption(string message, int option, Action action);
        void ShowOptions();
    }
}