using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GraphController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GraphManager.Instance.Graph.OnRemoveVertex = DeleteVertex;
        GraphManager.Instance.Graph.OnAddEdge = CreateEdge;
        GraphManager.Instance.Graph.OnRemoveEdge = DeleteEdge;
    }

    public void OnClick(BaseEventData eventData) 
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData.pointerId == -1)
        {
            Debug.Log("LeftClick on Background");
            CreateVertex(pointerData.position);
        }
        else if (pointerData.pointerId == -2)
        {
            Debug.Log("RightClick on Background");
        }
    }

    private void CreateVertex(Vector2 position)
    {
        GameObject vertex = GraphFactory.GetGraphElement("Vertex");
        VertexController vertexController = Instantiate(vertex, Utilities.ScreenToWorldPosition(position), Quaternion.identity, transform).GetComponent<VertexController>();
        GraphManager.Instance.AddVertex(vertexController);
    }

    private void DeleteVertex(VertexController v)
    {
        v.DeleteVertex();
    }

    public void CreateEdge(VertexController v1, VertexController v2, int weight)
    {
        GameObject edge = GraphFactory.GetGraphElement("Edge");
        EdgeController edgeController = Instantiate(edge, v1.transform.position, Quaternion.identity, transform).GetComponent<EdgeController>();

        edgeController.Initialize(v1, v2, weight);

        GraphManager.Instance.EdgeControllers.Add(edgeController);
    }

    public void DeleteEdge(VertexController v1, VertexController v2)
    {
        EdgeController e = GraphManager.Instance.GetEdge(v1, v2);
        
        if(e == null)
        {
            throw new Exception("Edge does not exist in GraphManager!!");
        }

        GraphManager.Instance.EdgeControllers.Remove(e);
        e.DeleteEdge();
    }
}
