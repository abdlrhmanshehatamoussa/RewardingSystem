using NUnit.Framework;
using RewardingSystem.Application;
using System.Collections.Generic;
using RewardingSystem.Models;

namespace Tests
{

    public class VouchersServiceTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(0, 0), TestCase(100, 1), TestCase(200, 2), TestCase(300, 3)]
        public void GetForUser_ValidId(int amount, int expected)
        {
            //Arrange
            UnitOfWorkMock uow = new UnitOfWorkMock();
            VouchersService service = new VouchersService(uow);

            //Act
            uow.Transactions.Add(new Transaction()
            {
                Amount = amount,
                UserId = UsersMockRepo.User1.Id,
            });
            List<VoucherSummary> results = service.GetForUser(UsersMockRepo.User1.Id);

            //Assert
            Assert.That(results.Count, Is.EqualTo(expected));
        }
    }
}