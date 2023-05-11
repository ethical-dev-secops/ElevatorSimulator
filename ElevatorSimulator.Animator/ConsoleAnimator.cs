using ElevatorSimulator.Animator.Abstract;
using ElevatorSimulator.Animator.Interface;
using ElevatorSimulator.Animator.Parameters;
using ElevatorSimulator.Animator.Presentation;
using ElevatorSimulator.Domain.WorldMechanics;
using System.Drawing;

namespace ElevatorSimulator.Animator
{
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

        public void RenderScreen(GameWorld gameWorld)
        {
            var bitmap = DrawScreenInMemoryBuffer(gameWorld);
            DrawScreen(bitmap);
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Primary method for displaying the UI
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
                        if (map[x, y].Value != 0)
                        {
                            Console.Write(map[x, y].Value);
                            Console.Write('\u0166');
                        }
                    }
                }
            }







            CreateInstructions();
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
            Console.Write("║ ║");
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

        private CanvasMap[,] DrawScreenInMemoryBuffer(GameWorld gameWorld)
        {
            CanvasMap[,] worldAsBitmap = new CanvasMap[SizeX+10,SizeY];
            
            foreach (var item in gameWorld.Elevators)
            {
                worldAsBitmap[item.XPosition, item.YPosition] = colorCoordinator.GetColor(item);
            }

            foreach (var item in gameWorld.Requests)
            {
                worldAsBitmap[item.XPosition, item.YPosition] = colorCoordinator.GetColor(item);
            }

            worldAsBitmap[1, gameWorld.Cursor.YIndex] = colorCoordinator.GetColor(gameWorld.Cursor);

            return worldAsBitmap;
        }

        #endregion
    }
}