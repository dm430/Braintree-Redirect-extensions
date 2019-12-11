using BraintreetRedirectExtensions.Models;
using System.Threading.Tasks;

namespace BraintreetRedirectExtensions.Services
{
    public interface IBraintreeLocalPaymentService
    {
        Task<PaymentResource> CreateLocalPaymentAsync(string merchantAccountId, LocalPayment localPayment);
        PaymentResource CreateLocalPayment(string merchantAccountId, LocalPayment localPayment);
    }
}