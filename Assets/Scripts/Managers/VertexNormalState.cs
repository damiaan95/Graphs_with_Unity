using UnityEngine;

public class VertexNormalState : VertexBaseState
{
    public override void EnterState(VertexStateManager stateManager)
    {
        Debug.Log("Vertices Entered Normal State");
    }

    public override void UpdateState(VertexStateManager stateManager)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stateManager.SwitchState(stateManager.ConnectState);
        } else if(Input.GetKey(KeyCode.LeftControl)) 
        {
            stateManager.SwitchState(stateManager.SelectableState);
        }
    }

    public override void DragEvent(VertexController vertex, Vector3 pos)
    {
        vertex.UpdatePosition(pos);
    }

    public override void DragEndEvent(VertexController vertex, Vector3 pos)
    {
        
    }

    public override void ClickEvent(VertexController vertex)
    {
    
    }
}