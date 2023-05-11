using ElevatorSimulator.Animator.Interface;
using ElevatorSimulator.Animator.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Animator.Factory
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class AnimatorFactory
    {
        public IAnimator CreateAnimator(AnimatorArguments argument)
        {
            switch (argument.AnimatorType)
            {
                case (AnimatorType.ConsoleAnimator):
                    return new ConsoleAnimator(argument);

                case (AnimatorType.WindowAnimator):
                    return new WindowAnimator(argument);

                default:
                    return new ConsoleAnimator(argument);

            }
        }
    }
}
