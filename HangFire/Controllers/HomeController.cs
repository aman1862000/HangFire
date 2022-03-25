using Braintree;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Hello aman sharma commented added in re-aman branch
namespace HangFire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBraintreeService _braintreeService;
        public HomeController(IBraintreeService braintreeService)
        {
            _braintreeService = braintreeService;
        }
        public IActionResult Index()
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();  //Genarate a token
            //ViewBag.ClientToken = clientToken;

            var data = new BookPurchaseVM
            {
                Id = 2,
                Description = "Hellow man",
                Author = "Me",
                Thumbnail = "This is thumbnail",
                Title = "This is title",
                Price = "230",
                Nonce = ""
            };

            return Ok(new { data,clientToken});
        }
        [HttpPost]
        public IActionResult Create(BookPurchaseVM model)
        {
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal("250"),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return Ok("Success");
            }
            else
            {
                return Ok("Failure");
            }
        }

    }
}
