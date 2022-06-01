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
            var _testConditions = new ConditionGroup(new List<ConditionItem>() { });
            var _testConditions2 = new ConditionGroup(new List<ConditionItem>() { });

            _idleToMoveTransition = new Transition(idleState, moveState, new List<ConditionGroup>(){_idleToMoveConditions, _testConditions});
            _moveToIdleTransition = new Transition(moveState, idleState, new List<ConditionGroup>(){_moveToIdleConditions});
            var _testTransition = new Transition(moveState, idleState, new List<ConditionGroup>(){_testConditions2});

            _idleTransitionGroup = new TransitionGroup(idleState, new List<Transition>(){_idleToMoveTransition,_testTransition});
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