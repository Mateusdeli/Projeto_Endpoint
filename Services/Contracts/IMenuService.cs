using System.Collections;

namespace App.Services.Contracts
{
    public interface IMenuService
    {
        void GetAll();
        void Exit();
        void Edit();
        void Delete();
        void FindBySerialNumber();
    }
}