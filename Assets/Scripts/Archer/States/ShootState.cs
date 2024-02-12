using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class ShootState : IArcherState
    {
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.SetTrigger("Aim");
            yield return new WaitForSeconds(archer.ArcherInfo.AimAnimationDuration);
            archer.Animator.SetTrigger("Shoot");
            archer.SetShootTarget(ShootingHelper.GetShootTarget(archer.transform, archer.ShootingPoint));
            GameObject.Instantiate(archer.ArrowPrefab, archer.ShootingPoint.position, archer.ShootingPoint.rotation)
                .Fly(archer.ShootTarget);
            yield return new WaitForSeconds(archer.ArcherInfo.ShootAnimationDuration);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Idle));
        }
    }
}