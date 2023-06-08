using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class VertexSelectableState : VertexBaseState
{
    public override void ClickEvent(VertexController vertex)
    {
        GraphManager.Instance.SelectVertex(vertex);
    }

    public override void DragEndEvent(VertexController vertex, Vector3 vector3)
    {
        
    }

    public override void DragEvent(VertexController vertex, Vector3 pos)
    {

    }

    public override void EnterState(VertexStateManager stateManager)
    {
        Debug.Log("Vertices entered Selectable State");
    }

    public override void UpdateState(VertexStateManager stateManager)
    {
        if(!Input.GetKey(KeyCode.LeftControl)) 
        {
            stateManager.SwitchState(stateManager.NormalState);
        }
    }
}

