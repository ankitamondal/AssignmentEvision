using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestApplication.Contracts;
using System.Collections.Generic;
using TestApplication.Model;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Tests
{
    [TestClass]
    public class AccountInfoTest
    {
        [TestMethod]
        public void RefreshAmountTest()
        {
            List<AccountInfoModel> accounts = new List<AccountInfoModel>
            {
                new AccountInfoModel
                {
                    accountId = 1,
                    Amount = 100.23
                },
                new AccountInfoModel
                {
                    accountId = 2,
                    Amount = 200.23
                },
                new AccountInfoModel
                {
                    accountId = 3,
                    Amount = 300.23
                },
                new AccountInfoModel
                {
                    accountId = 4,
                    Amount = 400.23
                },
                new AccountInfoModel
                {
                    accountId = 5,
                    Amount = 500.23
                }
            };
            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmount(
                    It.IsAny<int>()
                )).Returns((int i)=> accounts.Where(x=>x.accountId==i).SingleOrDefault().Amount);
            AccountInfo ai = new AccountInfo(2, mock.Object);
            ai.RefreshAmount();
            Assert.IsNotNull(ai.Amount);
            Assert.AreEqual(200.23, ai.Amount);
        }

        [TestMethod]
        public async Task RefreshAmountTestAsync()
        {
            List<AccountInfoModel> accounts = new List<AccountInfoModel>
            {
                new AccountInfoModel
                {
                    accountId = 1,
                    Amount = 100.23
                },
                new AccountInfoModel
                {
                    accountId = 2,
                    Amount = 200.23
                },
                new AccountInfoModel
                {
                    accountId = 3,
                    Amount = 300.23
                },
                new AccountInfoModel
                {
                    accountId = 4,
                    Amount = 400.23
                },
                new AccountInfoModel
                {
                    accountId = 5,
                    Amount = 500.23
                }
            };
            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmountAsync(
                    It.IsAny<int>()
                )).Returns(
                (int i) =>
                Task.FromResult(accounts.Where(x => x.accountId == i).SingleOrDefault().Amount
                ));

            AccountInfo ai = new AccountInfo(2, mock.Object);
            double amount=await ai.RefreshAmountAsync();
            Assert.IsNotNull(amount);
            Assert.AreEqual(200.23, amount);
        }


    }
}
