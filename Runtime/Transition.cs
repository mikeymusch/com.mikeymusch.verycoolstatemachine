using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [Serializable]
    public struct Transition
    {
        [SerializeField] State fromState;
        [SerializeField] State toState;
        [SerializeField] List<ConditionGroup> conditionGroups;

        public Transition(State fromState, State toState, List<ConditionGroup> conditionGroups)
        {
            this.fromState = fromState;
            this.toState = toState;
            this.conditionGroups = conditionGroups;
        }
    }
}