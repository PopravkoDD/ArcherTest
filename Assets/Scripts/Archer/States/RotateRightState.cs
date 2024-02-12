using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class RotateRightState : IArcherState
    {
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            AnimationCurve curve = archer.ArcherInfo.TurnRightAnimationCurve; 
            archer.Animator.SetTrigger("TurnRight");
            Debug.Log("Turning right");
            yield return RotationHelper.RotateRight(curve.keys[^1].time, archer.transform, curve);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Action));
        }
    }
}
