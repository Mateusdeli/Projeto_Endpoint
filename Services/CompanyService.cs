using System;
using System.Collections;
using System.Collections.Generic;
using App.Entities;
using App.Repositories;
using App.Repositories.Contracts;
using App.Services.Contracts;
using Exceptions.EndPoint;

namespace App.Services
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Insert(EndPoint endPoint)
        {
            var result = _companyRepository.FindBy(endPoint.SerialNumber);
            if (result == null)
            {
                _companyRepository.Add(endPoint);
                return;                
            }
            throw new EndPointNotFoundException("This Endpoint already exists.");
        }

        public void Edit(EndPoint endPoint, States state)
        {
            _companyRepository.Edit(endPoint, state);
        }

        public Tuple<EndPoint, bool> FindBySerialNumber(string serialNumber)
        {
            var endPoint = _companyRepository.FindBy(serialNumber);
            if (endPoint != null)
            {
                return new Tuple<EndPoint, bool>(endPoint, true);
            }
            throw new SerialNumberNotFoundException("Endpoint with the serial number entered was not found");
        }

        public void Remove(string serialNumber)
        {
            var result = FindBySerialNumber(serialNumber);
            _companyRepository.Remove(result.Item1);      
        }

        public ICollection<EndPoint> GetAll()
        {
            var endPointList = _companyRepository.GetAll();
            if (endPointList.Count > 0)
            {
                return endPointList;
            }
            throw new EndPointNotFoundException("No endpoint was found");
        }
    }
}