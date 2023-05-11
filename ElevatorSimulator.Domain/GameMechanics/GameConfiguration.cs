namespace ElevatorSimulator.Domain.WorldMechanics
{
    public class GameConfiguration
    {
        public int NumberOfFloors { get; set; }
        public int NumberOfElevators { get; set; }
        public int MaxHeight { get; set; }

        public const int Elevator1XIndex = 9;
        public const int Elevator2XIndex = 15;
    }
}