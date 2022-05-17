using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [CreateAssetMenu(fileName = "TransitionTable", menuName = "TransitionTable")]
    public class TransitionTable : ScriptableObject
    {
        internal Dictionary<int, List<string>> myDictionary;

        internal List<TransitionGroup> transitionGroups; 

        void OnEnable()
        {
            
        }
    }
}