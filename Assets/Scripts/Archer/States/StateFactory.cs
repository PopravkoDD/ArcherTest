using UnityEngine;

namespace Archer.States
{
    public class StateFactory
    {
        private bool _hasTarget = true;
        public IArcherState CreateState(State state)
        {
            switch (state)
            {
                case State.Idle:
                    return new IdleState();
                case State.Run:
                    return new RunState();
                case State.Action:
                    return SwapTarget() ? new ShootState() : new RunState();
                case State.Rotate:
                    return FiftyFifty() ? new RotateRightState() : new RotateLeftState();
                default:
                    return new IdleState();
            }
        }

        public enum State
        {
            Idle,
            Action,
            Run,
            Rotate
        }

        private static bool FiftyFifty()
        {
            return Random.value >= 0.5;
        }

        private bool SwapTarget()
        {
            _hasTarget = !_hasTarget;
            return _hasTarget;
        }
    }
}