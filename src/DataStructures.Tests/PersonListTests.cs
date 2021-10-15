using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace DataStructures.Tests
{
    [TestClass]
    public class PersonListTests
    {
        [TestMethod]
        public void Constructor_creates_empty_list()
        {
            // Arrange / Act
            var list = new PersonList();

            // Assert
            list.IsEmpty().Should().BeTrue();
            list.Count().Should().Be(0);
        }

        [TestMethod]
        public void Add_should_add_person_to_end_of_list_for_first_person()
        {
            // Arrange
            var list = new PersonList();
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            list.IsEmpty().Should().BeTrue();

            // Act
            var addedElement = list.Add(person);

            // Assert
            addedElement.Should().NotBeNull();
            addedElement.NextElement.Should().BeNull();
            list.IsEmpty().Should().BeFalse();
            list.Count().Should().Be(1);
        }


        [TestMethod]
        public void FunctionUnderTest_ExpectedResult_UnderCondition()
        {
            // Arrange


            // Act


            // Assert

        }
    }
}
