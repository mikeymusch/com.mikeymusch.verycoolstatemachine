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

            Foldout foldout = _visualElement.Q<Foldout>("transitionGroupFoldout");
            foldout.text = ObjectNames.NicifyVariableName(property.FindPropertyRelative("fromState").objectReferenceValue.name);
            foldout.viewDataKey = foldout.text;

            return _visualElement;
        }
        
        
        void LoadAndCloneMarkup()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                //"Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionGroup/TransitionGroupMarkup.uxml");
                "Assets/TransitionGroupMarkup.uxml");
            visualTree.CloneTree(_visualElement);
        }
    }
}