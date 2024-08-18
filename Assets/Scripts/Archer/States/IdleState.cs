using System.Collections;
using UnityEngine;

namespace Archer.States
{
    public class IdleState : IArcherState
    {
        private const string AnimationName = "Idle";

        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.SetTrigger(AnimationName);
            yield return new WaitForSeconds(Random.Range(archer.ArcherInfo.MinIdleTime, archer.ArcherInfo.MaxIdleTime));
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Rotate));
        }
    }
}
