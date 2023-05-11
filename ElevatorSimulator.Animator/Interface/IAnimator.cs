using ElevatorSimulator.Domain.WorldMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Animator.Interface
{
    /// <summary>
    /// All animators must render to the screen
    /// </summary>
    /// <remarks>
    /// The intention is to later create a Windows Form, and subsequently an OpenGL renderer.
    /// </remarks>
    public interface IAnimator
    {
        void RenderScreen(GameWorld gameWorld);
    }
}
