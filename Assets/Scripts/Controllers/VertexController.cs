using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VertexController : GraphElement
{
    public static VertexStateManager stateManager;
    private LineRenderer lr;

    private VertexAppearance _appearance;

    private void Start()
    {
        InitializeVertex();
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }
    private void Update()
    {
        // Unhappy with this solution, as this should be taken care of in the state switch.
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ResetLine();
        }
    }

    public void CheckForConnectionAtPosition(Vector3 pos)
    {
        
        Vector3 posUp = new Vector3(pos.x, pos.y, -1);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.up);
        
        VertexController v;

        v = hit.transform.gameObject.GetComponent<VertexController>(); // exception handling here
        
        if(v != null)
        {
            GraphManager.Instance.AddEdge(this, v, 1);
        }
        ResetLine();
    }

    private void InitializeVertex()
    {
        stateManager = VertexStateManager.Instance;
    }

    public void UpdatePosition(Vector3 pos)
    {
        transform.position = pos;
        lr.SetPosition(0, pos);
        lr.SetPosition(1, pos);
    }

    internal void ResetLine()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }

    public void OnClick(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        if(pointerData.pointerId == -1)
        {
            Debug.Log("LeftClick on Vertex");
            GraphManager.Instance.SelectVertex(this);
        } else if(pointerData.pointerId == -2)
        {
            Debug.Log("RightClick on Vertex");
            GraphManager.Instance.RemoveVertex(this);
        }
    }

    public void DrawLine(Vector3 pos)
    {
        lr.SetPosition(1, pos);
    }

    public void OnDrag(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        stateManager.CurrentState.DragEvent(this, Utilities.ScreenToWorldPosition(pointerData.position));
    }

    public void OnDragEnd(BaseEventData data)
    {
        PointerEventData pointerData = data as PointerEventData;
        stateManager.CurrentState.DragEndEvent(this, Utilities.ScreenToWorldPosition(pointerData.position));
    }

    public void DeleteVertex()
    {
        Destroy(gameObject);
    }

    internal void SetAppearance(VertexAppearance appearance)
    {
        _appearance = appearance;
        if (appearance.Equals(VertexAppearance.NORMAL)) 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        } else if (appearance.Equals(VertexAppearance.SELECTED)) 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}

public enum VertexAppearance
{
    NORMAL,
    SELECTED
}
