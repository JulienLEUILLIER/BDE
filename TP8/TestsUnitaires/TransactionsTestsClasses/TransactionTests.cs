using NSubstitute;
using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires.TransactionsTestsClasses
{
    public class TransactionTests
    {
        private readonly StudentOffice office;
        private readonly Client john;

        public TransactionTests()
        {
            office = new StudentOffice(new StubStock());
            john = Clients.John();
            office.AddClient(john, 15);
        }

        [Fact]
        public void AddingTransactions()
        {            
            office.SellProduct(john, new Order(ProductGenerator.chips, 5));

            Assert.Single(office.TransactionsList);
        }

        [Fact]
        public void AcceptingVisitor()
        {
            office.SellProduct(john, new Order(ProductGenerator.chips, 5));
            BestProductVisitor visitor = (BestProductVisitor)office.CreateVisitorProduct();

            Assert.Single(visitor.ProductTransactions);
        }

    }
}
