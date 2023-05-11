using ElevatorSimulator.Domain.DomainModels;
using ElevatorSimulator.Domain.Enums;
using ElevatorSimulator.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Domain.WorldMechanics
{
    /// <summary>
    /// Main class responsible for managing the game and handling the world's logic.
    /// </summary>
    public class GameMaster
    {
        /// <summary>
        /// Contains Simulation settings.
        /// </summary>
        public GameConfiguration Configuration { get; set; }

        /// <summary>
        /// Contains Simulation state variables. 
        /// </summary>
        private GameWorld gameWorld { get; set; }

        public GameMaster(GameConfiguration configuration)
        {
            Configuration = configuration;

            gameWorld = new GameWorld(Configuration);

        }

        /// <summary>
        /// Main executable for the game thread.
        /// </summary>
        public void CalculateLogicForNextFrame()
        {
            gameWorld = GameWorldUtilities.MoveElevators(gameWorld);
            gameWorld = GameWorldUtilities.MovePeople(gameWorld);
            gameWorld = GameWorldUtilities.ProcessRequest(gameWorld);
            gameWorld = GameWorldUtilities.ProcessCursor(gameWorld);
        }

        public GameWorld GetGameWorld()
        {
            return this.gameWorld;
        }

        public void AddRequest(int y)
        {
            gameWorld.Requests.Add(new DomainModels.Request() 
            {
                YPosition = y
            });
        }

        public void MoveCursorUp()
        {
            if (gameWorld.Cursor.YIndex < gameWorld.Cursor.MaxYIndex)
            {
                gameWorld.Cursor.YIndex++;
            }
        }

        public void MoveCursorDown()
        {
            if (gameWorld.Cursor.YIndex > 0)
            {
                gameWorld.Cursor.YIndex--;
            }
        }

        public void MoveCursorLeft()
        {
            if (gameWorld.Cursor.XIndex == 19)
            {
                gameWorld.Cursor.XIndex = 5;
            }
        }

        public void MoveCursorRight()
        {
            if (gameWorld.Cursor.XIndex == 5)
            {
                gameWorld.Cursor.XIndex = 19;
            }
        }

        public void ActivateCursor()
        {
            gameWorld.Cursor.CursorState = CursorState.Active;
        }

        /// <summary>
        /// Adds a person to current floor with random destination.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        public void AddNewPersonToFloor()
        {
            gameWorld.Floors[gameWorld.Cursor.YIndex].AddPerson(new Person());
        }
    }
}
