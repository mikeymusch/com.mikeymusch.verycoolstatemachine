using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomEditor(typeof(TransitionTable))]
    public class TransitionTableEditor : Editor
    {
        VisualElement _visualElement;
        TransitionTable _target;
        
        public override bool UseDefaultMargins() => false;

        void OnEnable()
        {
            _target = target as TransitionTable;
        }

        public override VisualElement CreateInspectorGUI()
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup(_visualElement, "Assets/TransitionTableMarkup.uxml");
            // Distribution path version: "Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionTable/TransitionTableMarkup.uxml"
            HideScrollViewVerticalScrollbar(_visualElement, "transitionGroupsListView");
            SendReorderableItemParentToBack(_visualElement, "transitionGroupsListView", serializedObject.FindProperty("transitionGroups"));

            Button addTransitionButton = _visualElement.Q<Button>("addATransitionButton");
            addTransitionButton.clicked += () =>
            {
                SlideAndHideVisualElement(_visualElement, "body", true);
            };
            
            ObjectField fromStateObjectField = _visualElement.Q<ObjectField>("fromStateObjectField");
            ObjectField toStateObjectField = _visualElement.Q<ObjectField>("toStateObjectField");
            fromStateObjectField.objectType = typeof(State);
            toStateObjectField.objectType = typeof(State);
            
            Button createTransitionButton = _visualElement.Q<Button>("createATransitionButton");
            createTransitionButton.clicked += () =>
            {
                if (!fromStateObjectField.value || !toStateObjectField.value)
                {
                    Debug.LogWarning("Please complete all fields before creating a transition.");
                    return;
                }

                // get the fields and create a new transition group from it
                // if target already has transition with the same from and to state
                    // if conditions are different - add the new conditions to that transition
                    // if conditions are the same, warn console and discard them
                    
                // if target already has a transition with the same from state
                    // add new transition to that group
                
                _target.AddTransitionGroup();
            };
                
            return _visualElement;
        }
    }
}