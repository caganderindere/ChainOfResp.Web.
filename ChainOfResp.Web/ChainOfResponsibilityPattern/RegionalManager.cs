using ChainofResp.Web.DataAccess;
using ChainOfResp.Web_.ChainOfResponsibilityPattern;
using ChainOfResp.Web_.Entitys;
using ChainOfResp.Web_.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class RegionalManager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 1000000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Bölge Müdürü - Çağan Derindere",
                    Description = "Para Çekme İşlemi Onaylandı. Müşteriye tutar ödendi."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmpLoyeeName = "Bölge Müdürü - Çağan Derindere",
                    Description = "Para çekme tutarı bölge müdürünün yetkisini aştığı için işlem onaylanamadı."
                };

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
}