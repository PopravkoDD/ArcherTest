using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class RunState : IArcherState
    {
        private const string RunAnimationName = "Run";
        private const string StopAnimationName = "Stop";
        private const float MinDistance = 5f;
        private const float MaxDistance = 15f;
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.SetTrigger(RunAnimationName);
            archer.SetRunTarget(archer.transform.position + archer.transform.forward * Random.Range(MinDistance, MaxDistance));
            Debug.Log("Running to the target: " + archer.RunTarget);
            yield return MovementHelper.Move(archer.transform, archer.RunTarget, archer.ArcherInfo.RunSpeed,
                archer.ArcherInfo.DestinationOffset);
            archer.Animator.SetTrigger(StopAnimationName);
            yield return new WaitForSeconds(archer.ArcherInfo.StopAnimationDuration);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Rotate));
        }
    }
}