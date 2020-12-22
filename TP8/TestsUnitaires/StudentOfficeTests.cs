using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class StudentOfficeTests
    {
        private readonly StudentOfficeBuilder sut;
        private readonly StudentOffice office;
        private readonly Client john, jane;

        public StudentOfficeTests()
        {
            sut = new StudentOfficeBuilder();
            office = sut.office;
            john = sut.john; jane = sut.jane;
        }
        [Fact]
        public void TestFormatName()
        {
            Assert.Equal("DOE John", john.GetName());
        }

        [Fact]
        public void GetRightClient()
        {
            sut.office._ClientList.Add(john, 5);

            Assert.True(office.GetClientByName(john.GetName()));
        }
        [Fact]
        public void AddingSingleStudentTest()
        {
            office.AddClient(john, 5m);

            Assert.Single(office._ClientList);
        }
        [Fact]
        public void AddingOtherClientTest()
        {
            office.AddClient(jane, 5m);

            Assert.Single(office._ClientList);
        }
        [Fact]
        public void ClientTypeTest()
        {
            Client pierre = Clients.CreateClient("dupont", "pierre", 25, 2006);
            Client jean = Clients.CreateClient("moulin", "jean", 42);

            office.AddClient(pierre, 5m);
            office.AddClient(jean, 7m);

            Assert.True(office.GetClientByName(pierre.GetName()));
            Assert.True(office.GetClientByName(jean.GetName()));
            Assert.IsType<Student>(pierre);
            Assert.IsType<OtherClient>(jean);
        }
    }
}
