using System.Collections;
using UnityEngine;

namespace Archer.States
{
    public class IdleState : IArcherState
    {
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.Play("idle");
            yield return new WaitForSeconds(Random.Range(archer.ArcherInfo.MinIdleTime, archer.ArcherInfo.MaxIdleTime));
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Rotate));
        }
    }
}
