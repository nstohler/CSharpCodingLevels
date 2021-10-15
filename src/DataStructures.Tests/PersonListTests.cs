using System;
using System.Collections.Generic;
using System.Linq;
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

            // Act
            var addedElement = list.Add(person);
            
            // Assert
            addedElement.Should().NotBeNull();
            addedElement.NextElement.Should().BeNull();
            list.IsEmpty().Should().BeFalse();
            list.Count().Should().Be(1);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(111)]
        public void Count_should_return_correct_amount_of_persons_in_list(int expectedCount)
        {
            // Arrange
            var list = new PersonList();
            var existingPersons = GetRandomPersons(expectedCount);
            
            // Act
            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            // Assert
            list.IsEmpty().Should().Be(expectedCount == 0);
            list.Count().Should().Be(expectedCount);
        }

        [TestMethod]
        public void Add_should_add_person_to_end_of_list_when_persons_are_already_in_list()
        {
            // Arrange
            var list = new PersonList();
            var existingPersons = GetRandomPersons(3);
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            // Act
            var addedElement = list.Add(person);

            // Assert
            addedElement.Should().NotBeNull();
            addedElement.NextElement.Should().BeNull();
            list.IsEmpty().Should().BeFalse();
            list.Count().Should().Be(4);
        }

        [TestMethod]
        [DataRow(3, 3)]
        [DataRow(0, 3)]
        [DataRow(3, 0)]
        [DataRow(0, 0)]
        public void GetAt_should_return_correct_person(int firstPersonsToAdd, int lastPersonsToAdd)
        {
            // Arrange
            var firstPersons = GetRandomPersons(firstPersonsToAdd);
            var lastPersons = GetRandomPersons(lastPersonsToAdd);
            var list = new PersonList();
            var expectedPerson = new Person() { FirstName = "Hans", LastName = "Wurst", LuckyNumber = 7, ShoeSize = 42 };
            
            foreach (var f in firstPersons)
            {
                list.Add(f);
            }

            list.Add(expectedPerson);

            foreach (var l in lastPersons)
            {
                list.Add(l);
            }

            // Act
            var index = firstPersonsToAdd;
            var getPerson = list.GetAt(index);

            // Assert
            getPerson.Should().NotBeNull();
            getPerson.Should().BeSameAs(getPerson);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void InsertAt_should_add_person_at_correct_position(int insertIndex)
        {
            // Arrange
            var list = new PersonList();
            var existingPersons = GetRandomPersons(3);
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            // Act
            var insertedElement = list.InsertAt(insertIndex, person);

            // Assert
            list.Count().Should().Be(4);
            insertedElement.Should().NotBeNull();
            
            var getPerson = list.GetAt(insertIndex);
            getPerson.Should().NotBeNull();
            getPerson.Should().BeSameAs(insertedElement);
        }

        [TestMethod]
        public void InsertAt_at_zero_index_should_add_person_correctly()
        {
            // Arrange
            var insertIndex = 0;
            var list = new PersonList();
            var existingPersons = GetRandomPersons(5);
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            var originalFirstPerson = list.GetAt(insertIndex);
            originalFirstPerson.NextElement.Should().NotBeNull();

            // Act
            var insertedElement = list.InsertAt(insertIndex, person);

            // Assert
            list.Count().Should().Be(6);
            insertedElement.Should().NotBeNull();
            insertedElement.NextElement.Should().NotBeNull();
            
            var getPerson = list.GetAt(insertIndex);
            getPerson.Should().NotBeNull();
            getPerson.Should().BeSameAs(insertedElement);

            var secondPerson = list.GetAt(insertIndex + 1);
            secondPerson.Should().BeSameAs(originalFirstPerson);
            getPerson.NextElement.Should().BeSameAs(secondPerson);
        }

        [TestMethod]
        public void InsertAt_at_middle_index_should_add_person_correctly()
        {
            // Arrange
            var insertIndex = 2;
            var list = new PersonList();
            var existingPersons = GetRandomPersons(5);
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            var originalPreviousPerson = list.GetAt(insertIndex - 1);
            originalPreviousPerson.NextElement.Should().NotBeNull();

            var originalMiddlePerson = list.GetAt(insertIndex);
            originalMiddlePerson.NextElement.Should().NotBeNull();

            // Act
            var insertedElement = list.InsertAt(insertIndex, person);

            // Assert
            list.Count().Should().Be(6);
            insertedElement.Should().NotBeNull();
            insertedElement.NextElement.Should().NotBeNull();
            
            var getPerson = list.GetAt(insertIndex);
            getPerson.Should().NotBeNull();
            getPerson.Should().BeSameAs(insertedElement);

            var previousPerson = list.GetAt(insertIndex - 1);
            previousPerson.Should().NotBeNull();
            previousPerson.Should().BeSameAs(originalPreviousPerson);
            originalPreviousPerson.NextElement.Should().BeSameAs(getPerson);

            var nextPerson = list.GetAt(insertIndex + 1);
            nextPerson.Should().BeSameAs(originalMiddlePerson);
            getPerson.NextElement.Should().BeSameAs(nextPerson);
        }

        [TestMethod]
        public void InsertAt_at_last_valid_index_should_add_person_before_last_existing_person()
        {
            // Arrange
            var insertIndex = 4;
            var list = new PersonList();
            var existingPersons = GetRandomPersons(5);
            var person = new Person() { FirstName = "Hans", LastName = "Wurst" };

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            var originalLastPerson = list.GetAt(insertIndex);
            originalLastPerson.NextElement.Should().BeNull();

            // Act
            var insertedElement = list.InsertAt(insertIndex, person);

            // Assert
            list.Count().Should().Be(6);
            insertedElement.Should().NotBeNull();
            insertedElement.NextElement.Should().NotBeNull();
            
            var getPerson = list.GetAt(insertIndex);
            getPerson.Should().NotBeNull();
            getPerson.Should().BeSameAs(insertedElement);

            var lastPerson = list.GetAt(insertIndex + 1);
            lastPerson.Should().BeSameAs(originalLastPerson);
            lastPerson.NextElement.Should().BeNull();
            getPerson.NextElement.Should().BeSameAs(lastPerson);
        }


        [TestMethod]
        [DataRow(-1)]
        [DataRow(5)]
        [DataRow(555)]
        public void InsertAt_should_throw_IndexOutOfRangeException_for_invalid_indexes(int index)
        {
            // Arrange
            var list = new PersonList();
            var existingPersons = GetRandomPersons(5);

            foreach (var existingPerson in existingPersons)
            {
                list.Add(existingPerson);
            }

            // Act
            Action act = () => list.InsertAt(index, GetRandomPerson());

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Invalid index*");
            list.Count().Should().Be(5);
        }

        private Person GetRandomPerson(int number = 7)
        {
            return new Person()
            {
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                LuckyNumber = number,
            };
        }

        private List<Person> GetRandomPersons(int count)
        {
            return Enumerable
                .Range(0, count)
                .Select(x => GetRandomPerson(x))
                .ToList();
        }
    }
}
