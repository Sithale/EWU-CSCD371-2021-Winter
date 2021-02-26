using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        public const int FirstNameColumn = 1;
        public const int LastNameColumn = 2;
        public const int EmailColumn = 3;
        public const int StreetAddressColumn = 4;
        public const int CityColumn = 5;
        public const int StateColumn = 6;
        public const int ZipColumn = 7;

        [TestMethod]
        public void CsvRows_IterateThroughRows_CorrectNumberOfRows()
        {
            // Arrange
            SampleData data = new SampleData();
            int rowNum = data.CsvRows.Count();

            // Assert
            Assert.AreEqual<int>(50, rowNum);

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SortTheListOfRows_ListIsProperlyOrderedAndUnique()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            IEnumerable<string> rows = data.GetUniqueSortedListOfStatesGivenCsvRows();
            bool res1 = rows.SequenceEqual(rows.OrderBy(row => row));
            bool res2 = rows.SequenceEqual(rows.OrderBy(row => row).Distinct());

            // Assert
            Assert.IsTrue(res1);
            Assert.IsTrue(res2);
        }

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_CompareStateStrings_ReturnsCorrectArrayOfStates()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            IEnumerable<string> stateList = data.GetUniqueSortedListOfStatesGivenCsvRows();
            string[] stateArray = stateList.ToArray<string>();
            string correctState = String.Join(", ", stateArray);
            string state = data.GetAggregateSortedListOfStatesUsingCsvRows();

            // Assert
            Assert.AreEqual(correctState, state);
        }

        [TestMethod]
        public void People_CreatePeopleFromList_OutputMatchesExpectedResult()
        {
            // Arrange
            SampleData data = new();
            IEnumerable<IPerson> people = data.People;

            // Act
            IEnumerable<IPerson> correctPeople = data.CsvRows.OrderBy(streetAddress => streetAddress).Select(rows => rows.Split(","))
                .OrderBy(state => state[StateColumn]).ThenBy(city => city[CityColumn]).ThenBy(zip => zip[ZipColumn])
                    .Select(person => new Person(person[FirstNameColumn], person[LastNameColumn],new Address(person[StreetAddressColumn],
                        person[CityColumn], person[StateColumn], person[ZipColumn]), person[EmailColumn]));

            IEnumerable<(IPerson, IPerson)> correctZip = people.Zip(correctPeople);

            // Assert
            Assert.IsTrue(correctZip.All(person => (person.Item1.EmailAddress == person.Item2.EmailAddress)));
            Assert.IsTrue(correctZip.All(person => (person.Item1.EmailAddress == person.Item2.EmailAddress)));
            Assert.IsTrue(correctZip.All(person => (person.Item1.EmailAddress == person.Item2.EmailAddress)));

        }

        [TestMethod]
        public void FilterByEmailAddress_SearchForFirstAndLastNamesGivenAnEmail_FilterSucceeds()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            IEnumerable<(string, string)> actual = data.FilterByEmailAddress(item => item.Contains("edu"));

            // Assert
            Assert.IsTrue(actual.Any(item => item.Item1 == "Sancho"));
            Assert.IsTrue(actual.Any(item => item.Item2 == "Leathe"));

            Assert.IsFalse(actual.Any(item => item.Item2 == "Mesnard"));
            Assert.IsFalse(actual.Any(item => item.Item1 == "Molly"));
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivnePeopleCollection_ComparesTwoStrings_ReturnsCorrectString()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            string states = data.GetAggregateSortedListOfStatesUsingCsvRows();
            string correctStates = data.GetAggregateListOfStatesGivenPeopleCollection(data.People);

            // Assert
            Assert.AreEqual<string>(correctStates, states);
        }
    }
}
