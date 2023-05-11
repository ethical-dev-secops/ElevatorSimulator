using ElevatorSimulator.Animator.Presentation;

namespace ElevatorSimulator.Animator.Parameters
{
    public class AnimatorArguments
    {
        /// <summary>
        /// Size of X dimension
        /// </summary>
        public int X;

        /// <summary>
        /// Size of Y dimension
        /// </summary>
        public int Y;

        /// <summary>
        /// Responsible for color selection
        /// </summary>
        public ColorCoordinator ColorCoordinator;

        /// <summary>
        /// Chooses how to render the simulation
        /// </summary>
        public AnimatorType AnimatorType;
    }
}