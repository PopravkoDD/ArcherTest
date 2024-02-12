using System.Collections;
using UnityEngine;

namespace Archer.States.Helpers
{
    public static class RotationHelper
    {
        private delegate float Rotator(AnimationCurve curve, float delta);
        
        public static IEnumerator RotateRight(float endTime, Transform archer, AnimationCurve curve)
        {
            return Rotate(endTime, archer, curve, (animationCurve, delta) => animationCurve.Evaluate(delta));
        }

        public static IEnumerator RotateLeft(float endTime, Transform archer, AnimationCurve curve)
        {
            return Rotate(endTime, archer, curve, (animationCurve, delta) => -animationCurve.Evaluate(delta));
        }
        
        private static IEnumerator Rotate(float endTime, Transform archer, AnimationCurve curve, Rotator rotator)
        {
            Vector3 archerStartRotation = archer.rotation.eulerAngles;
            float time = 0;
            while(time < endTime)
            {
                time += Time.deltaTime;
                archer.rotation =
                    AddDeltaRotation(archerStartRotation, rotator.Invoke(curve, time));
                yield return null;
            }
            archer.rotation =
                AddDeltaRotation(archerStartRotation, rotator.Invoke(curve, endTime));
        }


        private static Quaternion AddDeltaRotation(Vector3 startRotation, float delta)
        {
            return Quaternion.Euler(startRotation.x,
                startRotation.y + delta,
                startRotation.z);
        }
        
    }
}