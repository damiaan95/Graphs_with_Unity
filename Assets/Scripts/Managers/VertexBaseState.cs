using System;
using UnityEngine;

public abstract class VertexBaseState
{
    public abstract void EnterState(VertexStateManager stateManager);
    public abstract void UpdateState(VertexStateManager stateManager);
    public abstract void DragEvent(VertexController vertex, Vector3 pos);
    public abstract void DragEndEvent(VertexController vertexController, Vector3 vector3);
}