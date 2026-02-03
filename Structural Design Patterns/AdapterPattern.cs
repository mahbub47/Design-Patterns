using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Design_Patterns.Structural_Design_Patterns
{
    public class AdapterPattern
    {
        public interface IPaymentProcessor
        {
            void ProcessPayment(decimal amount, string method);
            bool CheckStatus();
            string GetTrasactionId();
        }

        public class BKashPaymentProcessor : IPaymentProcessor
        {
            private string trasactionId;
            private bool isPaymentSuccess;

            public BKashPaymentProcessor()
            {
                isPaymentSuccess = false;
            }
            public bool CheckStatus()
            {
                return isPaymentSuccess;
            }

            public string GetTrasactionId()
            {
                return trasactionId;
            }

            public void ProcessPayment(decimal amount, string currency)
            {
                Console.WriteLine($"Bkash Payment: Processing payment for amount {amount} {currency}");
                trasactionId = "TXN_" + DateTimeOffset.Now.ToUnixTimeMilliseconds();
                isPaymentSuccess = true;
                Console.WriteLine($"Bkash Payment Successful, Transaction Id: {trasactionId}");
            }
        }

        public class CheckOut
        {
            private IPaymentProcessor processor;

            public CheckOut(IPaymentProcessor paymentProcessor)
            {
                processor = paymentProcessor;
            }

            public void Checkout(decimal amount, string currency)
            {
                Console.WriteLine($"Checkout: Attempting to process order for order {amount} {currency}");
                processor.ProcessPayment(amount, currency);
                if (processor.CheckStatus())
                {
                    Console.WriteLine($"Order successful, Transaction ID: {processor.GetTrasactionId()}");
                }
                else
                {
                    Console.WriteLine($"Order failed");
                }
            }
        }


        //Adapter Class for PayPal Payment gateway
        public class PayPalAdapter : IPaymentProcessor
        {
            private PayPalPaymentProcessor paypalPaymentProcessor;
            private long referralId;

            public PayPalAdapter(PayPalPaymentProcessor paymentProcessor)
            {
                paypalPaymentProcessor = paymentProcessor;
            }
            public bool CheckStatus()
            {
                return paypalPaymentProcessor.PaymentStatus(referralId);
            }

            public string GetTrasactionId()
            {
                return $"TNX_" + referralId;
            }

            public void ProcessPayment(decimal amount, string currency)
            {
                paypalPaymentProcessor.MakePayment(amount, currency);
                referralId = paypalPaymentProcessor.GetPaymentId();
            }
        }


        //Third Party Payment Gateway
        public class PayPalPaymentProcessor
        {
            private long referenceId;
            private bool isPaymentSuccess;
            public PayPalPaymentProcessor()
            {
                referenceId = 0;
                isPaymentSuccess = false;
            }

            public void MakePayment(decimal amount, string currency)
            {
                Console.WriteLine($"Paypal Payment gateway, processing order for {amount} {currency}");
                referenceId = DateTimeOffset.Now.Ticks;
                isPaymentSuccess = true;
                Console.WriteLine($"Payment successfull for, transcation Id : {referenceId}");
            }

            public bool PaymentStatus(long refId)
            {
                Console.WriteLine($"Checking status for reference id: {refId}");
                return isPaymentSuccess;
            }

            public long GetPaymentId() { return referenceId; }
        }


        public class ECommerce
        {
            //public static void Main(string[] args)
            //{
            //    IPaymentProcessor paymentProcessor = new PayPalAdapter(new PayPalPaymentProcessor());
            //    CheckOut checkOut = new CheckOut(paymentProcessor);
            //    checkOut.Checkout(200, "BDT");
            //}
        }
    }
}
