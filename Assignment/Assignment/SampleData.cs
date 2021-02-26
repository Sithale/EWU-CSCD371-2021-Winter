using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        public const int FirstNameColumn = 1;
        public const int LastNameColumn = 2;
        public const int EmailColumn = 3;
        public const int StreetAddressColumn = 4;
        public const int CityColumn = 5;
        public const int StateColumn = 6;
        public const int ZipColumn = 7;

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(row => row.Split(",")[6]).OrderBy(State => State).Distinct();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People => CsvRows.OrderBy(streetAddress => streetAddress).Select(row => row.Split(","))
            .OrderBy(state => state[StateColumn]).ThenBy(city => city[CityColumn]).ThenBy(zip => zip[ZipColumn])
                .Select(person => new Person(person[FirstNameColumn], person[LastNameColumn],
                    new Address(person[StreetAddressColumn], person[CityColumn], person[StateColumn], person[ZipColumn]), person[EmailColumn]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) 
            => People.Where(email => filter(email.EmailAddress)).Select(email => (email.FirstName, email.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
            => people.Select(person => person.Address.State).Distinct().Aggregate((state, person) => state + ", " + person);
    }
}
