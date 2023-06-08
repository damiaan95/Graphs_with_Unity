using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    //VisualElement algorithmUIPanel;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button dijkstraButton = root.Q<Button>("dijkstra-button");
        dijkstraButton.RegisterCallback<ClickEvent>(ev => GraphManager.Instance.RunAlgorithm());

        /*foreach(var algorithmName in UIFactory.getAlgorithmUINames())
        {
            Button button = new Button();
            button.name = algorithmName + "-button";
            button.text = algorithmName;
            button.style.height = panel.style.height;
            button.RegisterCallback<ClickEvent>(ev => GraphManager.Instance.RunAlgorithm());
            panel.Add(button);
        }*/

    }

    /*private void SetAlgorithmUI(string algorithmName)
    {
        if(algorithmUIPanel.childCount != 0)
        {
            algorithmUIPanel.Clear();
        }

        /*VisualElement algUI = UIFactory.GetAlgorithmUI(algorithmName).AlgorithmUITool;

        Button hideButton = new Button();
        hideButton.text = "Hide";
        hideButton.style.width = 100;
        hideButton.style.height = 36;
        hideButton.style.unityFontStyleAndWeight = FontStyle.Bold;
        hideButton.style.fontSize = 14;
        hideButton.style.marginBottom = 10;
        hideButton.RegisterCallback<ClickEvent>(ev => algorithmUIPanel.Clear());

        algorithmUIPanel.Add(algUI);
        algorithmUIPanel.Add(hideButton);
    }*/
}
