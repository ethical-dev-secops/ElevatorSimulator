using ElevatorSimulator.Domain.WorldMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulator.Animator.Interface
{
    public interface IAnimator
    {
        void RenderScreen(GameWorld gameWorld);
    }
}
