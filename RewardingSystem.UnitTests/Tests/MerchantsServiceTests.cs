using NUnit.Framework;
using RewardingSystem.Application;
using Moq;
using System.Collections.Generic;
using RewardingSystem.Models;

namespace Tests
{
    public class MerchantsServiceTest
    {
        MerchantsService Service;
        Mock<IUnitOfWork> UOW = new Mock<IUnitOfWork>();
        Mock<IMerchantsRepository> MerchantsRepo = new Mock<IMerchantsRepository>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_NonEmptyRepository()
        {
            List<Merchant> list = new List<Merchant>() {
                new Merchant(){Id = 1, Name = "Test Merchant 1"},
                new Merchant(){Id = 2,Name = "Test Merchant 2"},
                new Merchant(){Id = 3,Name = "Test Merchant 3"}
            };
            TestUsingList(list);
        }

        [Test]
        public void GetAll_EmptyRepository()
        {
            TestUsingList(new List<Merchant>() { });
        }



        private void TestUsingList(List<Merchant> merchants)
        {
            //Arrange
            MerchantsRepo.Setup(r => r.GetAll()).Returns(merchants);
            UOW.Setup(p => p.Merchants).Returns(MerchantsRepo.Object);
            this.Service = new MerchantsService(UOW.Object);

            //Act
            var result = this.Service.GetAll();

            //Assert
            Assert.That(result.Count == merchants.Count);
        }
    }
}