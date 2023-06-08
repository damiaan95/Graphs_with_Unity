using AlgorithmUIElements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DijkstraUI : AlgorithmUI
{
    public override string Name => "Dijkstra";

    private Algorithm alg;
    protected override Algorithm algorithm => alg;

    protected override VisualElement algUIElement
    {
        get
        {
            DijkstraUIElement dijkstraElement = new DijkstraUIElement();
            return dijkstraElement;
        }
    }

    public override VisualElement AlgorithmUITool => algUIElement;
}
