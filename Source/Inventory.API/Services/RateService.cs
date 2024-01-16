// RateService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class RateService
    {
        private readonly RateRepository _rateRepository;

        public RateService(RateRepository rateRepository)
        {
            _rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));
        }

        public IEnumerable<Rate> GetAllRates()
        {
            return _rateRepository.GetAllRates();
        }

        public Rate GetRateById(int id)
        {
            return _rateRepository.GetRateById(id);
        }

        public void CreateRate(Rate rate)
        {
            _rateRepository.CreateRate(rate);
        }

        public void UpdateRate(Rate rate)
        {
            _rateRepository.UpdateRate(rate);
        }

        public void DeleteRate(int id)
        {
            _rateRepository.DeleteRate(id);
        }
    }
}