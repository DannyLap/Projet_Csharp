using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class RateController
{
    private readonly RateService _rateService;

    public RateController(RateService rateService)
    {
        _rateService = rateService ?? throw new ArgumentNullException(nameof(rateService));
    }

    // GET
    public IEnumerable<Rate> GetRates()
    {
        return _rateService.GetAllRates();
    }

    // GET by ID
    public Rate GetRateById(int id)
    {
        return _rateService.GetRateById(id);
    }

    // POST
    public Rate CreateRate(Rate rate)
    {
        return _rateService.CreateRate(rate);
    }

    // PUT
    public bool UpdateRate(int id, Rate rate)
    {
        if (id != rate.RateId)
            return false;

        return _rateService.UpdateRate(rate);
    }

    // DELETE
    public bool DeleteRate(int id)
    {
        var rate = _rateService.GetRateById(id);

        if (rate == null)
            return false;

        _rateService.DeleteRate(id);
        return true;
    }
}


