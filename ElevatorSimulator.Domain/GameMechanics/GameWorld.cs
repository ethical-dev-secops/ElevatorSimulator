using ElevatorSimulator.Domain.DomainModels;

namespace ElevatorSimulator.Domain.WorldMechanics
{
    /// <summary>
    /// Represents the in memory state of the simulation.
    /// </summary>
    public class GameWorld
    {
        #region Properties
        
        public List<Floor> Floors { get; set; }
        public List<Elevator> Elevators { get; set; }
        public List<Request> Requests { get; set; }
        public Cursor Cursor { get; set; }

        #endregion


        /// <summary>
        /// Generic constructor for starting the simulator.
        /// </summary>
        /// <param name="configuration"></param>
        #region Constructor
        public GameWorld(GameConfiguration configuration)
        {
            SetFloors(configuration);
            SetElevators(configuration);

            Requests = new List<Request>();
            Cursor = new Cursor(configuration.MaxHeight - 1);
        }

        /// <summary>
        /// Initializes the floors of the building.
        /// </summary>
        /// <param name="configuration"></param>
        private void SetFloors(GameConfiguration configuration)
        {
            Floors = new List<Floor>();
            for (var i = 0; i < configuration.NumberOfFloors; i++)
            {
                Floors.Add(new Floor());
            }
        }

        /// <summary>
        /// Initializes the elevators.
        /// </summary>
        /// <param name="configuration"></param>
        private void SetElevators(GameConfiguration configuration)
        {
            Elevators = new List<Elevator>();
            for (var i = 0; i < configuration.NumberOfElevators; i++)
            {
                if (i == 0)
                {
                    Elevators.Add(new Elevator() { XPosition = GameConfiguration.Elevator1XIndex });
                }
                else if (i == 1)
                {
                    Elevators.Add(new Elevator() { XPosition = GameConfiguration.Elevator2XIndex });
                }
            }
        }

        #endregion
    }
}