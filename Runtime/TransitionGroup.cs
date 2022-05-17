using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [Serializable]
    public struct TransitionGroup
    {
        [SerializeField] int index;
        [SerializeField] State fromState;
        [SerializeField] List<Transition> transitions;
    }
}