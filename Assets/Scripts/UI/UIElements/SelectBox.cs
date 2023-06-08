using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectBox : VisualElement
{
    private VisualElement selectedElement;

    public SelectBox()
    {
        AddToClassList("select-box");
    }

    public void HoldElement(VisualElement element)
    {
        selectedElement = element;
    }

    public void DropElement()
    {
        selectedElement = null;
    }
}
