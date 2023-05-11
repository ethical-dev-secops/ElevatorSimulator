using ElevatorSimulator.Animator.Abstract;
using ElevatorSimulator.Animator.Interface;
using ElevatorSimulator.Animator.Parameters;
using ElevatorSimulator.Animator.Presentation;
using ElevatorSimulator.Domain.WorldMechanics;
using System.Drawing;

namespace ElevatorSimulator.Animator
{
    public class WindowAnimator : AbstractAnimator, IAnimator
    {
        #region Properties

        public int SizeX;
        public int SizeY;
        public ColorCoordinator colorCoordinator;

        #endregion

        #region Constructors

        public WindowAnimator(AnimatorArguments animatorArguments)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        public override void RenderScreen(GameWorld gameWorld)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Primary method for displaying the UI
        /// </summary>
        /// <param name="map"></param>
        private void DrawScreen(CanvasMap[,] map)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}