// PaymentService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class PaymentService
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAllPayments();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.GetPaymentById(id);
        }

        public void CreatePayment(Payment payment)
        {
            _paymentRepository.CreatePayment(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentRepository.UpdatePayment(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentRepository.DeletePayment(id);
        }
    }
}