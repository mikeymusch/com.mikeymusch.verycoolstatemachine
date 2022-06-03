using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace com.mikeymusch.verycoolstatemachine
{
    public static class TransitionTableEditorUtilities
    {
        public static void LoadAndCloneMarkup(VisualElement visualElement, string markupFilePath)
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(markupFilePath);
            visualTree.CloneTree(visualElement);
        }

        public static void HideScrollViewVerticalScrollbar(VisualElement visualElement, string nameOfListView)
        {
            visualElement.Q<ListView>(nameOfListView).Q<ScrollView>("", "unity-scroll-view")
                .verticalScrollerVisibility = ScrollerVisibility.Hidden;
        }

        public static void SendReorderableItemParentToBack(VisualElement visualElement, string nameOfListView, SerializedProperty serializedProperty)
        {
            ListView listView = visualElement.Q<ListView>(nameOfListView);

            listView.bindItem += (element, i) =>
            {
                (element as PropertyField).BindProperty(serializedProperty.GetArrayElementAtIndex(i));
                element.parent.SendToBack();
            };
        }

        public static void SlideAndHideVisualElement(VisualElement visualElement, string nameOfElementToSlide, bool slideToLeft)
        {
            var elementToSlide = visualElement.Q<VisualElement>(nameOfElementToSlide);
            var distanceToSlide = visualElement.contentRect.width;
            elementToSlide.style.translate = slideToLeft ? 
                new StyleTranslate(new Translate(-distanceToSlide, 0, 0)) : 
                new StyleTranslate(new Translate(distanceToSlide, 0, 0));
            elementToSlide.style.opacity = 0f;
        }
    }
}
