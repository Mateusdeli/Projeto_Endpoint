using System.Collections;

namespace App.Services.Contracts
{
    public interface IMenuService
    {
        void Exit();
        void Edit();
        void Delete();
        void FindBySerialNumber();
    }
}