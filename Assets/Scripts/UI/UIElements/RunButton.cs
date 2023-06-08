using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RunButton : Button
{
    public RunButton()
    {
        text = "Run Algorithm";
        AddToClassList("run-button");
    }

    private void OnButtonClick()
    {
        GraphManager.Instance.RunAlgorithm();
    }
}
