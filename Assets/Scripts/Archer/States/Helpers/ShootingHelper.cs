using UnityEngine;

namespace Archer.States.Helpers
{
    public static class ShootingHelper
    {
        private static readonly float _shootingDistance = 2f;
        private static readonly float _upDistance = 4f;
        public static Vector3 GetShootTarget(Transform archer, Transform shootingPoint)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    Debug.Log("Shooting Down");
                    return archer.position + archer.forward * _shootingDistance;
                case 1: 
                    Debug.Log("Shooting Forward");
                    return shootingPoint.position + archer.forward * _shootingDistance;
                case 2:
                    Debug.Log("Shooting Up");
                    return archer.position + archer.forward * _shootingDistance + new Vector3(0, _upDistance, 0);
                default:
                    Debug.Log("Shooting Forward");
                    return shootingPoint.position + archer.forward * _shootingDistance;
            }
        }
    }
}