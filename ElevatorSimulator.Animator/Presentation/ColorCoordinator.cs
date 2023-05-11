using ElevatorSimulator.Domain.DomainModels;
using ElevatorSimulator.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Animator.Presentation
{
    /// <summary>
    /// Chooses the colours for the characters.
    /// </summary>
    public class ColorCoordinator
    {
        public CanvasMap GetColor(Elevator elevator)
        {
            var weight = elevator.GetCurrentWeight();
            var weightCapacityRatio = weight / elevator.MaxWeightOccupancy;
            var amountOfPeople = elevator.People.Count();

            if (weightCapacityRatio > 0.7)
            {
                return new CanvasMap() { Color = ConsoleColor.Red, Value = amountOfPeople };
            } 
            else if (weightCapacityRatio > 0.5)
            {
                return new CanvasMap() { Color = ConsoleColor.Blue, Value = amountOfPeople };
            }
            else if (weightCapacityRatio > 0.2)
            {
                return new CanvasMap() { Color = ConsoleColor.Green, Value = amountOfPeople };
            }
            return new CanvasMap() { Color = ConsoleColor.White, Value = amountOfPeople };
        }

        public ConsoleColor GetColor(Person person)
        {
            return ConsoleColor.Yellow;
        }

        public CanvasMap GetColor(Request request)
        {
            return new CanvasMap() { Color = ConsoleColor.DarkGreen};
        }

        public CanvasMap GetColor(Cursor cursor)
        {
            if (cursor.CursorState == CursorState.Active)
            {
                return new CanvasMap() { Color = ConsoleColor.Cyan};
            }
            if (cursor.CursorState == CursorState.Inactive)
            {
                return new CanvasMap() { Color = ConsoleColor.DarkCyan};
            }

            return new CanvasMap() { Color = ConsoleColor.DarkCyan};
        }
    }
}
