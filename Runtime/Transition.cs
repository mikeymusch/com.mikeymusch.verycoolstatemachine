using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    public struct Transition
    {
        List<ConditionGroup> _conditions;
        
        public State FromState { get; }
        public State ToState { get; }
        
        public Transition(State fromState, State toState, List<ConditionGroup> conditions)
        {
            _conditions = conditions;
            FromState = fromState;
            ToState = toState;
        }

        public bool EvaluateConditions()
        {
            for (int i = 0; i < _conditions.Count; i++)
            {
                for (int j = 0; j < _conditions[i].ConditionItems.Count; j++)
                {
                    if (_conditions[i].ConditionItems[j].Condition.Statement() != _conditions[i].ConditionItems[j].ExpectedResult)
                        break; // condition was not met, move on to next group
                    if (j == _conditions[i].ConditionItems.Count - 1)
                        return true; // we got to the end of the group and all of the conditions were satisfied
                }
            }
        
            // no condition items were met
            return false;
        }
    }
}