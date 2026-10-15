using ChainofResp.Web.DataAccess;
using ChainOfResp.Web_.ChainOfResponsibilityPattern;
using ChainOfResp.Web_.Entitys;
using ChainOfResp.Web_.Models;

namespace ChainOfResp.Web.ChainOfResponsibilityPattern
{
    public class Manager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 500000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Şube Müdürü - Ahmet Yılmaz",
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
                    EmpLoyeeName = "Şube Müdürü - Ahmet Yılmaz",
                    Description = "Para çekme tutarı şube müdürünün ödeyebileceği miktarı aştığı için işlem bölge müdüre yönlendirildi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

                NextApprover.ProcessRequest(request);
            }
        }
    }
}