using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class RotateRightState : IArcherState
    {
        private const string AnimationName = "TurnRight";
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            AnimationCurve curve = archer.ArcherInfo.TurnRightAnimationCurve; 
            archer.Animator.SetTrigger(AnimationName);
            Debug.Log("Turning right");
            yield return RotationHelper.RotateRight(curve.keys[^1].time, archer.transform, curve);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Action));
        }
    }
}
