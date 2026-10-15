using ChainofResp.Web.DataAccess;
using ChainOfResp.Web_.ChainOfResponsibilityPattern;
using ChainOfResp.Web_.Entitys;
using ChainOfResp.Web_.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class AssistantManager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 200000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Şube Müdür Yardımcısı - Elifnaz Demir",
                    Description = "Para Çekme İşlemi Onaylandı. Müşteriye tutar ödendi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover is not null)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Şube Müdür Yardımcısı - Elifnaz Demir",
                    Description = "Para çekme tutarı şube müdür yardımcısının ödeyebileceği miktarı aştığı için işlem şube müdürüne yönlendirildi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

                NextApprover.ProcessRequest(request);
            }
        }
    }
}