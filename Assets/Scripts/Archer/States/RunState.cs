using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class RunState : IArcherState
    {
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.SetTrigger("Run");
            archer.SetRunTarget(archer.transform.position + archer.transform.forward * Random.Range(5f, 15f));
            Debug.Log("Running to the target: " + archer.RunTarget);
            yield return MovementHelper.Move(archer.transform, archer.RunTarget, archer.ArcherInfo.RunSpeed,
                archer.ArcherInfo.DestinationOffset);
            archer.Animator.SetTrigger("Stop");
            yield return new WaitForSeconds(archer.ArcherInfo.StopAnimationDuration);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Rotate));
        }
    }
}