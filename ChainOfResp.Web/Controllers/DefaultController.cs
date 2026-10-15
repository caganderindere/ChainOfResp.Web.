using ChainofResp.Web.ChainOfResponsibilityPattern;
using ChainOfResp.Web.ChainOfResponsibilityPattern;
using ChainOfResp.Web_.ChainOfResponsibilityPattern;
using ChainOfResp.Web_.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResp.Web_.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Treasurer _treasurer;
        private readonly AssistantManager _assistantManager;
        private readonly Manager _manager;
        private readonly RegionalManager _regionalManager;

        public DefaultController(
            Treasurer treasurer,
            AssistantManager assistantManager,
            Manager manager,
            RegionalManager regionalManager)
        {
            _treasurer = treasurer;
            _assistantManager = assistantManager;
            _manager = manager;
            _regionalManager = regionalManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel request)
        {
            // Chain oluşturuluyor
            _treasurer.SetNextApprover(_assistantManager);
            _assistantManager.SetNextApprover(_manager);
            _manager.SetNextApprover(_regionalManager);

            // İstek zincirin ilk elemanına gönderiliyor
            _treasurer.ProcessRequest(request);

            if (request.Amount <= 1000000)
            {
                TempData["Message"] = "Para çekme işlemi onaylandı. Müşteriye tutar ödendi.";
            }
            else
            {
                TempData["Message"] = "Para çekme işlemi onaylanamadı. Tutar yetki sınırını aşıyor.";
            }

            return RedirectToAction("Index");
        }
    }
}