using UnityEngine;

public class VertexConnectState : VertexBaseState
{
    public override void EnterState(VertexStateManager stateManager)
    {
        Debug.Log("Vertices Entered Connect State");
    }

    public override void UpdateState(VertexStateManager stateManager)
    {
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            stateManager.SwitchState(stateManager.NormalState);
        }
    }

    public override void DragEvent(VertexController vertex, Vector3 pos)
    {
        vertex.DrawLine(pos);
    }

    public override void DragEndEvent(VertexController vertex, Vector3 pos)
    {
        vertex.CheckForConnectionAtPosition(pos);
    }

    public override void ClickEvent(VertexController vertex)
    {
        
    }
}