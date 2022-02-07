using RechargeSharp.Entities.Checkouts;
using System.Net;
using RechargeSharp.Entities.Exceptions;

namespace RechargeSharp.Utilities
{
    public static class ExceptionUtility
    {
        public static void ThrowIfSuitableExceptionFound(HttpResponseMessage responseMessage)
        {
            var message = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            switch (message)
            {
                case { } s when s.Contains(ProcessCheckoutErrorMessages.AlreadyProcessing, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CallToRouteAlreadyInProgress, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.Conflict)
                    {
                        throw new ConflictException(message);
                    }
                    break;
                case { } s when s.Contains(ProcessCheckoutErrorMessages.AuthorizationRequired, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new ScaException(message);
                    }
                    break;
                case { } s when s.Contains(ProcessCheckoutErrorMessages.CannotUseMoreThanOnce, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CheckoutAlreadyProcessed, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new CheckoutAlreadyProcessedException(message);
                    }
                    break;
                case { } s when s.Contains(ProcessCheckoutErrorMessages.CardDeclinedDoNotHonor, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CardDeclinedGenericDecline, StringComparison.InvariantCultureIgnoreCase) ||
                                s.Contains(ProcessCheckoutErrorMessages.CardDeclinedPickupCard, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CardNumberIncorrect, StringComparison.InvariantCultureIgnoreCase) ||
                                s.Contains(ProcessCheckoutErrorMessages.CvcIncorrect, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.InsufficientFunds, StringComparison.InvariantCultureIgnoreCase) ||
                                s.Contains(ProcessCheckoutErrorMessages.MaxDeclinesIn24HoursReached, StringComparison.InvariantCultureIgnoreCase) ||
                                s.Contains(ProcessCheckoutErrorMessages.CardExpired, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CardLost, StringComparison.InvariantCultureIgnoreCase) || 
                                s.Contains(ProcessCheckoutErrorMessages.CardStolen, StringComparison.InvariantCultureIgnoreCase) ||
                                s.Contains(ProcessCheckoutErrorMessages.CardDeclinedNonSpecific, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Contains(ProcessCheckoutErrorMessages.ErrorOccurredTryAgainLater, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new TransientErrorException(message);
                    }
                    break;
            }

            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException(message);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException(message);
            }

            if ((int)responseMessage.StatusCode > 399 && responseMessage.StatusCode != HttpStatusCode.TooManyRequests)
            {
                throw new Exception($"{responseMessage.RequestMessage}\r\n{responseMessage}\r\n{message}");
            }
        }
    }
}
