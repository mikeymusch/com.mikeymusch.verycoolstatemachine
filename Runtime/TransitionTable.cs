using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [CreateAssetMenu(fileName = "TransitionTable", menuName = "TransitionTable")]
    public class TransitionTable : ScriptableObject
    {
        [SerializeField] internal List<TransitionGroup> transitionGroups;

        #region Testing Fields
        [SerializeField] State idleState;
        [SerializeField] State moveState;
        [SerializeField] State eventState;
        
        [SerializeField] Condition movePressedCondition;
        // event thing

        ConditionItem _movePressed;
        ConditionItem _moveNotPressed;

        ConditionGroup _idleToMoveConditions;
        ConditionGroup _moveToIdleConditions;

        Transition _idleToMoveTransition;
        Transition _moveToIdleTransition;

        TransitionGroup _idleTransitionGroup;
        TransitionGroup _moveTransitionGroup;
        #endregion
        
        void OnEnable()
        {
            #region Testing Field Initialization
            _movePressed = new ConditionItem(movePressedCondition, true);
            _moveNotPressed = new ConditionItem(movePressedCondition, false);

            _idleToMoveConditions = new ConditionGroup(new List<ConditionItem>() {_movePressed});
            _moveToIdleConditions = new ConditionGroup(new List<ConditionItem>() {_moveNotPressed});

            _idleToMoveTransition = new Transition(idleState, moveState, new List<ConditionGroup>(){_idleToMoveConditions});
            _moveToIdleTransition = new Transition(moveState, idleState, new List<ConditionGroup>(){_moveToIdleConditions});

            _idleTransitionGroup = new TransitionGroup(idleState, new List<Transition>(){_idleToMoveTransition});
            _moveTransitionGroup = new TransitionGroup(moveState, new List<Transition>(){_moveToIdleTransition});
            #endregion
            
            transitionGroups = new List<TransitionGroup>()
            {
                _idleTransitionGroup,
                _moveTransitionGroup
            };
        }
    }
}