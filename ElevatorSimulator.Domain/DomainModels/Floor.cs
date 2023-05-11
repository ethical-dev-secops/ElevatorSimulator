using ElevatorSimulator.Domain.WorldMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Domain.DomainModels
{
    public class Floor
    {

        #region Properties

        public int FloorNumber { get; set; }
        public List<Person> People { get; set; }

        #endregion


        public Floor() 
        { 
            People = new List<Person>();
        }

        #region Methods

        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        public void AddPeople(List<Person> people)
        {
            People.AddRange(people);
        }

        public void RemovePerson(Person person)
        {
            People.Remove(person);
        }

        #endregion
    }
}
