using System.Collections;
using Archer.States.Helpers;
using UnityEngine;

namespace Archer.States
{
    public class ShootState : IArcherState
    {
        private const string AimAnimationName = "Aim";
        private const string ShootAnimationName = "Shoot";
        public IEnumerator EnterState(ArcherStateMachine archer)
        {
            archer.Animator.SetTrigger(AimAnimationName);
            archer.EnableAiming();
            archer.SetShootTarget(ShootingHelper.GetShootTarget(archer.transform, archer.ShootingPoint));
            yield return new WaitForSeconds(archer.ArcherInfo.AimAnimationDuration);
            archer.Animator.SetTrigger(ShootAnimationName);
            archer.DisableAiming();
            GameObject.Instantiate(archer.ArrowPrefab, archer.ShootingPoint.position, archer.ShootingPoint.rotation)
                .Fly(archer.ShootTarget);
            yield return new WaitForSeconds(archer.ArcherInfo.ShootAnimationDuration);
            archer.SetNextState(archer.StateFactory.CreateState(StateFactory.State.Idle));
        }
    }
}