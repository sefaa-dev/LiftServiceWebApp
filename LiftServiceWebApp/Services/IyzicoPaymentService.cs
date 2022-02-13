using LiftServiceWebApp.Models.Payment;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LiftServiceWebApp.Services
{
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IyzicoPaymentOptions _options;
        public IyzicoPaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            var section = _configuration.GetSection(IyzicoPaymentOptions.Key);
            _options = new IyzicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"],
                ThreedsCallbackUrl = section["ThreedsCallbackUrl"],
            };
        }
        public List<InstallmentModel> CheckInstallments(string binNumber, decimal price)
        {


            return null;
        }

        public PaymentResponseModel Pay(PaymentModel model)
        {


            return null;


        }
    }
}
