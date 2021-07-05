using NUnit.Framework;
using RewardingSystem.Application;
using Moq;
using System.Collections.Generic;
using RewardingSystem.Models;

namespace Tests
{
    public class TransactionsServiceTest
    {
        TransactionsService Service;
        Mock<IUnitOfWork> UOW = new Mock<IUnitOfWork>();
        Mock<ITransactionsRepository> TransactionsRepo = new Mock<ITransactionsRepository>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPointsForUser_SingleUser()
        {
            List<Transaction> transactions = new List<Transaction>() {
                new Transaction(){
                    Amount = 20
                },
                new Transaction(){
                    Amount = 40
                },
                new Transaction(){
                    Amount = 50
                }
            };
            GetPointsForUser(transactions, 110);
        }

        [Test]
        public void GetPointsForUser_EmptyList()
        {
            GetPointsForUser(new List<Transaction>(), 0);
        }

        private void GetPointsForUser(List<Transaction> transactions, int expected)
        {
            //Arrange
            int userId = 1;
            this.TransactionsRepo.Setup(t => t.Get(userId)).Returns(transactions);
            this.UOW.Setup(u => u.Transactions).Returns(this.TransactionsRepo.Object);
            this.Service = new TransactionsService(UOW.Object);

            //Act
            int points = this.Service.GetPointsForUser(userId);

            //Assert
            Assert.That(points == expected);
        }
    }
}