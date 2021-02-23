using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_IterateThroughRows_CorrectNumberOfRows()
        {
            // Arrange
            SampleData data = new SampleData();
            int rowNum = 0;

            // Act
            foreach (string row in data.CsvRows)
                rowNum++;

            // Assert
            Assert.AreEqual<int>(50, rowNum);

        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SortTheListOfRows_ListIsProperlyOrdered()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            IEnumerable<string> rows = data.GetUniqueSortedListOfStatesGivenCsvRows();
            bool res = rows.SequenceEqual(rows.OrderBy(row => row));
            
            // Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_SortTheListOfRows_ReturnsUniqueRows()
        {
            // Arrange
            SampleData data = new SampleData();

            // Act
            IEnumerable<string> rows = data.GetUniqueSortedListOfStatesGivenCsvRows();
            bool res = rows.SequenceEqual(rows.OrderBy(row => row).Distinct());

            // Assert
            Assert.IsTrue(res);
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
            IEnumerable<IPerson> correctPeople = data.CsvRows.OrderBy(StreetAddress => StreetAddress).Select(rows => rows.Split(","))
                .OrderBy(State => State[6]).ThenBy(City => City[5]).ThenBy(Zip => Zip[7])
                    .Select(person => new Person(person[1], person[2], new Address(person[4], person[5], person[6], person[7]), person[3]));

            IEnumerable<(IPerson, IPerson)> correctZip = people.Zip(correctPeople);

            // Assert
            Assert.IsTrue(correctZip.All(person => (person.Item1.FirstName == person.Item2.FirstName)));
            Assert.IsTrue(correctZip.All(person => (person.Item1.LastName == person.Item2.LastName)));
            Assert.IsTrue(correctZip.All(person => (person.Item1.FirstName == person.Item2.FirstName)));

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
    }
}
