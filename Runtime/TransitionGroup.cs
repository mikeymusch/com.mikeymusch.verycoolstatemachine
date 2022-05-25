using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [Serializable]
    public struct TransitionGroup
    {
        [SerializeField] State fromState;
        [SerializeField] List<Transition> transitions;

        [SerializeField] List<string> listOfStrings;

        public TransitionGroup(State fromState, List<Transition> transitions)
        {
            this.fromState = fromState;
            this.transitions = transitions;
            listOfStrings = new List<string>() {"hello", "world", "mikey", "nicole"};
        }
    }
}