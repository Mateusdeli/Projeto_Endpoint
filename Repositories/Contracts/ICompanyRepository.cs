using System.Collections.Generic;
using App.Entities;

namespace App.Repositories.Contracts
{
    public interface ICompanyRepository
    { 
        void Edit(EndPoint endpoint, States state);
        void Add(EndPoint entity);
        EndPoint FindBy(string serialNumber);
        void Remove(EndPoint entity);
        ICollection<EndPoint> GetAll();
    }
}