using App.Entities;
using App.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private Company _company;

        public CompanyRepository()
        {
            _company = new Company();
        }
        public void Add(EndPoint entity)
            => _company.EndPoints.Add(entity);

        public void Edit(EndPoint endpoint, States state)
            => endpoint.State = ((int)state);

        public ICollection<EndPoint> GetAll()
            => _company.EndPoints;

        public EndPoint FindBy(string serialNumber)
            => _company.EndPoints.FirstOrDefault(e => e.SerialNumber == serialNumber);

        public void Remove(EndPoint entity)
            => _company.EndPoints.Remove(entity);
    }
}