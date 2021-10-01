using System;
using System.Collections;
using System.Collections.Generic;
using App.Entities;

namespace App.Services.Contracts
{
    public interface ICompanyService
    {
        void Insert(EndPoint endPoint);
        void Edit(EndPoint endPoint, States state);
        Tuple<EndPoint, bool> FindBySerialNumber(string serialNumber);
        void Remove(string serialNumber);
        ICollection<EndPoint> GetAll();
    }
}