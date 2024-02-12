using Archer.States;
using Arrow;
using UnityEngine;

namespace Archer
{
    public class ArcherStateMachine : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ArcherInfo _archerInfo;
        [SerializeField] private Vector3 _runTarget;
        [SerializeField] private Vector3 _shootTarget;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private ArrowController arrowPrefab;
        private readonly StateFactory _stateFactory = new StateFactory();

        private void Start()
        {
            StartCoroutine(new IdleState().EnterState(this));
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
            _shootTarget = target;
        }


        public Animator Animator => _animator;
        public ArcherInfo ArcherInfo => _archerInfo;
        public StateFactory StateFactory => _stateFactory;
        public Vector3 RunTarget => _runTarget;
        public Vector3 ShootTarget => _shootTarget;
        public Transform ShootingPoint => _shootingPoint;
        public ArrowController ArrowPrefab => arrowPrefab;
    }
}
