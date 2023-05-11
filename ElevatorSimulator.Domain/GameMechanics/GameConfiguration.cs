namespace ElevatorSimulator.Domain.WorldMechanics
{
    /// <summary>
    /// Basic configuration for the simulation
    /// </summary>
    /// <remarks>
    /// The elevator indexes are specific only to Console applications
    /// </remarks>
    public class GameConfiguration
    {
        #region Properties

        public int NumberOfFloors { get; set; }
        public int NumberOfElevators { get; set; }
        public int MaxHeight { get; set; }

        /// <summary>
        /// Helps with Console X-Axis for elevator shaft 1
        /// </summary>
        public const int Elevator1XIndex = 9;

        /// <summary>
        /// Helps with Console X-Axis for elevator shaft 2
        /// </summary>
        public const int Elevator2XIndex = 15;

        #endregion
    }
}