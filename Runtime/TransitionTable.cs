using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    public abstract class TransitionTable<T> : ScriptableObject, IEditableTransitionTable where T : BaseStateMachine
    {
        [SerializeField] List<TransitionGroup> transitionGroups;

        #region Testing Fields
        
        #endregion
        
        void OnEnable()
        {
            #region Testing Field Initialization
            
            #endregion
            
            transitionGroups = new List<TransitionGroup>()
            {
                
            };
        }

        public void AddTransitionGroup()
        {
            Debug.Log("hello world");
        }

        public Type GetGenericType()
        {
            return GetType();
        }
    }
}