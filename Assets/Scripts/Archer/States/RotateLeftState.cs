using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class RotateLeftState : IArcherState
    {
        private const string AnimationName = "TurnLeft";
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            AnimationCurve curve = archer.ArcherInfo.TurnLeftAnimationCurve; 
            archer.Animator.SetTrigger(AnimationName);
            Debug.Log("Turning left");
            yield return RotationHelper.RotateLeft(curve.keys[^1].time, archer.transform, curve);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Action));
        }
    }
}