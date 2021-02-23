using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines("People.csv").Skip(1);


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(row => row.Split(",")[6]).OrderBy(State => State).Distinct();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

        // 4.
        public IEnumerable<IPerson> People => CsvRows.OrderBy(StreetAddress => StreetAddress).Select(row => row.Split(","))
            .OrderBy(State => State[6]).ThenBy(City => City[5]).ThenBy(Zip => Zip[7])
                .Select(person => new Person(person[1], person[2], new Address(person[4],person[5],person[6],person[7]), person[3]));

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) 
            => People.Where(email => filter(email.EmailAddress)).Select(email => (email.FirstName, email.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
            => people.Select(person => person.Address.State).Aggregate((State, person) => State + ", " + person);
    }
}
