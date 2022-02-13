using LiftServiceWebApp.Models.Payment;
using System.Collections.Generic;

namespace LiftServiceWebApp.Services
{
    public interface IPaymentService
    {
        public InstallmentModel CheckInstallments(string binNumber, decimal price);
        public PaymentResponseModel Pay(PaymentModel model);
    }
}
