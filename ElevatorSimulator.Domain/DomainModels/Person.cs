using ElevatorSimulator.Domain.WorldMechanics;

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

        public Person()
        {
            ID = Guid.NewGuid();
            var numberGenerator = new Random();

            HeadingToFloorNumber = numberGenerator.Next(1, 9);
        }

        #endregion
    }
}