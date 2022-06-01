using UnityEditor;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomPropertyDrawer(typeof(Transition))]
    public class TransitionPropertyDrawer : PropertyDrawer
    {
        VisualElement _visualElement;

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup(_visualElement, "Assets/TransitionMarkup.uxml");
            // Dist path ver: "Packages/com.mikeymusch.verycoolstatemachine/Editor/Transition/TransitionMarkup.uxml"
            HideScrollViewVerticalScrollbar(_visualElement, "transitionListView");
            
            Foldout foldout = _visualElement.Q<Foldout>("transitionFoldout");
            foldout.text = "To " + ObjectNames.NicifyVariableName(property.FindPropertyRelative("toState").objectReferenceValue.name);
            foldout.viewDataKey = foldout.text;
            
            return _visualElement;
        }
    }
}