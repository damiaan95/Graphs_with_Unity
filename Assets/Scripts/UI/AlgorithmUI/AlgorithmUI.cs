using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class AlgorithmUI
{
    public abstract string Name { get; }
    protected abstract Algorithm algorithm { get; }

    protected virtual VisualElement algUIElement { 
        get 
        {
            var button = new Button();
            button.text = "algorithm";
            return button;
        } 
    }

    public abstract VisualElement AlgorithmUITool { get; }
}
