﻿using ElevatorSimulator.Domain.WorldMechanics;

namespace ElevatorSimulator.Domain.DomainModels
{
    public class Person : DrawableObject
    {
        #region Properties

        public Guid ID { get; set; }
        public double Weight { get; set; }
        public int HeadingToFloorNumber { get; set; }
        public int CurrentFloorNumber { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Randomly generates stats for a Person
        /// </summary>
        /// <param name="floorNumber">Current floor number to spawn on</param>
        public Person(int floorNumber)
        {
            ID = Guid.NewGuid();

            var numberGenerator = new Random();

            HeadingToFloorNumber = numberGenerator.Next(1, 9);
            Weight = numberGenerator.Next(20, 120);
            CurrentFloorNumber = floorNumber;
        }

        #endregion
    }
}