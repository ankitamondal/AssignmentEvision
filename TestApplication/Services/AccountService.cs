using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Contracts;
using TestApplication.Model;

namespace TestApplication.Services
{
    public class AccountService : IAccountService
    {
        public double GetAccountAmount(int accountId)
        {
           
            return 16.6;
        }

        public async Task<double> GetAccountAmountAsync(int accountId)
        {
            return 16.6;
        }
    }
}
