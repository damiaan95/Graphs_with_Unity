using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexStateManager : MonoBehaviour
{

    public static VertexStateManager Instance { get; private set; }

    public VertexBaseState CurrentState { get; private set; }
    public VertexNormalState NormalState = new VertexNormalState();
    public VertexConnectState ConnectState = new VertexConnectState();
    public VertexSelectableState SelectableState = new VertexSelectableState();

    void Awake()
    {
        Instance = this;
        CurrentState = NormalState;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    internal void SwitchState(VertexBaseState state)
    {
        CurrentState = state;
    }
}
