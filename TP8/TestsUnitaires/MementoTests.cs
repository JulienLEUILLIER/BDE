using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class MementoTests
    {
        internal BackupBDE backup = new BackupBDE();
        internal StudentOfficeBuilder builder = new StudentOfficeBuilder();
        internal StudentOffice office;

        public MementoTests()
        {
            office = builder.office;
            builder.office.TransactionsList.Add(new Transaction(ProductGenerator.chips, 5, Clients.John()));
        }

        [Fact]
        public void SaveMementoTest()
        {          
            backup.Memento = builder.office.SaveState();
            var memento = backup.Memento;

            Assert.NotEmpty(memento.GetClientsSnapshot());
            Assert.NotEmpty(memento.GetTransactionsSnapshot());
            Assert.NotNull(memento.GetStockSnapshot());
        }

        [Fact]
        public void RestoreMementoTest()
        {
            backup.Memento = office.SaveState();
            var memento = backup.Memento;
            office.TransactionsList.Add(new Transaction(ProductGenerator.water, 10, Clients.Jane()));

            office.RestoreState(backup.Memento);

            Assert.Single(memento.GetTransactionsSnapshot());
        }
    }
}
