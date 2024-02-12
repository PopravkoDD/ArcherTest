using Archer.States.Helpers;
using UnityEngine;

namespace Arrow
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        public void Fly(Vector3 target)
        {
            transform.LookAt(target, Vector3.up);
            StartCoroutine(MovementHelper.Move(transform, target, _speed, 0.1f));
        }
    }
}