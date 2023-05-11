namespace ElevatorSimulator.Animator
{
    /// <summary>
    /// Class that carries the color mapping for the Console application
    /// </summary>
    public class CanvasMap
    {
        /// <summary>
        /// Represents the limited 8-bit color configuration
        /// </summary>
        public ConsoleColor Color { get; set; }
        
        /// <summary>
        /// Represents a generic placeholder value that can later be useful when rendering (ie: label)
        /// </summary>
        public double Value { get; set; }


        public CanvasMap()
        {
            Color = ConsoleColor.Black;
        }
    }
}