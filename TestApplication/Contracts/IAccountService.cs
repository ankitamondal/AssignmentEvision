using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Contracts
{
    public interface IAccountService
    {
        double GetAccountAmount(int accountId);
        Task<double> GetAccountAmountAsync(int accountId);
    }
}
