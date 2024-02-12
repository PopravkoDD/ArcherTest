using Archer.States.Helpers;
using UnityEngine;

namespace Arrow
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private float _stopOffset;
        [SerializeField] private float _speed;
        public void Fly(Vector3 target)
        {
            transform.LookAt(target, Vector3.up);
            StartCoroutine(MovementHelper.Move(transform, target, _speed, _stopOffset));
        }
    }
}