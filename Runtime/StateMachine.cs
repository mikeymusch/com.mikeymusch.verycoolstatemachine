using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    public abstract class StateMachine<T> : BaseStateMachine where T : BaseStateMachine
    {
        [SerializeField] protected TransitionTable<T> transitionTable;
    }

    public abstract class BaseStateMachine : MonoBehaviour
    {
    }
}