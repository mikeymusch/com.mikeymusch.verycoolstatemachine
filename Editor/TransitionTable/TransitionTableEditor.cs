using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomEditor(typeof(TransitionTable<>), true)]
    public class TransitionTableEditor : Editor
    {
        VisualElement _visualElement;
        IEditableTransitionTable _target;
        
        public override bool UseDefaultMargins() => false;

        void OnEnable()
        {
            _target = target as IEditableTransitionTable;
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
                _target.AddTransitionGroup();
                //Debug.Log(_target.GetType());
            };

            _visualElement.Q<ObjectField>("testOF").objectType = _target.GetGenericType();
            
            return _visualElement;
        }
    }
}