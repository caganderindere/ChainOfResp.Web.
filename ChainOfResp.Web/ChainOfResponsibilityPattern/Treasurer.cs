using ChainofResp.Web.DataAccess;
using ChainOfResp.Web_.Models;
using ChainOfResp.Web_.Entitys;

namespace ChainOfResp.Web_.ChainOfResponsibilityPattern
{
    public class Treasurer(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount < 50001)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Veznedar - Barış Bingöl",
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
                    EmpLoyeeName = "Veznedar - Barış Bingöl",
                    Description = "Para çekme tutarı veznedarın ödeyebileceği miktarı aştığı için işlem müdür yardımcısına yönlendirildi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

                NextApprover.ProcessRequest(request);
            }
        }
    }
}