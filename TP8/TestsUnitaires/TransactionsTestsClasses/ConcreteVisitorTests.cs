using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires.TransactionsTestsClasses
{
    public class ConcreteVisitorTests
    {

        private readonly StudentOfficeBuilder builder;
        private readonly BestProductVisitor visitor;

        public ConcreteVisitorTests()
        {
            builder = new StudentOfficeBuilder();
            visitor = new BestProductVisitor();
        }

        [Fact]
        public void VisitTest()
        {
            visitor.visitTransaction(new Transaction(ProductGenerator.chips, 15, builder.john));

            Assert.Single(visitor.ProductTransactions);
        }

        [Fact]
        public void AddingRightPrice()
        {
            visitor.visitTransaction(new Transaction(ProductGenerator.chips, 10, builder.john));

            Assert.Equal(15, visitor.ProductTransactions[ProductGenerator.chips]);
        }

        [Fact]
        public void AddingPriceToExisitingProduct()
        {
            visitor.visitTransaction(new Transaction(ProductGenerator.chips, 10, builder.john));
            visitor.visitTransaction(new Transaction(ProductGenerator.chips, 10, builder.john));

            Assert.Equal(30, visitor.ProductTransactions[ProductGenerator.chips]);
        }

        [Fact]
        public void GetTheBestProduct()
        {
            visitor.visitTransaction(new Transaction(ProductGenerator.chips, 10, builder.john));
            visitor.visitTransaction(new Transaction(ProductGenerator.water, 10, builder.john));

            ISellable product = visitor.GetBestproduct();

            Assert.Equal(1.0m, product.BuyPrice);
        }
    }
}
