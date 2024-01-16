// InvoicesService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class InvoicesService
    {
        private readonly InvoicesRepository _invoicesRepository;

        public InvoicesService(InvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository ?? throw new ArgumentNullException(nameof(invoicesRepository));
        }

        public IEnumerable<Invoices> GetAllInvoices()
        {
            return _invoicesRepository.GetAllInvoices();
        }

        public Invoices GetInvoicesById(int id)
        {
            return _invoicesRepository.GetInvoicesById(id);
        }

        public void CreateInvoices(Invoices invoices)
        {
            _invoicesRepository.CreateInvoices(invoices);
        }

        public void UpdateInvoices(Invoices invoices)
        {
            _invoicesRepository.UpdateInvoices(invoices);
        }

        public void DeleteInvoices(int id)
        {
            _invoicesRepository.DeleteInvoices(id);
        }
    }
}