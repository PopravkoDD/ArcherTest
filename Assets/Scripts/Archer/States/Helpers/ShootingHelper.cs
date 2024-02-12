using UnityEngine;

namespace Archer.States.Helpers
{
    public static class ShootingHelper
    {
        private const float ShootingDistance = 2f;
        private static readonly Vector3 HighTarget = new Vector3(0, 4, 0);
        public static Vector3 GetShootTarget(Transform archer, Transform shootingPoint)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Debug.Log("Shooting Down");
                    return archer.position + archer.forward * ShootingDistance;
                case 1: 
                    Debug.Log("Shooting Forward");
                    return shootingPoint.position + archer.forward * ShootingDistance;
                case 2:
                    Debug.Log("Shooting Up");
                    return archer.position + archer.forward * ShootingDistance + HighTarget;
                default:
                    Debug.Log("Shooting Forward");
                    return shootingPoint.position + archer.forward * ShootingDistance;
            }
        }
    }
}