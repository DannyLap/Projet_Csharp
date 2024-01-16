using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class InvoicesController
{
    private readonly InvoicesService _invoicesService;

    public InvoicesController(InvoicesService invoicesService)
    {
        _invoicesService = invoicesService ?? throw new ArgumentNullException(nameof(invoicesService));
    }

    public IEnumerable<Invoices> GetInvoices()
    {
        var invoices = _invoicesService.GetAllInvoices();
        return invoices;
    }

    public Invoices GetInvoiceById(int id)
    {
        var invoice = _invoicesService.GetInvoicesById(id);

        if (invoice == null)
        {
            return null;
        }

        return invoice;
    }

    public Invoices CreateInvoice(Invoices invoice)
    {
        _invoicesService.CreateInvoices(invoice);
        return invoice;
    }

    public bool UpdateInvoice(int id, Invoices invoice)
    {
        if (id != invoice.InvoiceId)
        {
            return false;
        }

        _invoicesService.UpdateInvoices(invoice);
        return true;
    }

    public bool DeleteInvoice(int id)
    {
        var existingInvoice = _invoicesService.GetInvoicesById(id);

        if (existingInvoice == null)
        {
            return false;
        }

        _invoicesService.DeleteInvoices(id);
        return true;
    }
}

