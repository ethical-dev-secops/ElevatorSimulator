﻿using ElevatorSimulator.Domain.Enums;
using ElevatorSimulator.Domain.WorldMechanics;
using System.Drawing;

namespace ElevatorSimulator.Domain.DomainModels
{
    public class Elevator : DrawableObject
    {
        #region Properties

        public Guid ID { get; set; }
        public List<Person> People { get; set; }
        /// <summary>
        /// Colour of sprite.
        /// </summary>

        public int MaxWeightOccupancy { get; set; }

        /// <summary>
        /// Where the elevator is currently at.
        /// </summary>
        public int CurrentFloorNumber { get; set; }
        /// <summary>
        /// Where the elevator is headed too.
        /// </summary>
        public int CurrentDestinationFloor { get; set; }
        /// <summary>
        /// All the destinations that users have put in.
        /// </summary>
        public List<int> Destinations { get; set; }

        /// <summary>
        /// Up or Down
        /// </summary>
        public Direction Direction { get; set; }

        #endregion

        #region Constructor

        public Elevator()
        {
            People = new List<Person>();
            Destinations = new List<int>();
            ID = Guid.NewGuid();

            MaxWeightOccupancy = 1200;
            Direction = Direction.None;
        }

        #endregion

        #region Methods

        public void AddPerson(Person person)
        {
            People.Add(person);
        }

        public void RemovePerson(Person person)
        {
            People.Remove(person);
        }

        public void AddDestination(int floorNumber)
        {
            Destinations.Add(floorNumber);
        }

        public List<Person> PeopleGettingOutAtThisFloor()
        {
            var peopleLeavingElevator = People.Where(x => x.HeadingToFloorNumber == CurrentFloorNumber);

            People.RemoveAll(X => peopleLeavingElevator.Any(y => y.ID == X.ID));

            return peopleLeavingElevator.ToList();
        }

        public void UpdateCurrentDestination()
        {
            if (CurrentDestinationFloor == Destinations.Max())
            {
                CurrentDestinationFloor = Destinations.Min();
            }
            else if (CurrentDestinationFloor == Destinations.Min())
            {
                CurrentDestinationFloor = Destinations.Max();
            }
            
            Destinations.Remove(CurrentDestinationFloor);
        }

        public double GetCurrentWeight()
        {
            var weight = People.Sum(x => x.Weight);

            return weight;
        }

        #endregion
    }
}