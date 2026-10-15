using ChainOfResp.Web_.Models;

namespace ChainOfResp.Web_.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee? NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            NextApprover = supervisor;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel request);
    }
}