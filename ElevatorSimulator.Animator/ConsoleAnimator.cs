using ElevatorSimulator.Animator.Abstract;
using ElevatorSimulator.Animator.Interface;
using ElevatorSimulator.Animator.Parameters;
using ElevatorSimulator.Animator.Presentation;
using ElevatorSimulator.Domain.WorldMechanics;
using System.Drawing;
using System.Reflection.Emit;

namespace ElevatorSimulator.Animator
{
    /// <summary>
    /// Draws the Console interface.
    /// </summary>
    /// 
    /// <remarks>
    /// Refreshes the screen on a Timer Thread (ie: no Console.Read())
    /// </remarks>
    /// 
    public class ConsoleAnimator : AbstractAnimator, IAnimator
    {
        #region Properties

        public int SizeX;
        public int SizeY;
        public ColorCoordinator colorCoordinator;

        #endregion

        #region Constructors

        public ConsoleAnimator(AnimatorArguments animatorArguments)
        {
            this.SizeX = animatorArguments.X;
            this.SizeY = animatorArguments.Y;
            this.colorCoordinator = animatorArguments.ColorCoordinator;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Main Draw to screen method
        /// </summary>
        /// <param name="gameWorld"></param>
        public void RenderScreen(GameWorld gameWorld)
        {
            var bitmap = DrawScreenInMemoryBuffer(gameWorld);
            DrawScreen(bitmap);
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Primary method for displaying the UI. Just prints out the pre-decided bitmap.
        /// </summary>
        /// <param name="map"></param>
        private void DrawScreen(CanvasMap[,] map)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Elevator Simulator");

            for (var y = 0; y < SizeY; y++)
            {
                DrawShaft1(y);

                DrawShaft2(y);

                for (var x = 0; x < SizeX; x++)
                {
                    if (map[x, y] != null && map[x, y].Color != ConsoleColor.Black)
                    {
                        Console.ForegroundColor = map[x, y].Color;
                        Console.CursorLeft = x;
                        Console.CursorTop = this.SizeY - y;
                        Console.Write('\u2588');

                        ProcessLabel(map[x, y].Value);
                    }
                }
            }

            CreateInstructions();
        }

        /// <summary>
        /// Used to label the amount of people
        /// </summary>
        /// <param name="label"></param>
        private static void ProcessLabel(double label)
        {
            if (label != 0)
            {
                if (label > 9)
                {
                    Console.Write(9);
                }
                else
                {
                    Console.Write(label);
                }
            }
        }

        /// <summary>
        /// Draws elevator shaft 1
        /// </summary>
        /// <param name="y"></param>
        private void DrawShaft1(int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = GameConfiguration.Elevator1XIndex;
            Console.CursorTop = this.SizeY - y;
            Console.Write("║ ║"+$"[{y}]");
        }

        /// <summary>
        /// Draws elevator shaft 2
        /// </summary>
        /// <param name="y"></param>
        private void DrawShaft2(int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = GameConfiguration.Elevator2XIndex;
            Console.CursorTop = this.SizeY - y;
            Console.Write("║ ║");
        }

        /// <summary>
        /// Prints UI instructions
        /// </summary>
        private static void CreateInstructions()
        {
            Console.CursorLeft = 20;
            Console.CursorTop = 20;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Instructions:");
            Console.WriteLine($"╔═══════════════════════╗   ╔═══════════════════════════════════╗");
            Console.WriteLine($"║ Add Person [Spacebar] ║   ║ Navigation [Up][Down][Left][Right]║");
            Console.WriteLine($"╚═══════════════════════╝   ╚═══════════════════════════════════╝");
        }

        /// <summary>
        /// Creates a virtual UI in Memory.
        /// </summary>
        /// <param name="gameWorld"></param>
        /// <returns></returns>
        private CanvasMap[,] DrawScreenInMemoryBuffer(GameWorld gameWorld)
        {
            CanvasMap[,] worldAsBitmap = new CanvasMap[SizeX+10,SizeY];
            
            foreach (var elevator in gameWorld.Elevators)
            {
                worldAsBitmap[elevator.XPosition, elevator.CurrentFloorNumber] = colorCoordinator.GetColor(elevator);
            }

            foreach (var request in gameWorld.Requests)
            {
                worldAsBitmap[request.XPosition, request.YPosition] = colorCoordinator.GetColor(request);
            }

            foreach (var floor in gameWorld.Floors.Where(x => x.People.Count() > 0))
            {
                 worldAsBitmap[GameConfiguration.Elevator1XIndex - 2, floor.FloorNumber] = new CanvasMap()
                {
                    Color = colorCoordinator.GetColor(floor.People.First()),
                    Value = floor.People.Count()
                };
            }

            worldAsBitmap[1, gameWorld.Cursor.YIndex] = colorCoordinator.GetColor(gameWorld.Cursor);

            return worldAsBitmap;
        }

        #endregion
    }
}