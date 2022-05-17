using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
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
            DisplayHeader();
            //FillBodyWithFromStateElements();

            return _visualElement;
        }

        void LoadAndCloneMarkup()
        {
            VisualTreeAsset visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(
                "Packages/com.mikeymusch.verycoolstatemachine/Editor/TransitionTable/TransitionTableMarkup.uxml");
            visualTree.CloneTree(_visualElement);
        }
        void DisplayHeader()
        {
            // binds the nicified version of the TransitionTable's name to the header label
            _visualElement.Q<Label>("header-label").text = ObjectNames.NicifyVariableName(target.name);
        }
        
        void FillBodyWithFromStateElements()
        {
            if (!_transitionTable.transitionGroups.Any())
            {
                // display no states warning
                return;
            }

            VisualElement body = _visualElement.Q<VisualElement>("body");
        }
    }
}