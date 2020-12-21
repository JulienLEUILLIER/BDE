using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class StudentOfficeTests
    {
        private readonly StudentOffice sut;
        private readonly Client john = Clients.John();
        private readonly Client jane = Clients.Jane();

        public StudentOfficeTests()
        {
            sut = new StudentOffice();
        }
        [Fact]
        public void TestFormatName()
        {
            Assert.Equal("DOE John", john.GetName());
        }

        [Fact]
        public void GetRightClient()
        {
            sut._ClientList.Add(john, 5);

            Assert.True(sut.GetClientByName(john.GetName()));
        }
        [Fact]
        public void AddingSingleStudentTest()
        {
            sut.AddClient(john, 5m);

            Assert.Single(sut._ClientList);
        }
        [Fact]
        public void AddingOtherClientTest()
        {
            sut.AddClient(jane, 5m);

            Assert.Single(sut._ClientList);
        }
        [Fact]
        public void ClientTypeTest()
        {
            Client pierre = Clients.CreateClient("dupont", "pierre", 25, 2006);
            Client jean = Clients.CreateClient("moulin", "jean", 42);

            sut.AddClient(pierre, 5m);
            sut.AddClient(jean, 7m);

            Assert.True(sut.GetClientByName(pierre.GetName()));
            Assert.True(sut.GetClientByName(jean.GetName()));
            Assert.IsType<Student>(pierre);
            Assert.IsType<OtherClient>(jean);
        }
    }
}
