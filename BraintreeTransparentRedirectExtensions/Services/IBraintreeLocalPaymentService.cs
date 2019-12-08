using BraintreeTransparentRedirectExtensions.Models;
using System.Threading.Tasks;

namespace BraintreeTransparentRedirectExtensions.Services
{
    public interface IBraintreeLocalPaymentService
    {
        Task<PaymentResource> CreateLocalPaymentAsync(string merchantAccountId, LocalPayment localPayment);
    }
}