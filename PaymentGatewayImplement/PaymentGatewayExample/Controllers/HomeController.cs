using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Stripe.Infrastructure;
using Stripe;
using System.Diagnostics;

namespace PaymentGatewayExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }

        [Obsolete]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["stripePublishableKey"]);
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["stripeSecretKey"];

            var myCharge = new Stripe.ChargeCreateOptions();
            myCharge.Amount = 500;
            myCharge.Currency = "USD";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);

            Debug.WriteLine(stripeCharge.Id);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}