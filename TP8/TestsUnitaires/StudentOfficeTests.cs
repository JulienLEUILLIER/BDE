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
            // Testing formatting name
            Assert.Equal("DOE John", john.GetName());
        }

        [Fact]
        public void GetRightClient()
        {
            // Testing if the client exists in the client list of the student office
            Assert.True(office.GetClientByName(john.GetName()));
        }
        [Fact]
        public void AddingSingleStudentTest()
        {
            // Testing adding a single client of type Student to an empty student office
            StudentOffice instantTest = new StudentOffice(0);
            instantTest.AddClient(jane,0);
            Assert.Single(instantTest._ClientList);
        }
        [Fact]
        public void AddingOtherClientTest()
        {
            // Testing adding a single client of type OtherClient to an empty student office
            StudentOffice instantTest = new StudentOffice(0);
            instantTest.AddClient(john, 0);
            Assert.Single(instantTest._ClientList);
        }
        [Fact]
        public void ClientTypeTest()
        {
            // Testing if creation of clients gets back the right type of client
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
