using UnityEditor;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomEditor(typeof(TransitionTable))]
    public class TransitionTableEditor : Editor
    {
        VisualElement _visualElement;
        
        public override bool UseDefaultMargins() => false;

        public override VisualElement CreateInspectorGUI()
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup(_visualElement, "Assets/TransitionTableMarkup.uxml");
            // Distribution path version: "Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionTable/TransitionTableMarkup.uxml"
            HideScrollViewVerticalScrollbar(_visualElement, "transitionGroupsListView");
            SendReorderableItemParentToBack(_visualElement, "transitionGroupsListView", serializedObject.FindProperty("transitionGroups"));

            return _visualElement;
        }
    }
}