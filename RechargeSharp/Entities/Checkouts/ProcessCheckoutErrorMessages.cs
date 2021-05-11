using System;
using System.Collections.Generic;
using System.Text;

namespace RechargeSharp.Entities.Checkouts
{
    public static class ProcessCheckoutErrorMessages
    {
        public static string AlreadyProcessing => "There is currently another in-progress request using this Stripe token (that probably means you clicked twice, and the other charge is still going through)";
        public static string CannotUseMoreThanOnce => "You cannot use a Stripe token more than once:";
        public static string CallToRouteAlreadyInProgress => "A call to this route is already in progress.";
        public static string InsufficientFunds => "Your card has insufficient funds.";
        public static string CardDeclinedDoNotHonor => "Your card was declined. decline_code = do_not_honor";
        public static string CardNumberIncorrect => "Your card number is incorrect.";
        public static string CardDeclinedGenericDecline => "Your card was declined. decline_code = generic_decline";
        public static string CvcIncorrect => "Your card's security code is incorrect.";
        public static string CardDeclinedPickupCard => "Your card was declined. decline_code = pickup_card";
        public static string AuthorizationRequired => "Your card was declined. This transaction requires authentication.";
        public static string CheckoutAlreadyProcessed => "Checkout has already been processed.";
        public static string ErrorOccurredTryAgainLater => "An error occurred while processing your card. Try again in a little bit.";
        public static string MaxDeclinesIn24HoursReached => "You have exceeded the maximum number of declines on this card in the last 24 hour period. Please contact us via https://support.stripe.com/contact if you need further assistance.";
        public static string CardExpired => "Your card has expired.";
        public static string CardLost => "Your card was declined. decline_code = lost_card";
        public static string CardStolen => "Your card was declined. decline_code = stolen_card";
        public static string CardDeclinedNonSpecific => "Your card was declined.";
    }
}
