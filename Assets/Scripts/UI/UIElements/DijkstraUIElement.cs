using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlgorithmUIElements
{
    class DijkstraUIElement : VisualElement
    {
        public int width { get; set; }
        public int height { get; set; }

        private StyleSheet styleSheet;

        private VisualElement dijkstraElement;
        private Button runButton;
        private VisualElement startBox;
        private VisualElement endBox;
        private VisualElement ghostIcon;

        public DijkstraUIElement()
        {
            styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI Toolkit/StyleSheets/dijkstra.uss");
            styleSheets.Add(styleSheet);

            dijkstraElement = new VisualElement();
            runButton = new RunButton();

            startBox = new SelectBox();
            endBox = new SelectBox();
            startBox.AddToClassList("start-box");
            endBox.AddToClassList("end-box");
            ghostIcon = new GhostVertex();

            Add(dijkstraElement);
            dijkstraElement.Add(startBox);
            dijkstraElement.Add(endBox);
            dijkstraElement.Add(ghostIcon);
            dijkstraElement.Add(runButton);
            dijkstraElement.AddToClassList("dijkstra-element");

            AddToClassList("dijkstra-parent");
            

        }
        

        public new class UxmlFactory : UxmlFactory<DijkstraUIElement, UxmlTraits> { }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlIntAttributeDescription m_width = new UxmlIntAttributeDescription() 
                { name = "width", defaultValue = 200};
            UxmlIntAttributeDescription m_height = new UxmlIntAttributeDescription()
                { name = "height", defaultValue = 300 };
            //UxmlIntAttributeDescription m_vertexBoxSize = new UxmlIntAttributeDescription()
                //{ name = "vertex-box-size", defaultValue = }

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var ate = ve as DijkstraUIElement;

                ate.width = m_width.GetValueFromBag(bag, cc);
                ate.height = m_height.GetValueFromBag(bag, cc);

                ate.Clear();

                VisualTreeAsset vt = Resources.Load<VisualTreeAsset>("UI Documents/DijkstraUIElement");
                VisualElement dijkstraUIElement = vt.Instantiate();

                ate.dijkstraElement = dijkstraUIElement.Q<VisualElement>("dijkstra-element");
                //ate.dkeRunButton = dijkstraUIElement.Q<VisualElement>("run-button");
                //ate.dkeHideButton = dijkstraUIElement.Q<Button>("hide-button");

               // ate.dkeHideButton.RegisterCallback<ClickEvent>(ev => );

                ate.Add(dijkstraUIElement);

                ate.dijkstraElement.style.width = ate.width;
                ate.dijkstraElement.style.height = ate.height;
                ate.style.width = ate.width;
                ate.style.height = ate.height;
            }
        }

    }
}
