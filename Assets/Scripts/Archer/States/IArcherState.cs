using System.Collections;

namespace Archer.States
{
    public interface IArcherState
    {
        IEnumerator EnterState(ArcherStateMachine archer);
    }
}
