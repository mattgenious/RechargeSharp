using RechargeSharp.Entities.Checkouts;
using System;
using System.Net;
using RechargeSharp.Entities.Exceptions;
using System.Net.Http;

namespace RechargeSharp.Utilities
{
    public static class ExceptionUtility
    {
        public static void ThrowIfSuitableExceptionFound(HttpResponseMessage responseMessage)
        {
            var message = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            switch (message)
            {
                case { } s when s.Equals(ProcessCheckoutErrorMessages.AlreadyProcessing, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.Conflict)
                    {
                        throw new ConflictException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.AuthorizationRequired, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new ScaException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CallToRouteAlreadyInProgress, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.Conflict)
                    {
                        throw new ConflictException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CannotUseMoreThanOnce, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new CheckoutAlreadyProcessedException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CardDeclinedDoNotHonor, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CardDeclinedGenericDecline, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CardDeclinedPickupCard, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CardNumberIncorrect, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CheckoutAlreadyProcessed, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new CheckoutAlreadyProcessedException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.CvcIncorrect, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.ErrorOccurredTryAgainLater, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new TransientErrorException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.InsufficientFunds, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
                    }
                    break;
                case { } s when s.Equals(ProcessCheckoutErrorMessages.MaxDeclinesIn24HoursReached, StringComparison.InvariantCultureIgnoreCase):
                    if (responseMessage.StatusCode == HttpStatusCode.UnprocessableEntity)
                    {
                        throw new PaymentException(message);
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
