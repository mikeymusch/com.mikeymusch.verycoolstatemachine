using UnityEditor;
using UnityEngine.UIElements;
using static com.mikeymusch.verycoolstatemachine.TransitionTableEditorUtilities;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomPropertyDrawer(typeof(ConditionGroup))]
    public class ConditionGroupPropertyDrawer : PropertyDrawer
    {
        VisualElement _visualElement;
        
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup(_visualElement, "Assets/ConditionGroupMarkup.uxml");
            // Dist path ver: "Packages/com.mikeymusch.verycoolstatemachine/Editor/ConditionGroup/ConditionGroupMarkup.uxml"

            return _visualElement;
        }
    }
}