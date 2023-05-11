using ElevatorSimulator.Animator;
using ElevatorSimulator.Animator.Factory;
using ElevatorSimulator.Domain.WorldMechanics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ElevatorSimulator.ConsoleApplication
{
    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IHost _host;

        public WorkerService(ILogger<WorkerService> logger, IHost host)
        {
            _logger = logger;
            _host = host;
        }


        /// <summary>
        /// Main IO and Simulation Thread
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            GameMaster simulator = GetGameMaster();
            ConsoleAnimator renderer = GetRenderer();

            var mainThread = new System.Timers.Timer(300);
            mainThread.Enabled = true;

            void RenderSimulationThread(Object source, ElapsedEventArgs e)
            {
                Console.Clear();

                simulator.CalculateLogicForNextFrame();
                renderer.RenderScreen(simulator.GetGameWorld());
            }

            RenderSimulationThread(null, null);
            mainThread.Elapsed += RenderSimulationThread;

            Console.Clear();

            var kbTask = Task.Run(() =>
            {
                while (true)
                {
                    ProcessKeyboard(simulator);
                }
            });
        }


        /// <summary>
        /// Handles keyboard input
        /// </summary>
        /// <param name="simulator"></param>
        private static void ProcessKeyboard(GameMaster simulator)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
            {
                simulator.MoveCursorUp();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                simulator.MoveCursorDown();
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                simulator.MoveCursorLeft();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                simulator.MoveCursorRight();
            }
            else if (key.Key == ConsoleKey.Spacebar)
            {
                simulator.ActivateCursor();
                simulator.AddNewPersonToFloor();
            }
        }

        private static ConsoleAnimator GetRenderer()
        {
            var factory = new AnimatorFactory();

            return (ConsoleAnimator) factory.CreateAnimator(new Animator.Parameters.AnimatorArguments()
            {
                X = 30,
                Y = 10,
                ColorCoordinator = new Animator.Presentation.ColorCoordinator()
            });
        }

        private static GameMaster GetGameMaster()
        {
            return new GameMaster(new GameConfiguration()
            {
                NumberOfElevators = 2,
                NumberOfFloors = 10,
                MaxHeight = 10
            });
        }
    }
}
