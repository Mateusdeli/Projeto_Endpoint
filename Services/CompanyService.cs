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
    }
}