using UnityEditor;
using UnityEngine.UIElements;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomPropertyDrawer(typeof(TransitionGroup))]
    public class TransitionGroupPropertyDrawer : PropertyDrawer
    {
        VisualElement _visualElement;


        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup();
            //DisplayTransitionGroupFoldout(property);

            return _visualElement;
        }
        
        
        void LoadAndCloneMarkup()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                //"Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionGroup/TransitionGroupMarkup.uxml");
                "Assets/TransitionGroupMarkup.uxml");
            visualTree.CloneTree(_visualElement);
        }

        void DisplayTransitionGroupFoldout(SerializedProperty property)
        {
            var foldout = new Foldout();
            foldout.text = ObjectNames.NicifyVariableName(property.FindPropertyRelative("fromState").objectReferenceValue.name);
            _visualElement.Add(foldout);
        }
    }
}