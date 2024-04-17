using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Models;
using Microsoft.AspNetCore.Mvc;
using PayStack.Net;
using System.Diagnostics.CodeAnalysis;

namespace FinalCarDealershipApplication.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _context;
        private readonly string token;

        private PayStackApi Paystack { get; set; }

        public PaymentController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
            token = _configuration["Payment:PaystackSk"];
            Paystack = new PayStackApi(token);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(Payment payment)
        {
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = payment.Amount * 100,
                Email = payment.Email,
                Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "http://localhost:7116/payment/verify"
            };

            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if(response.Status)
            {
                var transaction = new Transactions
                {
                    Amount = payment.Amount,
                    Email = payment.Email,
                    TransRef = request.Reference,
                    FullName = payment.FullName
                };

               // await _context.Transactions.AddAsync(transaction);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Payments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }

        public static int Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}
