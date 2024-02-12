using System.Collections;
using UnityEngine;

namespace Archer.States.Helpers
{
    public static class MovementHelper
    {
        public static IEnumerator Move(Transform moving, Vector3 target, float speed ,float offset)
        {
            while ((moving.position - target).sqrMagnitude >= offset)
            {
                moving.position = Vector3.MoveTowards(moving.position, target,
                    speed);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}