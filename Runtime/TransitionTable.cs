using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [CreateAssetMenu(fileName = "TransitionTable", menuName = "TransitionTable")]
    public class TransitionTable : ScriptableObject
    {
        // Fields for testing with
        [SerializeField] State idleState;
        [SerializeField] State jumpState;
        [SerializeField] State moveState;
        
        [SerializeField] Condition wPressedCondition;
        [SerializeField] Condition spacePressedCondition;
        // End fields for testing with


        List<Transition> _transitions = new();
        State _initialState => idleState; // currently returning idleState for now, implement later

        void OnEnable()
        {
            // Values for testing
            ConditionItem idleToMoveCondition = new ConditionItem(wPressedCondition, true);
            List<ConditionItem> idleToMoveConditions = new();
            idleToMoveConditions.Add(idleToMoveCondition);

            ConditionGroup idleToMoveConditionGroup = new ConditionGroup(idleToMoveConditions);
            List<ConditionGroup> idleToMoveConditionGroups = new();
            idleToMoveConditionGroups.Add(idleToMoveConditionGroup);
            
            Transition idleToMoveTransition = new Transition(idleState, moveState, idleToMoveConditionGroups);
            
            
            ConditionItem idleToJumpCondition = new ConditionItem(spacePressedCondition, true);
            List<ConditionItem> idleToJumpConditions = new();
            idleToJumpConditions.Add(idleToJumpCondition);

            ConditionGroup idleToJumpConditionGroup = new ConditionGroup(idleToJumpConditions);
            List<ConditionGroup> idleToJumpConditionGroups = new();
            idleToJumpConditionGroups.Add(idleToJumpConditionGroup);
            
            Transition idleToJumpTransition = new Transition(idleState, jumpState, idleToJumpConditionGroups);
            
            _transitions.Add(idleToMoveTransition);
            _transitions.Add(idleToJumpTransition);
            // End values for testing
        }

        public bool TryGetNextState(State currentState, out State nextState)
        {
            if (currentState is null)
            {
                nextState = _initialState;
                return true;
            }

            for (int i = 0; i < _transitions.Count(); i++)
            {
                if (_transitions[i].FromState != currentState) 
                    continue;
                if (!_transitions[i].EvaluateConditions()) 
                    continue;
                
                // transition with the same fromState as the current state
                // had a condition met and so a transition is needed
                nextState = _transitions[i].ToState;
                return true;
            }   

            // No conditions were met
            nextState = currentState;
            return false;
        }
    }
}