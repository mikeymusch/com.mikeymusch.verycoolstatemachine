using UnityEditor;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomPropertyDrawer(typeof(TransitionGroup))]
    public class TransitionGroupPropertyDrawer : PropertyDrawer
    {
        VisualElement _visualElement;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup(_visualElement, "Assets/TransitionGroupMarkup.uxml");
            // Dist path ver: "Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionGroup/TransitionGroupMarkup.uxml"
            HideScrollViewVerticalScrollbar(_visualElement, "transitionGroupListView");
            SendReorderableItemParentToBack(_visualElement, "transitionGroupListView", property.FindPropertyRelative("transitions"));
            
            Foldout foldout = _visualElement.Q<Foldout>("transitionGroupFoldout");
            foldout.text = ObjectNames.NicifyVariableName("From " + property.FindPropertyRelative("fromState").objectReferenceValue.name);
            foldout.viewDataKey = foldout.text;
            
            return _visualElement;
        }
    }
}