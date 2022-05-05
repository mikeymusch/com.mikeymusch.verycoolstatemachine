using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    public class StateMachine : MonoBehaviour
    {
        // Fields for testing
        [SerializeField] State idleState;
        // Ends fields for testing
        
        [SerializeField] TransitionTable transitionTable;

        State _currentState;
        
        void Start()
        {
        }

        void Update()
        {
            if (transitionTable.TryGetNextState(_currentState, out var nextState))
                TransitionStates(nextState);
        }

        void TransitionStates(State nextState)
        {
            if (_currentState is null)
            {
                _currentState = nextState;
                _currentState.OnEnter();
            }
            else
            {
                _currentState.OnExit();
                _currentState = nextState;
                _currentState.OnEnter();   
            }
        }
    }
}