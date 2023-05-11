namespace ElevatorSimulator.Domain.WorldMechanics
{
    /// <summary>
    /// Basic class every game object inherits from
    /// </summary>
    public class DrawableObject
    {
        /// <summary>
        /// X Co-ordinate
        /// </summary>
        public int XPosition;
        /// <summary>
        /// Y Co-ordinate
        /// </summary>
        public int YPosition;
        /// <summary>
        /// Width of sprite
        /// </summary>
        public int Width;
        /// <summary>
        /// Height of sprite
        /// </summary>
        public int Height;
    }
}