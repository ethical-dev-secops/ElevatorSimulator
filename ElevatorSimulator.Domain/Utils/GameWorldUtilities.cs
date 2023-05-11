using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorSimulator.Domain.DomainModels;
using ElevatorSimulator.Domain.Enums;
using ElevatorSimulator.Domain.WorldMechanics;

namespace ElevatorSimulator.Domain.Utils
{
    internal class GameWorldUtilities
    {
        /// <summary>
        /// Loads people into and out of the elevators.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        public static GameWorld MovePeople(GameWorld gameWorld)
        {
            foreach (var lift in gameWorld.Elevators)
            {
                var peopleGettingOut = lift.PeopleGettingOutAtThisFloor();

                gameWorld.Floors[lift.CurrentFloorNumber].AddPeople(peopleGettingOut);
            }

            return gameWorld;
        }

        /// <summary>
        /// Changes the floor position of the elevator.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        public static GameWorld MoveElevators(GameWorld gameWorld)
        {
            for (var i = 0; i < gameWorld.Elevators.Count(); i++)
            {
                if (gameWorld.Elevators[i].Direction == Direction.Up)
                {
                    gameWorld.Elevators[i].CurrentFloorNumber++;
                }
                else if (gameWorld.Elevators[i].Direction == Direction.Down)
                {
                    gameWorld.Elevators[i].CurrentFloorNumber--;
                }
            }

            return gameWorld;
        }

        /// <summary>
        /// Makes an elevator move to a floor.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static GameWorld ProcessRequest(GameWorld gameWorld)
        {
            for (var i = 0; i < gameWorld.Requests.Count(); i++)
            {
                if (gameWorld.Requests[i].CountdownTimer > 0)
                {
                    gameWorld.Requests[i].CountdownTimer--;
                }

                if (gameWorld.Elevators.Any(x=>x.CurrentFloorNumber == gameWorld.Requests[i].YPosition))
                {
                    gameWorld.Requests[i].CountdownTimer = 3;
                }
            }

            return gameWorld;
        }

        /// <summary>
        /// Processes the cursor.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        public static GameWorld ProcessCursor(GameWorld gameWorld)
        {
            if (gameWorld.Cursor.CursorState == CursorState.CoolingDownT1)
            {
                gameWorld.Cursor.CursorState = CursorState.Inactive;
            }
            else
            {
                gameWorld.Cursor.CursorState++;
            }

            return gameWorld;
        }

        /// <summary>
        /// Deals with floor co-ordination
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        public static GameWorld ProcessElevatorMovements(GameWorld gameWorld)
        {
            var floorsWithPeople = gameWorld.Floors.Where(x => x.People.Count > 0);

            for(var i = 0; i < gameWorld.Elevators.Count; i++)
            {
                var thisElevator = gameWorld.Elevators[i];

                if (thisElevator.Direction == Direction.None || thisElevator.Direction == Direction.Up)
                {
                    if(floorsWithPeople.Any())
                    {
                        thisElevator.CurrentDestinationFloor = floorsWithPeople.Max(x => x.FloorNumber);
                    }
                }

                if (thisElevator.Direction == Direction.Down)
                {
                    if (floorsWithPeople.Any())
                    {
                        thisElevator.CurrentDestinationFloor = floorsWithPeople.Min(x => x.FloorNumber);
                    }
                }
            }

            return gameWorld;
        }
    }
}
