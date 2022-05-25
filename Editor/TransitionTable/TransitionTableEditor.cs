using UnityEditor;
using UnityEngine.UIElements;

namespace com.mikeymusch.verycoolstatemachine
{
    [CustomEditor(typeof(TransitionTable))]
    public class TransitionTableEditor : Editor
    {
        VisualElement _visualElement;
        TransitionTable _transitionTable;
        
        public override bool UseDefaultMargins() => false;

        void OnEnable()
        {
            _transitionTable = (TransitionTable)target;
        }
        
        public override VisualElement CreateInspectorGUI()
        {
            _visualElement = new VisualElement();

            LoadAndCloneMarkup();
            HideVerticalScrollVisibility();

            return _visualElement;
        }

        void LoadAndCloneMarkup()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                //"Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionTable/TransitionTableMarkup.uxml");
                "Assets/TransitionTableMarkup.uxml");
            visualTree.CloneTree(_visualElement);
        }
        void HideVerticalScrollVisibility()
        {
            ListView listView = _visualElement.Q<ListView>("transitionGroupsListView");
            ScrollView scrollView = listView.Q<ScrollView>("", "unity-scroll-view");
            scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;
        }
    }
}