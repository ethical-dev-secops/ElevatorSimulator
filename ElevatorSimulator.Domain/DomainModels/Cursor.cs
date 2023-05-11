using ElevatorSimulator.Domain.Enums;

namespace ElevatorSimulator.Domain.DomainModels
{
    /// <summary>
    /// Represents the console cursor (where you can type).
    /// </summary>
    public class Cursor
    {
        #region Properties

        public int YIndex { get; set; }
        public int XIndex { get; set; }
        public int MaxYIndex { get; set; }
        public CursorState CursorState { get; set; }

        #endregion

        #region Constructor

        public Cursor(int MaxYIndex) 
        { 
            this.MaxYIndex = MaxYIndex;
        }

        #endregion
    }
}