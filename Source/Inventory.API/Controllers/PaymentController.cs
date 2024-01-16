using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class PaymentController
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
    }

    public IEnumerable<Payment> GetPayments()
    {
        var payments = _paymentService.GetAllPayments();
        return payments;
    }

    public Payment GetPaymentById(int id)
    {
        var payment = _paymentService.GetPaymentById(id);

        if (payment == null)
        {
            return null;
        }

        return payment;
    }

    public Payment CreatePayment(Payment payment)
    {
        _paymentService.CreatePayment(payment);
        return payment;
    }

    public bool UpdatePayment(int id, Payment payment)
    {
        if (id != payment.PaymentId)
        {
            return false;
        }

        _paymentService.UpdatePayment(payment);
        return true;
    }

    public bool DeletePayment(int id)
    {
        var existingPayment = _paymentService.GetPaymentById(id);

        if (existingPayment == null)
        {
            return false;
        }

        _paymentService.DeletePayment(id);
        return true;
    }
}
