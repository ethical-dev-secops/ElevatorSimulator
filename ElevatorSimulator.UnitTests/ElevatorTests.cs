using ElevatorSimulator.Domain.DomainModels;
using ElevatorSimulator.Domain.Utils;

namespace ElevatorSimulator.UnitTests
{
    /// <summary>
    /// Unit Tests only applicable to the elevator.
    /// </summary>
    public class ElevatorTests
    {
        /// <summary>
        /// Checks if the elevator has more people than it can handle.
        /// </summary>
        [Fact]
        public void ElevatorIsOverMaximumWeightCapacity()
        {
            var random = new Random();
            var elevator = new Elevator();

            while(elevator.People.Sum(x=>x.Weight) < elevator.MaxWeightOccupancy)
            {
                elevator.People.Add(new Person(random.Next(0,10)));
            }

            Assert.True(GameWorldUtilities.IsElevatorOverloaded(elevator),"Max Weight test is failing.");
        }

        /// <summary>
        /// Checks if the elevator can handle small loads of people.
        /// </summary>
        [Fact]
        public void ElevatorIsUnderMaximumWeightCapacity()
        {
            var random = new Random();
            var limitOfPeople = random.Next(0,3);
            var elevator = new Elevator();

            for(var i = 0; i < limitOfPeople; i++)
            {
                elevator.People.Add(new Person(random.Next(0, 10)));
            }

            Assert.False(GameWorldUtilities.IsElevatorOverloaded(elevator), "Viable Weight test is failing.");
        }
    }
}