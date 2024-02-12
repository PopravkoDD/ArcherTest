using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "New_Archer", menuName = "Archer")]
    public class ArcherInfo : ScriptableObject
    {
        [SerializeField] private float _minIdleTime;
        public float MinIdleTime => _minIdleTime;
        
        [SerializeField] private float _maxIdleTime;
        public float MaxIdleTime => _maxIdleTime;

        [SerializeField] private AnimationCurve _turnRightAnimationCurve;
        public AnimationCurve TurnRightAnimationCurve => _turnRightAnimationCurve;


        [SerializeField] private AnimationCurve _turnLeftAnimationCurve;
        public AnimationCurve TurnLeftAnimationCurve => _turnLeftAnimationCurve;

        [SerializeField] private AnimationClip _stopAnimation;
        public float StopAnimationDuration => _stopAnimation.length;
        
        [SerializeField] private AnimationClip _aimAnimation;
        public float AimAnimationDuration => _aimAnimation.length;
        
        [SerializeField] private AnimationClip _shootAnimation;
        public float ShootAnimationDuration => _shootAnimation.length;
        
        [SerializeField] private float _runSpeed;
        public float RunSpeed => _runSpeed;
        
        [Header("Should Be Powered(^2)!")][SerializeField] private float _destinationOffset;
        public float DestinationOffset => _destinationOffset;
    }
}
