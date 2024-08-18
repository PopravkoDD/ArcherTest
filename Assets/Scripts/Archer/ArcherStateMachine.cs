using System.Collections;
using Archer.States;
using Arrow;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;

namespace Archer
{
    public class ArcherStateMachine : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ArcherInfo _archerInfo;
        [SerializeField] private Vector3 _runTarget;
      //  [SerializeField] private Vector3 _shootTarget;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private ArrowController _arrowPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private MultiAimConstraint aimingRig;
        private readonly StateFactory _stateFactory = new StateFactory();

        private void Start()
        {
            StartCoroutine(_stateFactory
                .CreateState(StateFactory.State.Idle)
                .EnterState(this));
        }

        public void SetNextState(IArcherState state)
        {
            StartCoroutine(state.EnterState(this));
        }

        public void SetRunTarget(Vector3 target)
        {
            _runTarget = target;
        }

        public void SetShootTarget(Vector3 target)
        {
            this._target.position = target;
            //_shootTarget = target;
        }

        public void EnableAiming()
        {
            StartCoroutine(ChangeAnimRiggingWeight(1));
        }

        public void DisableAiming()
        {
            StartCoroutine(ChangeAnimRiggingWeight(0));
        }

        private IEnumerator ChangeAnimRiggingWeight(float finalValue)
        {
            float currentTime = 0f;
            while (currentTime <= _archerInfo.AimingTime)
            {
                currentTime += Time.deltaTime;
                aimingRig.weight = Mathf.Lerp(aimingRig.weight, finalValue, currentTime);
                yield return null;
            }

            aimingRig.weight = finalValue;
            yield return null;
        }

        public Animator Animator => _animator;
        public ArcherInfo ArcherInfo => _archerInfo;
        public StateFactory StateFactory => _stateFactory;
        public Vector3 RunTarget => _runTarget;
        public Vector3 ShootTarget => _target.position;
        public Transform ShootingPoint => _shootingPoint;
        public ArrowController ArrowPrefab => _arrowPrefab;
    }
}
