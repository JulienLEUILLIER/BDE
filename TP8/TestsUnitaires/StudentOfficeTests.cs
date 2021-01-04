using TestsUnitaires.DataGenerator;
using TP8;
using Xunit;

namespace TestsUnitaires
{
    public class StudentOfficeTests
    {
        private readonly StudentOfficeBuilder builder;
        private readonly StudentOffice SUT;
        private readonly Client john, jane;

        public StudentOfficeTests()
        {
            builder = new StudentOfficeBuilder();
            SUT = builder.office;
            john = builder.john; jane = builder.jane;
        }

        [Fact]
        public void GetRightClient()
        {
            // Testing if the client exists in the client list of the student office
            Assert.True(SUT.GetClientByName(john.GetName()));
        }
        [Fact]
        public void AddingSingleStudentTest()
        {
            // Testing adding a single client of type Student to an empty student office
            StudentOffice instantTest = new StudentOffice(0);
            instantTest.AddClient(jane,0);
            Assert.Single(instantTest.ClientList);
        }
        [Fact]
        public void AddingOtherClientTest()
        {
            // Testing adding a single client of type OtherClient to an empty student office
            StudentOffice instantTest = new StudentOffice(0);
            instantTest.AddClient(john, 0);
            Assert.Single(instantTest.ClientList);
        }
        [Fact]
        public void ClientTypeTest()
        {
            // Testing if creation of clients gets back the right type of client
            Client pierre = SUT.CreateClient("dupont", "pierre", 25, 2006);
            Client jean = SUT.CreateClient("moulin", "jean", 42);

            Assert.IsType<Student>(pierre);
            Assert.IsType<OtherClient>(jean);
        }
    }
}
