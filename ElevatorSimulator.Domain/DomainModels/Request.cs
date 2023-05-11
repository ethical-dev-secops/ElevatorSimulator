using ElevatorSimulator.Domain.WorldMechanics;

namespace ElevatorSimulator.Domain.DomainModels
{
    public class Request : DrawableObject
    {
        public int CurrentFloorNumber { get; set; }
        public bool IsEnabled { get; set; }

        public int CountdownTimer { get; set; }

        #region Constructor

        public Request()
        {
            IsEnabled = false;
        }

        #endregion
    }
}