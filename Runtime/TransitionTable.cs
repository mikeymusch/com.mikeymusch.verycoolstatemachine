using System.Collections.Generic;
using UnityEngine;

namespace com.mikeymusch.verycoolstatemachine
{
    [CreateAssetMenu(menuName = "Transition Table")]
    public class TransitionTable : ScriptableObject
    {
        [SerializeField] internal List<TransitionGroup> transitionGroups;

        #region Testing Fields
        [SerializeField] State idleState;
        [SerializeField] State moveState;
        [SerializeField] State jumpState;
        [SerializeField] State attackState;

        [SerializeField] Condition movePressedCondition;
        [SerializeField] Condition jumpPressedCondition;
        [SerializeField] Condition attackPressedCondition;
        #endregion

        void OnEnable()
        {
            #region Testing Field Initialization
            ConditionItem movePressed = new ConditionItem(movePressedCondition, true);
            ConditionItem moveNotPressed = new ConditionItem(movePressedCondition, false);
            ConditionItem jumpPressed = new ConditionItem(jumpPressedCondition, true);
            ConditionItem jumpNotPressed = new ConditionItem(jumpPressedCondition, false);
            ConditionItem attackPressed = new ConditionItem(attackPressedCondition, true);
            ConditionItem attackNotPressed = new ConditionItem(attackPressedCondition, false);
            ConditionItem extraNPressed = new ConditionItem(attackPressedCondition, false);

            ConditionGroup noInputPressed = new ConditionGroup(new List<ConditionItem>()
                {moveNotPressed, jumpNotPressed});
            ConditionGroup moveInputPressed = new ConditionGroup(new List<ConditionItem>() {movePressed});
            ConditionGroup jumpInputPressed = new ConditionGroup(new List<ConditionItem>() {jumpPressed});
            ConditionGroup attackInputPressed = new ConditionGroup(new List<ConditionItem>() {attackPressed});
            ConditionGroup attackInputNotPressed = new ConditionGroup(new List<ConditionItem>() {attackNotPressed, extraNPressed});
            

            Transition moveToIdleTransition = new Transition(moveState, idleState, new List<ConditionGroup>() {noInputPressed, attackInputNotPressed});
            Transition idleToMoveTransition = new Transition(idleState, moveState, new List<ConditionGroup>() {moveInputPressed});
            Transition idleToAttackTransition = new Transition(idleState, attackState, new List<ConditionGroup>() {attackInputPressed});

            TransitionGroup moveTransitionGroup = new TransitionGroup(moveState, new List<Transition>() {moveToIdleTransition});
            TransitionGroup idleTransitionGroup = new TransitionGroup(idleState, new List<Transition>() {idleToMoveTransition, idleToAttackTransition});
            #endregion
            
            transitionGroups = new List<TransitionGroup>()
            {
                moveTransitionGroup, 
                idleTransitionGroup
            };
        }

        public void AddTransitionGroup()
        {
            Debug.Log("hello world");
        }
    }
}